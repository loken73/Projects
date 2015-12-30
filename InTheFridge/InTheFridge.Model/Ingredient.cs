using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheFridge.Model
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Display(Name = "Name")]
        public string IngredientName { get; set; }
        public string IngredientDescription { get; set; }

        [Display(Name = "Average amount of Calories")]
        public int IngredientCalories { get; set; }

        [Display(Name = "Ingredient Image")]
        public string IngredientImage { get; set; }

        [Display(Name = "Food Type")]
        public string IngredientType { get; set; }
    }
}
