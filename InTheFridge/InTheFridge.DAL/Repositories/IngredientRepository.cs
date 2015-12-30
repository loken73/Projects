using InTheFridge.DAL.Repositories;
using InTheFridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheFridge.DAL.Data
{
    public class IngredientRepository : RepositoryBase<Ingredient>
    {
        public IngredientRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override IQueryable<object> Search(string a)
        {
            var db = context.Ingredients.OfType<Ingredient>()
                     .Where(x => a == null || x.IngredientName.StartsWith(a))
                     .OrderBy(x => x.IngredientName)
                     .Take(10);
            return db;
        }
    }
}
