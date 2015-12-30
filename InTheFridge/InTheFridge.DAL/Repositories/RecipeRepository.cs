using InTheFridge.DAL.Data;
using InTheFridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace InTheFridge.DAL.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>
    {
        public RecipeRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override IQueryable<object> Search(string a)
        {
            var db = context.Recipes.OfType<Recipe>()
                     .Where(x => a == null || x.RecipeIngredients.Contains(a))
                     .OrderBy(x => x.RecipeName)
                     .Take(10);
            return db;
        }
    }
}
