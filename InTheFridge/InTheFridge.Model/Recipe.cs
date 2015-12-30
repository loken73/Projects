using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheFridge.Model
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Display(Name ="Name")]
        public string RecipeName { get; set; }

        [Display(Name = "Description")]
        public string RecipeDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string Directions { get; set; }

        [Display(Name = "When is it best to eat?")]
        public string Meal { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(150)]
        public string RecipeImage { get; set; }

        [Display(Name = "Ingredients")]
        [DataType(DataType.MultilineText)]
        public string RecipeIngredients { get; set; }
    }
}
