using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOverhaul.Localisation
{
    public static class EffectStringRegistrator
    {
        //Helps register the STRINGS into base game STRINGS MODIFIERS
        public static void RegisterMo(string effectId, Type stringsClass)
        {
            void Add(string suffix, LocString value)
            {
                Strings.Add($"STRINGS.DUPLICANTS.MODIFIERS.{effectId}.{suffix}", value);
            }

            Add("NAME", (LocString)stringsClass.GetField("NAME").GetValue(null));
            Add("TOOLTIP", (LocString)stringsClass.GetField("TOOLTIP").GetValue(null));
            Add("CAUSE", (LocString)stringsClass.GetField("CAUSE").GetValue(null));
            Add("DESCRIPTION", (LocString)stringsClass.GetField("DESCRIPTION").GetValue(null));
        }

        public static void RegisterAt(string effectId, Type stringsClass)
        {
            void Add(string suffix, LocString value)
            {
                Strings.Add($"STRINGS.DUPLICANTS.ATTRIBUTES.{effectId}.{suffix}", value);
            }

            Add("NAME", (LocString)stringsClass.GetField("NAME").GetValue(null));
            Add("DESC", (LocString)stringsClass.GetField("DESC").GetValue(null));
            Add("SPEEDMODIFIER", (LocString)stringsClass.GetField("SPEEDMODIFIER").GetValue(null));
        }
        public static void RegisterT(string traitId, Type stringsClass)
        {
            void Add(string suffix, LocString value)
            {
                Strings.Add($"STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.{traitId}.{suffix}", value);
            }

            Add("NAME", (LocString)stringsClass.GetField("NAME").GetValue(null));
            Add("DESC", (LocString)stringsClass.GetField("DESC").GetValue(null));
        }
    }
}
