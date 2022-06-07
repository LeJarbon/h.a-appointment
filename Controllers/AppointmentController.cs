using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ha.appointment.Models.Model;
using Microsoft.AspNetCore.Identity;
using Ha.appointment.Model.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ha.appointment.Models.Model.Context;
using Microsoft.AspNetCore.Authorization;

namespace Ha.appointment.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private UserManager<MyUser> _userManager;
        private HADbContext _db;
        public AppointmentController(UserManager<MyUser> userManager, HADbContext db)
        {
            _userManager = userManager;
            _db = db;   
        }
        // GET: AppointmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AppointmentController/Details/5
  

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(_db.Staff, "ID", "NameSurname");


            return View();
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment model)
        {
            
                if (ModelState.IsValid)
                {

                // For ASP.NET Core <= 3.1
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                model.UserID = Convert.ToInt32(userId);
                _db.Appointment.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");


                }
            return View(model);
            
        }

     

        // GET: AppointmentController/Delete/5
       
    }
}
