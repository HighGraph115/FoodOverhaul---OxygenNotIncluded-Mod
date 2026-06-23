using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOverhaul.Compatibility
{
    internal class DupesCuisine
    {
        private static bool Init()
        {
            var check = Type.GetType("DupesCuisine.Foods, DupesCuisine");
            if (check != null)
            {
                return false;
            }
            return true;

            //Get
        }
    }
}
