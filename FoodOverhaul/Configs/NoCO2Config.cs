using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static FoodOverhaul.Effects.FEffects;

namespace FoodOverhaul.Configs
{
    public class NoCO2Config
    {
        public class NoCO2State : KMonoBehaviour
        {
            //remember original values
            public float originalMinCO2 = 0.3f;
            public float originalO2toCO2 = 0.5f;
            public bool initialized;
        }

        //[HarmonyPatch(typeof(Klei.AI.Effects), "Add", new Type[] { typeof(string), typeof(bool) })] Possible better patch structure?
        [HarmonyPatch(typeof(OxygenBreather), "Sim200ms")]
        public static class NoCO2_OxygenBreather_Patch
        {
            static void Prefix(OxygenBreather __instance)
            {
                //Create Instances
                var effects = __instance.GetComponent<Klei.AI.Effects>();
                var state = __instance.GetComponent<NoCO2State>();

                if (state == null)
                    state = __instance.gameObject.AddComponent<NoCO2State>();

                bool hasEffect = effects != null && effects.HasEffect(NoCO2.ID);

                //Check for Effect
                if (hasEffect)
                {
                    if (!state.initialized)
                    {
                        /*
                        * Use for dynamicly changing values
                        state.originalMinCO2 = __instance.minCO2ToEmit;
                        state.originalO2toCO2 = __instance.O2toCO2conversion;
                        */
                        state.initialized = true;
                    }

                    //Change the defaults during Effect
                    __instance.O2toCO2conversion = 0f;
                    __instance.minCO2ToEmit = float.MaxValue;
                    __instance.accumulatedCO2 = 0f;
                }
                else if (state.initialized)
                {
                    // Restore defaults
                    __instance.minCO2ToEmit = state.originalMinCO2;
                    __instance.O2toCO2conversion = state.originalO2toCO2;
                    state.initialized = false;
                }
            }
        }
    }
}
