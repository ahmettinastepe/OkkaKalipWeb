using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.EmailServices.Abstract;
using OkkaKalipWeb.UI.Extensions;
using OkkaKalipWeb.UI.Identity;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ICartService cartService, IInfoService infoService) : base(infoService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel()
            {
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = code });

                // send mail
                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayın", $"Lütfen Email Hesabınızı Onaylamak İçin Linke <a href='http://localhost:62309{callbackUrl}'>Tıklayınız</a>");

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen Bir Hata Oluştu Lütfen Tekrar Deneyiniz.");

            return View(model);
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl,
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu Email İle Daha Önce Hesap Oluşturulmamış");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen Hesabınızı Email ile Onaylayınız.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
                return Redirect(model.ReturnUrl ?? "~/");

            ModelState.AddModelError("", "Email veya Parola Yanlış.");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData.Put("message", new ResultMessage()
            {
                Title = "Oturum Kapatıldı",
                Message = "Hesabınız güvenli bir şekilde sonlandırıldı",
                Css = "warning"
            });

            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Hesap onayı için bilgileriniz yanlış",
                    Css = "danger"
                });

                return Redirect("~/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //create cart object
                    _cartService.InitializeCart(user.Id);

                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = "Hesabınız onaylandı",
                        Css = "success"
                    });

                    return RedirectToAction("Login");
                }
            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = "Hesabınız onaylanamadı",
                Css = "danger"
            });

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View(new AccountModel()
            {
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifre Sıfırlama",
                    Message = "Bilgileriniz Hatalı",
                    Css = "danger"
                });

                return View();
            }


            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifre Sıfırlama",
                    Message = "Girdiğiniz Email adresi ile bir kullanıcı bulunamadı",
                    Css = "danger"
                });

                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new { token = code });

            // send mail
            await _emailSender.SendEmailAsync(email, "Parola Sıfırlama", $"Parolanızı Yenilemek İçin Linke <a href='http://localhost:62309{callbackUrl}'>Tıklayınız</a>");

            TempData.Put("message", new ResultMessage()
            {
                Title = "Parola Sıfırlama",
                Message = "Parola yenilemek için hesabınıza mail gönderildi",
                Css = "warning"
            });

            return RedirectToAction("Login", "Account");
        }

        public IActionResult ResetPassword(string token)
        {
            if (token == null)
                return RedirectToAction("Index", "Home");

            var model = new ResetPasswordModel { Token = token };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return RedirectToAction("Index", "Home");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
                return RedirectToAction("Login", "Account");

            return View(model);
        }

        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}