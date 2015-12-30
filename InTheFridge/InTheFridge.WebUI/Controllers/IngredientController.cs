using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InTheFridge.Contracts.Repositories;
using InTheFridge.Model;
using InTheFridge.DAL;

namespace InTheFridge.WebUI.Controllers
{
    public class IngredientController : Controller
    {
        IRepositoryBase<Ingredient> ingredients;

        public IngredientController(IRepositoryBase<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        //// GET: Ingredient
        //public ActionResult IngredientList()
        //{
        //    var model = ingredients.GetAll();
        //    return View(model);
        //}

        public ActionResult IngredientList(string a)
        {            
            IQueryable<Ingredient> ingredient = (IQueryable<Ingredient>) ingredients.Search(a);
            return View(ingredient);
        }

        public ActionResult CreateIngredient()
        {
            var model = new Ingredient();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateIngredient(Ingredient ingredient)
        {
            ingredients.Insert(ingredient);
            ingredients.Commit();
            return RedirectToAction("IngredientList");
        }

        public ActionResult EditIngredient(int id)
        {
            Ingredient ingredient = ingredients.GetById(id);
            
            return View(ingredient);
        }

        [HttpPost]
        public ActionResult EditIngredient(Ingredient ingredient)
        {
            ingredients.Update(ingredient);
            ingredients.Commit();

            return RedirectToAction("IngredientList");
        }

        public ActionResult IngredientDetails(int id)
        {
            Ingredient ingredient = ingredients.GetById(id);

            return View(ingredient);
        }

        public ActionResult DeleteIngredient(int id)
        {
            Ingredient ingredient = ingredients.GetById(id);
            return View(ingredient);
        }
    }
}