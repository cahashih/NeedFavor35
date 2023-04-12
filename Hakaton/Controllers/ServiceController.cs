using Hakaton.Models;
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
    public class ServiceController : Controller
    {
        // GET: Service
        
        /*
        public ActionResult Details(int id)
        {
            // Use the selected item's ID to retrieve the corresponding object from the database
            // and pass it to the view for display
            var selectedItem = db_a9744d_needfavorEntities.GetContext().Service.Where(u=>u.CategoryServiceId == id);
            return View(selectedItem);
        }
        */
        public ActionResult Index()
        {
            
            int selectedIndex = 1;
            SelectList states = new SelectList(db_a9744d_needfavorEntities.GetContext().CategoryService, "CategoryServiceId", "Name", selectedIndex);
            ViewBag.States = states;
            SelectList cities = new SelectList(db_a9744d_needfavorEntities.GetContext().Service.Where(c => c.CategoryServiceId == selectedIndex), "ServiceId", "Name");
            ViewBag.Cities = cities;
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
        
    }
}