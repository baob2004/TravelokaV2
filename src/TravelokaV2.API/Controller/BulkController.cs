using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.ReviewsAndRating; // nếu bạn đã đặt BulkReview* DTO ở Application
using TravelokaV2.Application.DTOs.RoomCategory;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Application.Services;              // IReviewsService
using TravelokaV2.Infrastructure.Identity;
using static TravelokaV2.Application.DTOs.ReviewsAndRating.BulkPayment;
using static TravelokaV2.Application.DTOs.ReviewsAndRating.BulkReview;

namespace TravelokaV2.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BulkController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IReviewsService _reviewsService;
        IPaymentRecordService _paymentRecordService;
        private readonly IUnitOfWork _uow;

        public BulkController(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IReviewsService reviewsService,
            IPaymentRecordService paymentRecordService,
            IUnitOfWork uow
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _reviewsService = reviewsService;
            _uow = uow;
            _paymentRecordService = paymentRecordService;
        }

        // ========================= BULK USERS =========================

        /// <summary>Bulk tạo nhiều user một lúc (chỉ Admin).</summary>
        /// 
        [Authorize(Roles ="Admin")]
        [HttpPost("users")]
        [ProducesResponseType(typeof(BulkUserCreateResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<BulkUserCreateResponse>> BulkCreateUsers(
            [FromBody] BulkUserCreateRequest req,
            CancellationToken ct)
        {
            if (req?.Users is null || req.Users.Count == 0)
                return BadRequest("Users is empty.");

            var results = new List<BulkUserCreateItemResult>(req.Users.Count);

            foreach (var u in req.Users)
            {
                if (ct.IsCancellationRequested) break;

                var errs = new List<string>();
                if (string.IsNullOrWhiteSpace(u.Email)) errs.Add("Email is required.");
                if (string.IsNullOrWhiteSpace(u.UserName)) u.UserName = u.Email;

                if (errs.Count > 0)
                {
                    results.Add(BulkUserCreateItemResult.Fail(u.Email, u.UserName, errs));
                    continue;
                }

                // Check exists
                var existedByEmail = await _userManager.FindByEmailAsync(u.Email);
                var existedByUser = await _userManager.FindByNameAsync(u.UserName);
                if (existedByEmail != null || existedByUser != null)
                {
                    if (req.SkipExisting)
                    {
                        results.Add(BulkUserCreateItemResult.Skip(u.Email, u.UserName, "User already exists."));
                        continue;
                    }
                    results.Add(BulkUserCreateItemResult.Fail(u.Email, u.UserName, "User already exists."));
                    continue;
                }

                // Create entity
                var entity = new AppUser
                {
                    Email = u.Email,
                    UserName = u.UserName,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    EmailConfirmed = req.EmailConfirmedByDefault
                };

                // Password
                var password = string.IsNullOrWhiteSpace(u.Password)
                    ? GenerateStrongPassword()
                    : u.Password;

                var createResult = await _userManager.CreateAsync(entity, password);
                if (!createResult.Succeeded)
                {
                    results.Add(BulkUserCreateItemResult.Fail(
                        u.Email, u.UserName,
                        createResult.Errors.Select(e => $"{e.Code}: {e.Description}")));
                    continue;
                }

                // Assign roles
                if (u.Roles is not null && u.Roles.Count > 0)
                {
                    foreach (var role in u.Roles.Distinct(StringComparer.OrdinalIgnoreCase))
                    {
                        if (!await _roleManager.RoleExistsAsync(role))
                        {
                            if (req.AutoCreateMissingRoles)
                            {
                                var r = await _roleManager.CreateAsync(new IdentityRole(role));
                                if (!r.Succeeded)
                                {
                                    results.Add(BulkUserCreateItemResult.Warn(entity.Id, u.Email, u.UserName,
                                        $"Create role '{role}' failed: {string.Join("; ", r.Errors.Select(e => e.Description))}"));
                                    continue;
                                }
                            }
                            else
                            {
                                results.Add(BulkUserCreateItemResult.Warn(entity.Id, u.Email, u.UserName,
                                    $"Role '{role}' does not exist."));
                                continue;
                            }
                        }

                        var addRole = await _userManager.AddToRoleAsync(entity, role);
                        if (!addRole.Succeeded)
                        {
                            results.Add(BulkUserCreateItemResult.Warn(entity.Id, u.Email, u.UserName,
                                $"AddToRole '{role}' failed: {string.Join("; ", addRole.Errors.Select(e => e.Description))}"));
                        }
                    }
                }

                results.Add(BulkUserCreateItemResult.Success(entity.Id, u.Email, u.UserName,
                    passwordGenerated: string.IsNullOrWhiteSpace(u.Password) ? password : null));
            }

            var response = new BulkUserCreateResponse
            {
                Total = req.Users.Count,
                Succeeded = results.Count(x => x.Status == "success"),
                Skipped = results.Count(x => x.Status == "skipped"),
                Failed = results.Count(x => x.Status == "failed"),
                Warned = results.Count(x => x.Status == "warning"),
                Results = results
            };

            return Ok(response);
        }

        // ====================== BULK REVIEWS BY ACCOM ======================

        /// <summary>
        /// Bulk tạo nhiều review cho một accommodation từ danh sách user đã tồn tại.
        /// </summary>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPost("accommodations/reviews")]
        [ProducesResponseType(typeof(BulkReviewCreateResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<BulkReviewCreateResponse>> BulkCreateReviewsForAccommodation(
            [FromBody] BulkReviewCreateCommand cmd,
            CancellationToken ct)
        {
            if (cmd is null || cmd.Items is null || cmd.Items.Count == 0)
                return BadRequest("Items is empty.");

            // map sang request cũ để tái dùng service
            var req = new BulkReviewCreateRequest
            {
                SkipExisting = cmd.SkipExisting,
                DefaultCreatedAtUtc = cmd.DefaultCreatedAtUtc,
                Items = cmd.Items
            };

            var result = await _reviewsService.BulkCreateAsync(cmd.AccomId, req, ct);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users/ids")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUserIds(CancellationToken ct)
        {
            var ids = await _userManager.Users
                .Select(u => u.Id)
                .ToListAsync(ct);

            return Ok(ids);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("accommodations/ids")]
        [ProducesResponseType(typeof(IEnumerable<Guid>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAllAccommodationIds(CancellationToken ct = default)
        {
            var ids = await _uow.Accommodations
                .Query()
                .Select(a => a.Id)
                .ToListAsync(ct);

            return Ok(ids);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("paymentmethods/ids")]
        [ProducesResponseType(typeof(IEnumerable<Guid>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAllPaymentMethodIds(CancellationToken ct = default)
        {
            var ids = await _uow.PaymentMethods
                .Query()
                .Select(pm => pm.Id)
                .ToListAsync(ct);

            return Ok(ids);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("paymentrecords")]
        public async Task<ActionResult<BulkPaymentRecordCreateResponse>> BulkCreatePaymentRecords(
        [FromBody] BulkPaymentRecordCreateRequest req,
        CancellationToken ct)
        {
            if (req is null || req.Items is null || req.Items.Count == 0)
                return BadRequest("Items is empty.");
            var result = await _paymentRecordService.BulkCreateAsync(req, ct);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("rooms/ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAllRoomIds(CancellationToken ct = default)
        {
            var ids = await _uow.Rooms
                .Query()
                .Select(r => r.Id)
                .ToListAsync(ct);

            return Ok(ids);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("roomcategories/ids")]
        [ProducesResponseType(typeof(IEnumerable<Guid>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAllRoomCategoryIds(CancellationToken ct = default)
        {
            var ids = await _uow.RoomCategories
                .Query()
                .Select(rc => rc.Id)
                .ToListAsync(ct);

            return Ok(ids);
        }

        // ====================== helpers ======================

        private static string GenerateStrongPassword()
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digit = "0123456789";
            const string spec = "!@#$%^&*_-+=.?";
            var rnd = Random.Shared;

            int len = rnd.Next(10, 13);
            var chars = new List<char>
            {
                lower[rnd.Next(lower.Length)],
                upper[rnd.Next(upper.Length)],
                digit[rnd.Next(digit.Length)],
                spec[rnd.Next(spec.Length)]
            };
            var all = lower + upper + digit + spec;
            while (chars.Count < len) chars.Add(all[rnd.Next(all.Length)]);

            for (int i = 0; i < chars.Count; i++)
            {
                int j = rnd.Next(chars.Count);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
            return new string(chars.ToArray());
        }
    }

    #region DTOs for Bulk Users (bạn có thể chuyển các DTO này sang Application layer nếu muốn)

    public class BulkUserCreateRequest
    {
        /// <summary>Cho phép bỏ qua user đã tồn tại (default: true)</summary>
        public bool SkipExisting { get; set; } = true;

        /// <summary>Tự tạo role nếu chưa tồn tại (default: false)</summary>
        public bool AutoCreateMissingRoles { get; set; } = false;

        /// <summary>Đánh dấu EmailConfirmed cho user mới (default: false)</summary>
        public bool EmailConfirmedByDefault { get; set; } = false;

        [Required]
        public List<BulkUserCreateItem> Users { get; set; } = new();
    }

    public class BulkUserCreateItem
    {
        [Required, EmailAddress]
        public string Email { get; set; } = default!;

        /// <summary>Nếu null/empty, mặc định lấy email làm username</summary>
        public string? UserName { get; set; }

        public string? Password { get; set; } // nếu null → generate

        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }

        /// <summary>Danh sách role muốn gán (tuỳ chọn)</summary>
        public List<string>? Roles { get; set; }
    }

    public class BulkUserCreateResponse
    {
        public int Total { get; set; }
        public int Succeeded { get; set; }
        public int Skipped { get; set; }
        public int Failed { get; set; }
        public int Warned { get; set; }
        public List<BulkUserCreateItemResult> Results { get; set; } = new();
    }

    public class BulkUserCreateItemResult
    {
        public string Status { get; set; } = default!; // success | failed | skipped | warning
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Message { get; set; } // thông điệp chung
        public List<string>? Errors { get; set; } // chi tiết lỗi
        public string? PasswordGenerated { get; set; } // trả lại password nếu generate

        public static BulkUserCreateItemResult Success(string userId, string email, string? userName, string? passwordGenerated = null)
            => new() { Status = "success", UserId = userId, Email = email, UserName = userName, PasswordGenerated = passwordGenerated };

        public static BulkUserCreateItemResult Fail(string? email, string? userName, IEnumerable<string> errors)
            => new() { Status = "failed", Email = email, UserName = userName, Errors = errors.ToList() };

        public static BulkUserCreateItemResult Fail(string? email, string? userName, string error)
            => new() { Status = "failed", Email = email, UserName = userName, Errors = new List<string> { error } };

        public static BulkUserCreateItemResult Skip(string? email, string? userName, string message)
            => new() { Status = "skipped", Email = email, UserName = userName, Message = message };

        public static BulkUserCreateItemResult Warn(string userId, string? email, string? userName, string message)
            => new() { Status = "warning", UserId = userId, Email = email, UserName = userName, Message = message };
    }
    #endregion
}
