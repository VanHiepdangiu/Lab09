# Lab 09 - Validate & Data Annotation trong ASP.NET Core MVC

**Sinh viên:** Nguyễn Văn Hiệp — **MSSV:** 2410900035 — **Lớp:** K24CNT1  
**Học phần:** Phát triển ứng dụng với công nghệ .NET

Dựa trên code demo `TvcLesson08Models` trong repo thầy: https://github.com/tvchung/k24cnt1_netcore và bổ sung theo `Labguide05-AspNetCore-Validate-Anotation.pdf`.

## Nội dung
- CRUD thành viên: List, Create, Edit, Details, Delete.
- `[Required]`, `[StringLength]`, `[RegularExpression]`, `[EmailAddress]`.
- `[DataType(DataType.Password)]`.
- Validation message tiếng Việt.
- Kiểm tra trùng Username và Email.
- `ModelState.IsValid`.
- Anti-forgery token.
- Validation phía client qua `_ValidationScriptsPartial`.

## URL
- `/TvcMember`
- `/TvcMember/TvcCreate`
- Link sửa, chi tiết, xóa trong danh sách.

Mở `lab09.sln`, Build Solution rồi F5.
