using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InTheFridge.Model;
using InTheFridge.DAL;
using InTheFridge.Contracts.Repositories;

namespace InTheFridge.WebUI.Controllers
{
    public class RecipeController : Controller
    {
        IRepositoryBase<Recipe> recipes;

        public RecipeController(IRepositoryBase<Recipe> recipes)
        {
            this.recipes = recipes;
        }
        
        // GET: Recipe
        //public ActionResult Index()
        //{
        //    var model = recipes.GetAll();
        //    return View(model);
        //}

        public ActionResult RecipeIndex(string a)
        {
            IQueryable<Recipe> ingredient = (IQueryable<Recipe>)recipes.Search(a);
            return View(ingredient);
        }

        public ActionResult CreateRecipe()
        {
            List<SelectListItem> mealtimes = new List<SelectListItem>();

            mealtimes.Add(new SelectListItem { Text = "Breakfast", Value = "0" });

            mealtimes.Add(new SelectListItem { Text = "Brunch", Value = "1" });

            mealtimes.Add(new SelectListItem { Text = "Lunch", Value = "2" });

            mealtimes.Add(new SelectListItem { Text = "Dinner", Value = "3" });

            mealtimes.Add(new SelectListItem { Text = "Dessert", Value = "4" });

            ViewBag.Meal = mealtimes;

            var model = new Recipe();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateRecipe(Recipe recipe)
        {
            recipes.Insert(recipe);
            recipes.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult EditRecipe(int id)
        {
            Recipe recipe = recipes.GetById(id);

            return View(recipe);
        }

        [HttpPost]
        public ActionResult EditRecipe(Recipe recipe)
        {
            recipes.Update(recipe);
            recipes.Commit();
            return RedirectToAction("RecipeIndex");
        }

        public ActionResult RecipeDetails(int id)
        {
            var recipe = recipes.GetById(id);

            return View(recipe);
        }

        //public ActionResult Delete(int id)
        //{
        //    Recipe recipe = recipes.GetById(id);
        //    return View(recipe);
        //}

        //[HttpPost]
        //public ActionResult DeletedConfirmed(Recipe recipe)
        //{
        //    recipes.Delete(recipe);
        //    recipes.Commit();
        //    return RedirectToAction("Index");                                        
        //}
    }
}