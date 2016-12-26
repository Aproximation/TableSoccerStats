using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableSoccerStats.Database.EntityModel;

namespace TableSoccerStats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (var db = new TssDbContext())
            //{
                
            //    var player = new Player {FirstName = "Michał", LastName = "Guzowski", Initials = "MG", Email = "mguzowski@predica.pl", Created = DateTime.Now };
            //    db.Players.Add(player);
            //    db.SaveChanges();

            //    // Display all Blogs from the database 
            //    var query = from p in db.Players
            //                select p;
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}