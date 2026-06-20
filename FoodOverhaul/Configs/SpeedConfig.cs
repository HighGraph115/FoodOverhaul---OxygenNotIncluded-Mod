using HarmonyLib;
using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static FoodOverhaul.Configs.NoCO2Config;
using static FoodOverhaul.Effects.FEffects;

namespace FoodOverhaul.Configs
{
    public class SpeedBoostConfig
    {
        public class SpeedBoostState : KMonoBehaviour
        {
            public bool initialized;
        }

        [HarmonyPatch(typeof(BipedTransitionLayer), "BeginTransition")]
        public static class SpeedBoost_BipedTransition_Patch1
        {
            static void Postfix(
                Navigator navigator,
                Navigator.ActiveTransition transition)
            {

                var effects = navigator.GetComponent<Klei.AI.Effects>();
                if (effects != null && effects.HasEffect(Athletic_Diet.ID))
                {
                    transition.speed *= Athletic_Diet.Runspd_increase;
                    transition.animSpeed *= Athletic_Diet.Runspd_increase;
                }

                if (effects != null && effects.HasEffect(Athletic_Diet2.ID))
                {
                    transition.speed *= Athletic_Diet2.Runspd_increase;
                    transition.animSpeed *= Athletic_Diet2.Runspd_increase;
                }
            }
        }
    }
}
