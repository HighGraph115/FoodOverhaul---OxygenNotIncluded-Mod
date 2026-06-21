using FoodOverhaul.Effects;
using HarmonyLib;
using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static EdiblesManager;
using static LogicGate.LogicGateDescriptions;

using static TUNING.FOOD;

namespace FoodOverhaul
{
    public class FoodEffectsPatches
    {
        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class Db_Initialize_Patch
        {
            public static void Prefix()
            {

            }

            public static void Postfix()
            {
                Debug.Log("[FoodOverhaul] starting mod init");
                try
                {
                    // Initializes Favorite Food Traits
                    FavoriteFoodConfig.FavoriteFoodTraitCreator.TraitCreator();

                    new FEffects();

                    Debug.Log("[FoodOverhaul] SetFoodEffects completed");
                    //Reach.ReachPatch.ExpandTables(3, 3);
                    //Debug.Log("[FoodOverhaul] Reach.ExpandTables called");

                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}
