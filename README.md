# TravelokaV2
# TravelokaV2 – REST API Docs (Tiếng Việt)

Tài liệu này mô tả các endpoint phục vụ frontend. Tất cả ví dụ dưới đây dùng JSON.

- **Base URL**: `https://<domain>/api`
- **Auth**: Bearer JWT (`Authorization: Bearer <access_token>`) cho các endpoint yêu cầu.
- **Content-Type**: `application/json; charset=utf-8`
- **Mã lỗi chuẩn**: `400` (validate), `401` (unauthorized), `403` (forbidden), `404` (not found), `409` (conflict), `500` (server)

## Mục lục
- [Mô hình Auth](#mô-hình-auth)
- [Quy ước phân trang và sắp xếp](#quy-ước-phân-trang-và-sắp-xếp)
- [Accommodation](#accommodation)
  - [Tìm kiếm & phân trang](#tìm-kiếm--phân-trang)
  - [CRUD](#crud)
  - [General Info](#general-info)
  - [Policy](#policy)
  - [Assign Image](#assign-image)
  - [Assign Facility](#assign-facility)
- [AccomType](#accomtype)
- [BedType](#bedtype)
- [CancelPolicy](#cancelpolicy)
- [Facility](#facility)
- [Image](#image)
- [PaymentMethod](#paymentmethod)
- [PaymentRecord](#paymentrecord)
- [RoomCategory](#roomcategory)
  - [Facilities cho RoomCategory](#facilities-cho-roomcategory)
  - [Images cho RoomCategory](#images-cho-roomcategory)
- [Room](#room)
- [Reviews & Rating](#reviews--rating)
- [Ví dụ cURL](#ví-dụ-curl)

---

## Mô hình Auth
**Models**
```json
AuthResponse {
  accessToken: string,
  refreshToken: string,
  userId: string,
  userName: string,
  email: string
}
```
**Endpoints**
- `POST /auth/register` → Body: `RegisterRequest` → 200 `AuthResponse`
- `POST /auth/login` → Body: `LoginRequest` → 200 `AuthResponse`
- `POST /auth/refresh` → Body: `RefreshRequest` → 200 `AuthResponse`
- `GET  /auth/me` *(Authorize)* → 200: thông tin user hiện tại

---

## Quy ước phân trang và sắp xếp
Nếu controller hỗ trợ phân trang (vd: Accommodation search), dùng `PagedQuery` với các tham số:
- `page` *(int)* – trang hiện tại (mặc định 1)
- `pageSize` *(int)* – số bản ghi/trang (mặc định 20)
- `sortBy` *(string)* – trường sắp xếp (vd: `name`, `rating`)
- `sortDir` *(asc|desc)* – chiều sắp xếp

Response dạng `PagedResult<T>`:
```json
{
  "items": [/* T */],
  "page": 1,
  "pageSize": 20,
  "total": 123,
  "totalPages": 7
}
```

---

## Accommodation
**Base**: `/accommodation`

### Tìm kiếm & phân trang
- **GET** `/accommodation`
  - **Query params**:
    - `q` *(string, optional)* – Từ khóa tìm kiếm
    - `accomTypeId` *(GUID, optional)* – Lọc theo loại chỗ ở
    - `starMin` *(int, optional)* – Số sao tối thiểu (1–5)
    - `ratingMin` *(float, optional)* – Điểm đánh giá tối thiểu (0.0–10.0)
    - `page`, `pageSize`, `sortBy`, `sortDir` *(từ PagedQuery)*
  - **Res**: `PagedResult<AccomSummaryDto>` (200)

### CRUD
- **GET** `/accommodation/{id}` → `AccomDetailDto` (200)
- **POST** `/accommodation` → Body: `AccomCreateDto` → `201 Created` (trả `Guid`)
- **POST** `/accommodation/bulk` → Body: `List<AccomCreateDto>` → `200 OK` (`List<Guid>`)
- **PUT** `/accommodation/{id}` → Body: `AccomUpdateDto` → `204 No Content`
- **DELETE** `/accommodation/{id}` → `204 No Content`

### General Info
- **GET** `/accommodation/{accomId}/general-info` → `GeneralInfoDto` (200 hoặc `404` nếu không có)
- **PUT** `/accommodation/{accomId}/general-info` → Body: `GeneralInfoUpdateDto` → `204 No Content`
- **DELETE** `/accommodation/{accomId}/general-info` → `204 No Content`

### Policy
- **GET** `/accommodation/{accomId}/policy` → `PolicyDto` (200 hoặc `404`)
- **PUT** `/accommodation/{accomId}/policy` → Body: `PolicyUpdateDto` → `204 No Content`
- **DELETE** `/accommodation/{accomId}/policy` → `204 No Content`

### Assign Image
- **POST** `/accommodation/{accomId}/images/{imageId}` → Gắn 1 ảnh → `204 No Content`
- **DELETE** `/accommodation/{accomId}/images/{imageId}` → Gỡ 1 ảnh → `204 No Content`
- **POST** `/accommodation/{accomId}/images/bulk` → Body: `List<Guid>` (imageId) → `200 OK` (số lượng đã gắn)

### Assign Facility
- **POST** `/accommodation/{accomId}/facilities/{facilityId}` → Gắn 1 tiện nghi → `204 No Content`
- **DELETE** `/accommodation/{accomId}/facilities/{facilityId}` → Gỡ 1 tiện nghi → `204 No Content`
- **POST** `/accommodation/{accomId}/facilities/bulk` → Body: `List<Guid>` (facilityId) → `200 OK` (số lượng đã gắn)

---

## AccomType
**Base**: `/accomtype`

- **GET** `/accomtype` → `AccomTypeDto[]` (200)
- **GET** `/accomtype/{id}` → `AccomTypeDto` (200)
- **POST** `/accomtype` → Body: `AccomTypeCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/accomtype/{id}` → Body: `AccomTypeUpdateDto` → `204 No Content`
- **DELETE** `/accomtype/{id}` → `204 No Content`

---

## BedType
**Base**: `/bedtype`

- **GET** `/bedtype` → `BedTypeDto[]` (200)
- **GET** `/bedtype/{id}` → `BedTypeDto` (200)
- **POST** `/bedtype` → Body: `BedTypeCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/bedtype/{id}` → Body: `BedTypeUpdateDto` → `204 No Content`
- **DELETE** `/bedtype/{id}` → `204 No Content`

---

## CancelPolicy
**Base**: `/cancelpolicy`

- **GET** `/cancelpolicy` → `CancelPolicyDto[]` (200)
- **GET** `/cancelpolicy/{id}` → `CancelPolicyDto` (200)
- **POST** `/cancelpolicy` → Body: `CancelPolicyCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/cancelpolicy/{id}` → Body: `CancelPolicyUpdateDto` → `204 No Content`
- **DELETE** `/cancelpolicy/{id}` → `204 No Content`

---

## Facility
**Base**: `/facility`

- **GET** `/facility` → `FacilityDto[]` (200)
- **GET** `/facility/{id}` → `FacilityDto` (200)
- **POST** `/facility` → Body: `FacilityCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/facility/{id}` → Body: `FacilityUpdateDto` → `204 No Content`
- **DELETE** `/facility/{id}` → `204 No Content`
- **POST** `/facility/bulk` → Body: `List<FacilityCreateDto>` → `200 OK` (`List<Guid>`)

---

## Image
**Base**: `/image`

- **GET** `/image` → `ImageDto[]` (200)
- **GET** `/image/{id}` → `ImageDto` (200)
- **POST** `/image` → Body: `ImageCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/image/{id}` → Body: `ImageUpdateDto` → `204 No Content`
- **DELETE** `/image/{id}` → `204 No Content`
- **POST** `/image/bulk` → Body: `List<ImageCreateDto>` → `200 OK` (`List<Guid>`)

---

## PaymentMethod
**Base**: `/paymentmethod`

- **GET** `/paymentmethod` → `PaymentMethodDto[]` (200)
- **GET** `/paymentmethod/{id}` → `PaymentMethodDto` (200)
- **POST** `/paymentmethod` → Body: `PaymentMethodCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/paymentmethod/{id}` → Body: `PaymentMethodUpdateDto` → `204 No Content`
- **DELETE** `/paymentmethod/{id}` → `204 No Content`

---

## PaymentRecord
**Base**: `/paymentrecord`

- **POST** `/paymentrecord` *(Authorize)* → Body: `PaymentRecordCreateDto` → `201 Created` (trả `Guid`)
  - Header: `Authorization: Bearer <access_token>` (server lấy `userId`, `userName` từ token)
- **GET** `/paymentrecord/{id}` → `PaymentRecordDto` (200)
- **GET** `/paymentrecord` → `PaymentRecordDto[]` (200)
- **PUT** `/paymentrecord/{id}` → Body: `PaymentRecordUpdateDto` → `204 No Content`
- **DELETE** `/paymentrecord/{id}` → `204 No Content`

---

## RoomCategory
**Base**: `/roomcategory`

- **GET** `/roomcategory/{id}` → `RoomCategoryDto` (200)
- **GET** `/roomcategory/Accommodations/{accomId}` → `RoomCategoryDto[]` (200)
- **POST** `/roomcategory` → Body: `RoomCategoryCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/roomcategory/{id}` → Body: `RoomCategoryUpdateDto` → `204 No Content`
- **DELETE** `/roomcategory/{id}` → `204 No Content`
- **POST** `/roomcategory/bulk` → Body: `List<RoomCategoryCreateDto>` → `200 OK` (`List<Guid>`)

### Facilities cho RoomCategory
- **POST** `/roomcategory/{roomCategoryId}/facilities/{facilityId}` → Gắn 1 tiện nghi → `204 No Content`
- **DELETE** `/roomcategory/{roomCategoryId}/facilities/{facilityId}` → Gỡ 1 tiện nghi → `204 No Content`
- **POST** `/roomcategory/{roomCategoryId}/facilities/bulk` → Body: `List<Guid>` (facilityId) → `200 OK` (số lượng đã gắn)

### Images cho RoomCategory
- **POST** `/roomcategory/{roomCategoryId}/images/{imageId}` → Gắn 1 ảnh → `204 No Content`
- **DELETE** `/roomcategory/{roomCategoryId}/images/{imageId}` → Gỡ 1 ảnh → `204 No Content`
- **POST** `/roomcategory/{roomCategoryId}/images/bulk` → Body: `List<Guid>` (imageId) → `200 OK` (số lượng đã gắn)

---

## Room
**Base**: `/room`

- **GET** `/room/{id}` → `RoomDetailDto` (200)
- **GET** `/room/Categories/{categoryId}` → `RoomSummaryDto[]` (200)
- **POST** `/room` → Body: `RoomCreateDto` → `201 Created` (trả `Guid`)
- **PUT** `/room/{id}` → Body: `RoomUpdateDto` → `204 No Content`
- **DELETE** `/room/{id}` → `204 No Content`
- **POST** `/room/bulk` → Body: `List<RoomCreateDto>` → `200 OK` (`List<Guid>`)

---

## Reviews & Rating
**Base**: `/reviewsandrating`

- **GET** `/reviewsandrating/Accommodations/{accomId}` → `ReviewDto[]` (200)
- **POST** `/reviewsandrating/Accommodations/{accomId}` *(Authorize)* → Body: `ReviewCreateDto` → `201 Created` (trả `Guid`)
  - Header: `Authorization: Bearer <access_token>` (server lấy `userId`, `userName` từ token)
- **GET** `/reviewsandrating/{id}` → `ReviewDto` (200)
- **PUT** `/reviewsandrating/{id}` → Body: `ReviewUpdateDto` → `204 No Content`
- **DELETE** `/reviewsandrating/{id}` → `204 No Content`

---


