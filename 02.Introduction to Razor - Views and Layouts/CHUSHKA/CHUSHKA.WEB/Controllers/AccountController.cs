namespace CHUSHKA.WEB.Controllers
{
    using CHUSHKA.Models;
    using CHUSHKA.WEB.Common;
    using CHUSHKA.WEB.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private readonly SignInManager<ChushkaUser> signInManager;
        private readonly UserManager<ChushkaUser> userManager;

        public AccountController(SignInManager<ChushkaUser> signInManager, UserManager<ChushkaUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(GlobalConstants.HomeIndexUrl);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin user)
        {
            var result = await this.signInManager.PasswordSignInAsync(user.Username, 
                user.Password, 
                isPersistent: false, 
                lockoutOnFailure: false);
         
            if (result.Succeeded)
            {
                return this.Redirect(GlobalConstants.HomeIndexUrl);
            }

            return this.View(); 
        }

        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(GlobalConstants.HomeIndexUrl);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister viewModel)
        {
            var user = new ChushkaUser
            {
                UserName = viewModel.Username,
                Email = viewModel.Email,
                FullName = viewModel.FullName
            };

            var result = await this.userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);

                return this.Redirect(GlobalConstants.HomeIndexUrl);
            }

            return this.View();
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.Redirect(GlobalConstants.HomeIndexUrl); 
        }
    }
}