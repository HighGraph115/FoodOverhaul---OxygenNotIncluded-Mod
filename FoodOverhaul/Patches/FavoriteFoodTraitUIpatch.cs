using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Klei.AI;

namespace FoodOverhaul.Patches
{
    public class FavoriteFoodTraitUIpatch
    {
        [HarmonyPatch(typeof(CharacterContainer), "SetInfoText")]

        public static class CharacterContainer_SetInfoText_FavoriteFoodTraitPatch
        {
            static void Postfix(CharacterContainer __instance)
            {

                //Get Required Character Container information from a given Instance
                var trav = Traverse.Create(__instance);
                var stats = trav.Field("stats").GetValue<MinionStartingStats>();
                var expectationRight = trav.Field("expectationRight").GetValue<LocText>();
                var expectationLabels = trav.Field("expectationLabels").GetValue<List<LocText>>();

                string fav = FavoriteFoodConfig.FavoriteFoodTraitPatch.Get(stats);
                // Check if Trait exists or needs to be created
                Trait favT = fav != null ? Db.Get().traits.TryGet("FF_" + fav) : null;

                if (favT != null)
                {
                    bool alreadyShowing = expectationLabels != null &&
                        expectationLabels.Any(l => l != null && !string.IsNullOrEmpty(l.text) && l.text.Contains(favT.GetName()));

                    if (!alreadyShowing)
                    {
                        LocText newLabel = Util.KInstantiateUI<LocText>(
                            expectationRight.gameObject,
                            expectationRight.transform.parent.gameObject,
                            force_active: false);
                        newLabel.gameObject.SetActive(true);
                        newLabel.text = string.Format(" {0}", favT.GetName());
                        newLabel.GetComponent<ToolTip>().SetSimpleTooltip(favT.GetTooltip());
                        expectationLabels.Add(newLabel);
                    }
                }
            }
        }
    }
}
