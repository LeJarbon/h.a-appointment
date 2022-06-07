using Ha.appointment.Models.Model;
using Ha.appointment.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ha.appointment.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MyUser> _userManager;
        private RoleManager<MyRole> _roleManager;

        private SignInManager<MyUser> _signInManager;
        public AccountController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager, ApplicationDbContext db, SignInManager<MyUser> signInManager)
        {


            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager= signInManager;  


        }

        public IActionResult AddUser()
        {
            
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.EMail, model.Password, model.RememberMe,true);

                if (result.Succeeded)
                {
                    if (returnUrl != null)
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Geçersiz Giriş Denemesi");
                
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(User model)
        {
          
            if (ModelState.IsValid)
            {

                var user = new MyUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email
                };
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, model.Password);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);

                }
                var control = await _roleManager.RoleExistsAsync("Admin");
                if (control != true)
                {
                    // first we create Admin rool    
                    var role = new MyRole();
                    role.Name = "Admin";
                    var addroles = await _roleManager.CreateAsync(role);
                }

       
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }


            }
            return View(model);
        }




    }
}
