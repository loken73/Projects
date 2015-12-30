using InTheFridge.Contracts.Repositories;
using InTheFridge.DAL.Data;
using InTheFridge.DAL.Repositories;
using InTheFridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InTheFridge.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //IRepositoryBase<Recipe> recipes;
        //IRepositoryBase<Ingredient> ingredients;

        //public HomeController(IRepositoryBase<Recipe> recipes)
        //{
        //    this.recipes = recipes;
        //}

        public ActionResult Index()
        {
            
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