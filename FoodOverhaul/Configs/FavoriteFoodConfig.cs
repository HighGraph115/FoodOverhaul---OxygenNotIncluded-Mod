using Database;
using Epic.OnlineServices.Lobby;
using HarmonyLib;
using Klei.AI;
using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using static FoodOverhaul.Effects.FEffects;
using static Klei.AI.Traits;
using static MinionResume;
using static TUNING.DUPLICANTSTATS;
using static UnityEngine.GameObject;

namespace FoodOverhaul
{
    public class FavoriteFoodConfig
    {
        public static readonly List<TraitVal> favoriteTrait = new List<TraitVal>
            {
                new TraitVal
                {
                id = "SpicyTofu"
                },
                new TraitVal
                {
                id = "Curry"
                },
                new TraitVal
                {
                id = "Burger"
                },
                new TraitVal
                {
                id = "BerryPie",
                requiredDlcIds = DlcManager.EXPANSION1
                },
                new TraitVal
                {
                id = "Quiche"
                },
                new TraitVal
                {
                id = "SpiceBread"
                },
                new TraitVal
                {
                id = "Pancakes"
                },
                new TraitVal
                {
                id = "FriesCarrot",
                requiredDlcIds = DlcManager.DLC2
                },
                new TraitVal
                {
                id = "DeepFriedShellfish",
                requiredDlcIds = DlcManager.DLC2
                },
                new TraitVal
                {
                id = "UrchinMeat",
                requiredDlcIds = DlcManager.DLC5
                }
            };
        public class FavoriteFoodEffect


        {
            private static Dictionary<int, string> duplicantEffects = new Dictionary<int, string>();

