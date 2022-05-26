using BugTracker.BLL;
using BugTracker.DAL;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly UserBusinessLogicLayer _userBLL;
        private readonly SignInManager<User> _signInManager;

        public UsersController(IRepository<User> userRepository, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userBLL = new UserBusinessLogicLayer(userRepository, roleManager, userManager);
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(string userName, string passwordHash)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            
            if(userName is not null && userName != "")
            {
                user.UserName = userName;
                user.NormalizedUserName = userName.ToUpper();
            }

            if(passwordHash is not null && passwordHash != "")
            {
                var passwordHasher = new PasswordHasher<User>();
                var hashed = passwordHasher.HashPassword(user, passwordHash);
                user.PasswordHash = hashed;
            }
            

            _userBLL.Update(user);
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
