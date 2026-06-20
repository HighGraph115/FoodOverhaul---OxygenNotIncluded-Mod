using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static FoodOverhaul.FavoriteFoodConfig.FavoriteFood;

namespace FoodOverhaul
{
    public class FoodEffects
    {
        public List<string> Effects;

        public FoodEffects()
        {
            Effects = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="duration"></param>
        /// <param name="description"></param>
        /// <param name="foods"></param>
        public FoodEffects(string id, float x, float duration, string description, List<string> foods) : this()
        {
        }

        /// <summary>
        /// Add effects to the food items specified
        /// </summary>
        /// <param name="foods">List of food item IDs</param>
        /// <param name="effects">List of effect IDs</param>
        public static void SetFoodEffects(List<string> foods, List<string> effects)
        {
            var foodType = typeof(TUNING.FOOD.FOOD_TYPES);
            var fields = foodType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var f in fields)
            {
                if (f.FieldType != typeof(EdiblesManager.FoodInfo))
                {
                    continue;
                }

                var foodInfo = (EdiblesManager.FoodInfo)f.GetValue(null);
                if (foodInfo == null)
                {
                    continue;
                }

                if (!foods.Contains(foodInfo.Id))
                {
                    continue;
                }

                // new  List if none exists
                if (foodInfo.Effects == null)
                {
                    foodInfo.Effects = new List<string>();
                }
                else
                {
                    // Add basegame food effects here, if new ones are added
                    var oEffects = new List<string>
                        {
                            "SeafoodRadiationResistance",
                            "WarmTouchFood",
                            "GoodEats",
                            "Thirsty"
                        };

                    // Remove all old Effects from Food
                    if (foodInfo.Effects.Any(e => oEffects.Contains(e)))
                    {
                        foodInfo.Effects.RemoveAll(e => oEffects.Contains(e));
                    }
                }

                // Add new effects without duplicates
                foreach (var y in effects)
                {
                    if (!foodInfo.Effects.Contains(y))
                    {
                        foodInfo.Effects.Add(y);
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(Edible), "StopConsuming")]
    public static class ConsumtionTracker_Patch
    {
        // Track the StopConsuming() food item
        public static string currentFoodId;

        static void Prefix(Edible __instance)
        {
            currentFoodId = __instance.FoodID; // creates instance for Add_FavoriteEffect_Patch
        }

        static void Postfix()
        {
            currentFoodId = null; // clear
        }
    }
}
