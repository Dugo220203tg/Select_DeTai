using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WrbDeTai.Data;
using WrbDeTai.Models;
using Microsoft.AspNetCore.Identity;

namespace WrbDeTai.Controllers
{
    public class AccountController : Controller
    {
        private readonly ProjectManagerContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(
            ProjectManagerContext context,
            ILogger<AccountController> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        private ProjectManagerContext db = new ProjectManagerContext();

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.StudentId == model.StudentId && a.Password == model.Password);

            if (account != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.StudentId),
                new Claim("FullName", account.Name),
            };

                var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                };

                await HttpContext.SignInAsync(
                  IdentityConstants.ApplicationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties);


                // Lưu thông tin vào session
                HttpContext.Session.SetString("StudentId", account.StudentId);
                HttpContext.Session.SetString("AccountName", account.Name);
                _logger.LogInformation("User {StudentId} logged in successfully", account.StudentId);

                return RedirectToAction("Select", "Topic");
            }
            else
            {
                ModelState.AddModelError("", "Thông tin đăng nhập không chính xác.");
                return View(model);
            }
        }

        // GET: /Account/ChangePassword
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        // POST: /Account/ChangePassword
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Lấy StudentId từ session
            string studentId = HttpContext.Session.GetString("StudentId");
            if (string.IsNullOrEmpty(studentId))
            {
                return RedirectToAction("Login");
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(ac => ac.StudentId == studentId);

            if (account != null)
            {
                // Kiểm tra mật khẩu cũ có đúng không
                if (account.Password != model.OldPassword)
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không chính xác.");
                    return View(model);
                }

                // Cập nhật mật khẩu mới
                account.Password = model.NewPassword;
                account.ModifiedDate = DateOnly.FromDateTime(DateTime.Now);
                account.ModifiedUser = studentId;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";
                return RedirectToAction("Select", "Topic");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại.");
            }

            return View(model);
        }


        // GET: /Account/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
