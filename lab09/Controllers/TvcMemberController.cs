using Microsoft.AspNetCore.Mvc;
using lab09.Models;

namespace lab09.Controllers;

public class TvcMemberController : Controller
{
    private static readonly List<TvcMember> _members = new()
    {
        new(){TvcMemberId=Guid.NewGuid().ToString(),TvcUserName="nguyenvanhiep",TvcPassword="123456",TvcFullName="Nguyễn Văn Hiệp - 2410900035",TvcEmail="hiep2410900035@gmail.com"},
        new(){TvcMemberId=Guid.NewGuid().ToString(),TvcUserName="tranthib",TvcPassword="123456",TvcFullName="Trần Thị Bình",TvcEmail="tranthib@example.com"},
        new(){TvcMemberId=Guid.NewGuid().ToString(),TvcUserName="levancuong",TvcPassword="123456",TvcFullName="Lê Văn Cường",TvcEmail="levancuong@example.com"}
    };
    [HttpGet("/TvcMember")]
    public IActionResult Index()=>View(_members);
    [HttpGet] public IActionResult TvcCreate()=>View(new TvcMember());
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TvcCreate(TvcMember member)
    {
        if(_members.Any(x=>x.TvcUserName.Equals(member.TvcUserName,StringComparison.OrdinalIgnoreCase)))ModelState.AddModelError(nameof(member.TvcUserName),"Tên đăng nhập đã tồn tại");
        if(_members.Any(x=>x.TvcEmail.Equals(member.TvcEmail,StringComparison.OrdinalIgnoreCase)))ModelState.AddModelError(nameof(member.TvcEmail),"Email đã tồn tại");
        if(!ModelState.IsValid)return View(member);
        member.TvcMemberId=Guid.NewGuid().ToString();_members.Add(member);TempData["Message"]="Thêm thành viên thành công";return RedirectToAction(nameof(Index));
    }
    [HttpGet] public IActionResult TvcEdit(string id){var m=_members.FirstOrDefault(x=>x.TvcMemberId==id);return m==null?NotFound():View(m);}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TvcEdit(TvcMember member)
    {
        if(_members.Any(x=>x.TvcMemberId!=member.TvcMemberId&&x.TvcUserName.Equals(member.TvcUserName,StringComparison.OrdinalIgnoreCase)))ModelState.AddModelError(nameof(member.TvcUserName),"Tên đăng nhập đã tồn tại");
        if(_members.Any(x=>x.TvcMemberId!=member.TvcMemberId&&x.TvcEmail.Equals(member.TvcEmail,StringComparison.OrdinalIgnoreCase)))ModelState.AddModelError(nameof(member.TvcEmail),"Email đã tồn tại");
        if(!ModelState.IsValid)return View(member);
        var old=_members.FirstOrDefault(x=>x.TvcMemberId==member.TvcMemberId);if(old==null)return NotFound();old.TvcUserName=member.TvcUserName;old.TvcPassword=member.TvcPassword;old.TvcFullName=member.TvcFullName;old.TvcEmail=member.TvcEmail;TempData["Message"]="Cập nhật thành công";return RedirectToAction(nameof(Index));
    }
    public IActionResult TvcDetails(string id){var m=_members.FirstOrDefault(x=>x.TvcMemberId==id);return m==null?NotFound():View(m);}
    [HttpGet] public IActionResult TvcDelete(string id){var m=_members.FirstOrDefault(x=>x.TvcMemberId==id);return m==null?NotFound():View(m);}
    [HttpPost]
    [ValidateAntiForgeryToken] public IActionResult TvcDeleted(string id){var m=_members.FirstOrDefault(x=>x.TvcMemberId==id);if(m==null)return NotFound();_members.Remove(m);TempData["Message"]="Xóa thành viên thành công";return RedirectToAction(nameof(Index));}
}
