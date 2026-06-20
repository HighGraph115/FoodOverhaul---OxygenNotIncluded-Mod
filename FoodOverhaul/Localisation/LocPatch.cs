using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOverhaul.Localisation;
using STRINGS;

namespace FoodOverhaul.Localisation
{
    [HarmonyPatch(typeof(Localization), "Initialize")]
    public static class LocPatch
    {
        public static void Postfix()
        {
            //Modifiers

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_ATHLETIC_DIET",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_ATHLETIC_DIET));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_ATHLETIC_DIET2",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_ATHLETIC_DIET2));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_CALMING",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_CALMING));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_AQUATIC",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_AQUATIC));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_FAVORITE",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_FAVORITE));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_NOSTALGIC",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_NOSTALGIC));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_NOCO2",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_NOCO2));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_SPACE",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_SPACE));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_HEALTHY",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_HEALTHY));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_AESTHETIC",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_AESTHETIC));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_DIRTY",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_DIRTY));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_CONSTRUCTIVE",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_CONSTRUCTIVE));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_SWEET",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_SWEET));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_FARMER_FOOD",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_FARMER_FOOD));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_FARMERSDELIGHT",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_FARMERSDELIGHT));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_BULKING",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_BULKING));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_BULKING2",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_BULKING2));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_GREASY",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_GREASY));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_BADFOOD",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_BADFOOD));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_INSPIRING",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_INSPIRING));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_STIMULATED",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_STIMULATED));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_THEBIGONE",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_THEBIGONE));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_REMINISCING",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_REMINISCING));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterMo(
            "FE_REMINISCING2",
            typeof(STRINGS.DUPLICANTS.MODIFIERS.FE_REMINISCING2));


            //Attributes

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterAt(
            "CO2EMISSION",
            typeof(STRINGS.DUPLICANTS.ATTRIBUTES.CO2EMISSION));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterAt(
            "MOVEMENTINCREASE_1",
            typeof(STRINGS.DUPLICANTS.ATTRIBUTES.MOVEMENTINCREASE_1));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterAt(
            "MOVEMENTINCREASE_2",
            typeof(STRINGS.DUPLICANTS.ATTRIBUTES.MOVEMENTINCREASE_2));


            //Traits

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_Burger",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_Burger));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_SpicyTofu",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_SpicyTofu));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_Curry",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_Curry));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_BerryPie",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_BerryPie));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_Quiche",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_Quiche));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_SpiceBread",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_SpiceBread));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_Pancakes",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_Pancakes));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_FriesCarrot",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_FriesCarrot));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_DeepFriedShellfish",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_DeepFriedShellfish));

            FoodOverhaul.Localisation.EffectStringRegistrator.RegisterT(
            "FF_UrchinMeat",
            typeof(STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_UrchinMeat));
        }
    }
}
