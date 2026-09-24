using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab09.Models;

public class TvcMember
{
    public string TvcMemberId { get; set; } = string.Empty;

    [DisplayName("Tên đăng nhập")]
    [Required(ErrorMessage="Vui lòng nhập tên đăng nhập")]
    [StringLength(30,MinimumLength=4,ErrorMessage="Tên đăng nhập từ 4 đến 30 ký tự")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$",ErrorMessage="Tên đăng nhập chỉ gồm chữ, số và dấu gạch dưới")]
    public string TvcUserName { get; set; } = string.Empty;

    [DisplayName("Mật khẩu")]
    [Required(ErrorMessage="Vui lòng nhập mật khẩu")]
    [StringLength(50,MinimumLength=6,ErrorMessage="Mật khẩu phải có ít nhất 6 ký tự")]
    [DataType(DataType.Password)]
    public string TvcPassword { get; set; } = string.Empty;

    [DisplayName("Họ và tên")]
    [Required(ErrorMessage="Vui lòng nhập họ và tên")]
    [StringLength(100,MinimumLength=2,ErrorMessage="Họ tên từ 2 đến 100 ký tự")]
    public string TvcFullName { get; set; } = string.Empty;

    [DisplayName("Email")]
    [Required(ErrorMessage="Vui lòng nhập email")]
    [EmailAddress(ErrorMessage="Email không đúng định dạng")]
    [StringLength(150)]
    public string TvcEmail { get; set; } = string.Empty;
}
