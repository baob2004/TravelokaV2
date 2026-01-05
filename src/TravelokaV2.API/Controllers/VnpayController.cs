using Microsoft.AspNetCore.Mvc;
using VNPAY;
using VNPAY.Models;
using VNPAY.Models.Enums;
using VNPAY.Models.Exceptions;

namespace TravelokaV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnpayController(IVnpayClient vnpayClient) : ControllerBase
    {
        private readonly IVnpayClient _vnpayClient = vnpayClient;

        [HttpGet]
        public IActionResult Create()
        {
            var request = new VnpayPaymentRequest
            {
                Money = 10000, // Số tiền thanh toán (ví dụ: 10.000 VND)
                Description = "Thanh toan don hang ABC", // Mô tả giao dịch
                BankCode = BankCode.ANY, // Tùy chọn. Mã phương thức thanh toán. Mặc định là tất cả phương thức giao dịch
                Language = DisplayLanguage.Vietnamese // Tùy chọn. Mặc định là tiếng Việt
            };

            var paymentUrlInfor = _vnpayClient.CreatePaymentUrl(request);
            var paymentUrl = paymentUrlInfor.Url;
            return Ok(paymentUrl);
        }

        [HttpGet("callback")]
        public IActionResult PaymentCallback()
        {
            var vnpayData = Request.Query;
            if (vnpayData["vnp_ResponseCode"] == "00")
                return Ok("Thanh toán thành công");
            else
                return BadRequest($"Lỗi thanh toán: {vnpayData["vnp_ResponseCode"]}");
        }


        [HttpGet("ProceedAfterPayment")]
        public IActionResult ProceedAfterPayment()
        {
            try
            {
                var paymentResult = _vnpayClient.GetPaymentResult(Request);

                // Thực hiện hành động nếu thanh toán thành công tại đây. Ví dụ: Cập nhật trạng thái đơn hàng trong cơ sở dữ liệu.
                return Ok();
            }
            catch (VnpayException ex)  // Bắt lỗi liên quan đến VNPAY
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
