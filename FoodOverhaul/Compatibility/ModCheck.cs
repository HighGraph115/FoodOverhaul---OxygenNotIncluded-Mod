using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOverhaul.Compatibility
{
    internal class ModCheck
    {
        public static bool DupesCuisine_enabled { get; set; }
        static readonly HashSet<string> mod_ids = new HashSet<string>
            {
                "DupesCuisine"
            };
        public static void CheckForMods(IReadOnlyList<KMod.Mod> mods)
        {
            foreach (KMod.Mod mod in (IEnumerable<KMod.Mod>)mods)
            {
                if (mod_ids.Contains(mod.staticID))
                {
                    ModCheck.DupesCuisine_enabled = mod.IsActive();
                }
            }
        }
    }
}