            public static string GetPersonalEffect(GameObject duplicant)
            {
                int instanceId = duplicant.GetInstanceID();

                if (duplicantEffects.TryGetValue(instanceId, out string existingEffectId))
                {
                    return existingEffectId;
                }

                string personalEffectId = Favorite.ID + "_" + instanceId;

                var effectDb = Db.Get().effects;
                var effect = effectDb.TryGet(personalEffectId);

                if (effect == null)
                {
                    effect = new Effect(personalEffectId, "Personal Favorite", Favorite.description, Favorite.Duration, true, true, false);

                    effect.SelfModifiers = new List<AttributeModifier>();

                    MinionResume resume = duplicant.GetComponent<MinionResume>();
                    if (resume != null)
                    {
                        HashSet<string> processedGroups = new HashSet<string>();

                        foreach (var skill in Db.Get().Skills.resources)
                        {
                            //Check if skill is Personal Interest
                            if (resume.HasSkillAptitude(skill))
                            {
                                string skillGroupId = skill.skillGroup;

                                if (!processedGroups.Contains(skillGroupId))
                                {
                                    processedGroups.Add(skillGroupId);
                                    var skillGroup = Db.Get().SkillGroups.Get(skillGroupId);

                                    //Check in case of no Interests
                                    if (skillGroup != null && skillGroup.relevantAttributes != null)
                                    {
                                        foreach (var attribute in skillGroup.relevantAttributes)
                                        {
                                            //no duplicate attributes
                                            if (!effect.SelfModifiers.Contains(new AttributeModifier(attribute.Id, Favorite.x, "Personal Interest")))
                                            {
                                                effect.SelfModifiers.Add(new AttributeModifier(attribute.Id, Favorite.x, "Personal Interest"));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    effectDb.Add(effect);
                }

                duplicantEffects[instanceId] = personalEffectId;
                return personalEffectId;
            }
        }
        public class FavoriteFoodTraitCreator
        {
            public static void TraitCreator()
            {
                // Creates Traits for every id listed in favoriteTrait
                foreach (TraitVal food in favoriteTrait)
                {

                    bool isactive = DlcManager.IsCorrectDlcSubscribed(food);

                    bool allowed = true;

                    //Exclude traits that don't fit active and subscribed Dlc's
                    if (!isactive)
                    {
                        try
                        {
                            allowed = food.requiredDlcIds.Any(id => Game.IsDlcActiveForCurrentSave(id));
                        }
                        catch
                        {
                            allowed = false;
                        }
                    }

                    if (!allowed)
                        continue;

                    string traitid = "FF_" + food.id;

                    //Catch Duplicate creation of Traits, due to Traitcreation per Save Load
                    if (Db.Get().traits.TryGet(traitid) != null)
                        continue;

                    string name = STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_.NAME;
                    string desc = STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_.DESC;
                    string locstringName = $"STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_{food.id}.NAME";
                    string locstringDesc = $"STRINGS.DUPLICANTS.TRAITS.FAVORITEFOOD.FF_{food.id}.DESC";

                    if (Strings.TryGet(locstringName, out var nameentry) && nameentry != null)
                        name = nameentry.String;
                    if (Strings.TryGet(locstringDesc, out var descentry) && descentry != null)
                        desc = descentry.String;
                    // Needs to be properly executed to function
                    var createAction = TraitUtil.CreateNamedTrait(traitid, name, desc);
                    try
                    {
                        createAction(); // Execution
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"[FoodOverhaul] TraitCreator: exception creating '{traitid}': {e.Message}");
                    }
                }
            }
        }
        public class FavoriteFood
        {
            private static readonly System.Random fixedrandom = new System.Random();
            public static List<string> foods = new List<string>
            {
                "SpicyTofu", "Curry", "Burger", "BerryPie", "Quiche", "SpiceBread", "Pancakes", "FriesCarrot", "DeepFriedShellfish", "UrchinMeat"
            };

            private static readonly List<string> foodsactive = new List<string>();

            public static void UpdateFoodlistForCurrentSave()
            {
                foodsactive.Clear();

                foreach (var food in favoriteTrait)
                {

                    if (food.requiredDlcIds == null)
                    {
                        foodsactive.Add(food.id);
                        continue;
                    }

                    bool anyActive = false;
                    foreach (var dlc in food.requiredDlcIds)
                    {
                        if (string.IsNullOrEmpty(dlc) || Game.IsDlcActiveForCurrentSave(dlc))
                        {
                            anyActive = true;
                            break;
                        }
                    }

                    if (anyActive)
                        foodsactive.Add(food.id);
                }

                //Fallback in case of problems, List without Dlc items
                if (foodsactive.Count == 0)
                {
                    foods = new List<string>
                        {
                        "SpicyTofu", "Curry", "Burger", "Quiche", "SpiceBread", "Pancakes"
                        };
                }
                else
                {
                    foods = new List<string>(foodsactive);
                }
            }

            public class FavoriteFoodAssigned : KMonoBehaviour
            {
                //Keep between save and load, foreach loop caused conflict in the simulation
                [Serialize]
                public bool FFTraitAssigned;
            }

            public static string FavoriteFoodSelecter(GameObject duplicant)
            {
                string fav = foods[fixedrandom.Next(0, foods.Count())];
                return fav;
            }

            public static void ApplyRandomTrait(GameObject duplicant)
            {
                var check = duplicant.GetComponent<FavoriteFoodAssigned>();

                if(check == null)
                {
                    check = duplicant.AddComponent<FavoriteFoodAssigned>();
                }

                //checks, if the duplicant had received the trait already
                if(check.FFTraitAssigned)
                {
                    return;
                }

                string fav = FavoriteFoodSelecter(duplicant);
                var trait = Db.Get().traits.TryGet("FF_" + fav);
                //Check if trait creation failed
                if (trait != null)
                {
                    duplicant.GetComponent<Traits>().Add(trait);
                    check.FFTraitAssigned = true;
                }
                else
                {
                    Debug.LogWarning("Couldn't get FF_Trait ID");
                }
            }

            //Patch to make sure the FFTraitAssigned check exists on save/load
            [HarmonyPatch(typeof(MinionConfig), "CreatePrefab")]
            public static class MinionConfig_CreatePrefab_Patch
            {
                static void Postfix(GameObject __result)
                {
                    __result.AddOrGet<FavoriteFoodAssigned>();
                }
            }

            //Applies Random Traits on all spawning Dupes
            [HarmonyPatch(typeof(MinionStartingStats), "ApplyTraits")]
            public static class MinionStartingStats_ApplyTraits_FavoriteFood_Patch
            {
                static void Postfix(MinionStartingStats __instance, GameObject go)
                {
                    try
                    {
                        string foodId = FavoriteFoodTraitPatch.Get(__instance);
                        if (foodId == null) return;

                        var trait = Db.Get().traits.TryGet("FF_" + foodId);
                        if (trait == null) return;

                        var traitsComponent = go.GetComponent<Traits>();
                        if (!traitsComponent.HasTrait(trait.Id))
                        {
                            traitsComponent.Add(trait);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning("[FoodOverhaul] Favorite food transfer failed: " + e.Message);
                    }
                }
            }

            [HarmonyPatch(typeof(Klei.AI.Effects), "Add", new Type[] { typeof(string), typeof(bool) })]
            public class Add_FavoriteEffect_Patch
            {
                public static bool Prefix(Klei.AI.Effects __instance, ref string effect_id, ref bool should_save)
                {
                    if (effect_id == Favorite.ID)
                    {
                        string eatenFoodId = ConsumtionTracker_Patch.currentFoodId; //Gets any currently eaten food
                        Traits traits = __instance.GetComponent<Traits>();

                        // If the food doesn't match the trait or neither are present
                        if (eatenFoodId == null || traits == null || !traits.HasTrait("FF_" + eatenFoodId))
                            return false;

                        effect_id = FavoriteFoodEffect.GetPersonalEffect(__instance.gameObject);
                    }
                    return true;
                }
            }
        }
        public class FavoriteFoodTraitPatch
        {
            //Get/Set for receiving Duplicant stats, adding them to the MinionStartingStats to generate Traits like Stress and Joy response
            private static readonly ConditionalWeakTable<MinionStartingStats, string> tempstats = new ConditionalWeakTable<MinionStartingStats, string>();

            public static void Set(MinionStartingStats stats, string foodid)
            {
                tempstats.Remove(stats);
                tempstats.Add(stats, foodid);
            }

            public static string Get(MinionStartingStats stats)
            {
                tempstats.TryGetValue(stats, out string foodid);
                return foodid;
            }

        }

        [HarmonyPatch (typeof(MinionStartingStats), "GenerateTraits")]
        
        public static class MinionStartingStats_GenerateTraits_FavoriteFoodTraitPatch
        {
            static void Postfix(MinionStartingStats __instance)
            {
                var bionic = __instance.personality.model;
                if (bionic != null && bionic == GameTags.Minions.Models.Bionic)
                {
                    return;
                }

                string fav = FavoriteFood.FavoriteFoodSelecter(null);
                FavoriteFoodTraitPatch.Set(__instance, fav);
            }
        }

        //Patch the available Food list whenever a save file is loaded
        [HarmonyPatch]
        public static class SaveLoader_Load_FavoriteFoodPatch
        {
            //Simply Patching "Load" causes Ambiguity error, manually getting the proper method
            //TargetMethod gets called, when Harmony doesnt find a method to patch
            static MethodBase TargetMethod()
            {
                var allbinding = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
                //Skim for Load methods
                var method = typeof(SaveLoader).GetMethods(allbinding).Where(x => x.Name == "Load").ToArray();

                //Makes sure to filter for exactly Load(string)
                var stringsearch = method.FirstOrDefault(x =>
                {
                    var parameter = x.GetParameters();
                    return parameter.Length == 1 && parameter[0].ParameterType == typeof(string);
                });
                if (stringsearch != null)
                    return stringsearch;

                //Fallback 1: Go for Load() instead. This shouldn't happen unless SaveLoader gets deprecated
                var noparameter = method.FirstOrDefault(m => m.GetParameters().Length == 0);
                if (noparameter != null)
                    return noparameter;

                //Fallback 2: This really shouldn't happen, but just in case grab FirstorDefault
                return method.FirstOrDefault();
            }
            public static void Postfix()
            {
                try
                {
                    //Create Traits that may be missing due to new Dlc
                    FavoriteFoodTraitCreator.TraitCreator();

                    // Create new List whenever any new SaveFile is loaded
                    FavoriteFoodConfig.FavoriteFood.UpdateFoodlistForCurrentSave();
                    Debug.Log("[FoodOverhaul] Updated favorite foods for current save.");
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning("[FoodOverhaul] Failed to update foods, fallback to Vanilla mode: " + e.Message);
                }
            }
        }
    }
}

