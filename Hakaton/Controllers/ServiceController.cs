using Hakaton.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Hakaton.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        // GET: Service
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private static Random random = new Random();
        
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789qwertyuiopasdfghjklzxcvbnm";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public ServiceController()
        {
        }

        public ServiceController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            
            ViewBag.Users = db_a9744d_needfavorEntities.GetContext().ServiceCustomerExecutor;
            return View();
        }
        public ActionResult GetItems(int id)
        {
            return PartialView(db_a9744d_needfavorEntities.GetContext().Service.Where(c => c.CategoryServiceId == id).ToList());
        }

        public ActionResult Details(int id)
        {
            // Use the selected item's ID to retrieve the corresponding object from the database
            // and pass it to the view for display
            var selectedItem = db_a9744d_needfavorEntities.GetContext().Service.Find(id);
            return View(selectedItem);
        }

        [HttpPost]
        public async Task<ActionResult> TakeService(string serviceId)
        {
            int ServiceIdd = Convert.ToInt32(serviceId);
            var userId = User.Identity.GetUserId();
            var roles = await UserManager.GetRolesAsync(userId);
            if (roles[0].ToString() == "Executor")
            {
                var Service = await db_a9744d_needfavorEntities.GetContext().ServiceCustomerExecutor.FirstOrDefaultAsync(u => u.id == ServiceIdd);
                Service.ExecutorId = userId;
                await db_a9744d_needfavorEntities.GetContext().SaveChangesAsync();
                return View();
            }
            return View();
        }
        public async Task<ActionResult> CreateAnnouncement()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAnnouncement(AddServiceCustomerExecutor model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userId = User.Identity.GetUserId();
            var roles = await UserManager.GetRolesAsync(userId);
            
            if (roles[0].ToString() == "Customer")
            {
                ServiceCustomerExecutor newService = new ServiceCustomerExecutor();
                newService.CustomerId = userId;
                newService.Title= model.Title;
                newService.Description= model.Description;
                newService.HaveCostStart = model.HaveCostStart.ToString();
                newService.HaveCost = model.HaveCost.ToString();
                newService.Period= model.Period;
                newService.Position= model.Position;
                db_a9744d_needfavorEntities.GetContext().ServiceCustomerExecutor.Add(newService);
                await db_a9744d_needfavorEntities.GetContext().SaveChangesAsync();
                return RedirectToAction("Index", "Manage");
            }
            return View();

        }
        


    }
}