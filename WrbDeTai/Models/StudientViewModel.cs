using System.ComponentModel.DataAnnotations;

namespace WrbDeTai.Models
{
    public class StudientViewModel
    {

    }
    public class SignInMD
    {
        public string? MaSinhVien {  get; set; }
        public string? PassWord { get; set; }
    }
    public class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int? TeacherId { get; set; }
        public string StudentId { get; set; }
        public string TypeAccount { get; set; }
        public bool Status { get; set; }
        public DateTime? DateIssued { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu cũ")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mã sinh viên")]
        [Display(Name = "Mã sinh viên")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập?")]
        public bool RememberMe { get; set; }
    }
}
