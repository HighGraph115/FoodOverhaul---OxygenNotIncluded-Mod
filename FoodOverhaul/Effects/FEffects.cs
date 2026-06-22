using JetBrains.Annotations;
using Klei.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using static FoodOverhaul.FoodEffectsPatches;
using static FoodOverhaul.STRINGS.DUPLICANTS.ATTRIBUTES;
using static Klei.AI.Attribute;
using static KSelectable;
using static OxygenBreather;
using static STRINGS.DUPLICANTS.ATTRIBUTES;
using static STRINGS.ITEMS.FOOD;
using static TUNING.DUPLICANTSTATS;

namespace FoodOverhaul.Effects
{
    public class FEffects
    {
        public FEffects() 
        {
            new Athletic_Diet();
            new Athletic_Diet2();
            new Calming();
            new Aquatic();
            new Favorite();
            new Nostalgic();
            new NoCO2();
            new Space();
            new Healthy();
            new Aesthetic();
            new Earth();
            new Constructive();
            new Farmer_Food();
            new FarmersDelight();
            new Sweet();
            new Reminiscing();
            new Reminiscing2();
            new Bulking();
            new Bulking2();
            new Greasy();
            new BadFood();
            new Inspiring();
            new Stimulated();
            new TheBigOne();
        }
        /*
         * Blueprint: Basic Structure for creating any effect for any food Item and apply basic changes to attributes
         * 
        public class Effect_Sample : FoodEffects
        {
            public const string ID = "FE_Effect_Sample";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "";
            public static readonly List<string> food = new List<string> { "FieldRation" };

            public Effect_Sample() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);
                
                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "NAME", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Athletics.Id, x, "NAME"));
                SetFoodEffects(food, effects);
            }
        }
        */
        public class Athletic_Diet : FoodEffects
        {
            public const string ID = "FE_Athletic_Diet";
            public const float Runspd_increase = 1.20f;
            public const float Duration = 600f;
            public const string description = "Increased total Speed: 20% Runspeed";
            public static readonly List<string> food = new List<string> { "RawEgg", "Tofu", "SmokedDinosaurMeat", "PlantMeat", "Nigiri" };

            public Athletic_Diet() : base(
                ID,
                Runspd_increase,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                if (effect == null)
                {
                    effect = new Effect(ID, "Athletic Diet", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                    // Add a modifier 
                //effect.SelfModifiers.Add(new AttributeModifier("MOVEMENTINCREASE_1", Runspd_increase, "Athletic Diet"));
                SetFoodEffects(food, effects);
            }
        }
        public class Athletic_Diet2 : FoodEffects
        {
            public const string ID = "FE_ATHLETIC_DIET2";
            public const float Runspd_increase = 1.4f;
            public const float Duration = 600f;
            public const string description = "Increased total Speed: 40% Runspeed";
            public static readonly List<string> food = new List<string> { "SpicyTofu", "Curry", "SurfAndTurf", "DeepFriedShellfish" };

            public Athletic_Diet2() : base(
                ID,
                Runspd_increase,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                if (effect == null)
                {
                    effect = new Effect(ID, "ATHLETIC DIET!", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier
                //effect.SelfModifiers.Add(new AttributeModifier("MOVEMENTINCREASE_2", Runspd_increase, "ATHLETIC DIET!", false, false, true ));
                SetFoodEffects(food, effects);
            }
           
        }
        public class Calming : FoodEffects
        {
            public const string ID = "FE_CALMING";
            public const float x = 5f;
            public const float Duration = 600f;
            public const string description = "This Duplicant feels at ease";
            public static readonly List<string> food = new List<string> { "Edamame" };

            public Calming() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Calm", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier("StressDelta", -5f / 600f, "Calm"));
                SetFoodEffects(food, effects);
            }
        }
        public class Aquatic : FoodEffects
        {
            public const string ID = "FE_Aquatic";
            public const float x = 50f;
            public const float Duration = 600f;
            public const string description = "This Duplicant feels like a fish";
            public static readonly List<string> food = new List<string> { "Nigiri", "Maki", "UrchinMeat" };

            public Aquatic() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Deeper breaths", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                var breathid = Db.Get().Amounts.Breath.maxAttribute.Id;
                effect.SelfModifiers.Add(new AttributeModifier(breathid, x, "Bigger Breaths"));
                SetFoodEffects(food, effects);
            }
        }
        public class Favorite : FoodEffects
        {
            public const string ID = "FE_FAVORITE";
            public const float x = 3f;
            public const float Duration = 600f;
            public const string description = "This Duplicants favorite Snack!";
            public static readonly List<string> food = new List<string>
            {
                "SpicyTofu", "Curry", "Burger", "BerryPie", "Quiche", "SpiceBread", "Pancakes", "FriesCarrot", "DeepFriedShellfish", "UrchinMeat"
            };

            public Favorite() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Personal Favorite", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }

                // Add a modifier here
                SetFoodEffects(food, effects);
            }
        }
        public class Nostalgic : FoodEffects
        {
            public const string ID = "FE_NOSTALGIC";
            public const float home = 3f;
            public const float Duration = 600f;
            public const string description = "It is unclear why, but something about it reminds Duplicants of home";
            public static readonly List<string> food = new List<string> { "CookedEgg", "Pancakes", "CookedPikeapple" };

            public Nostalgic() : base(
                    ID,
                    home,
                    Duration,
                    description,
                    food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Old Classic", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Ranching.Id, home, "Old Classic"));
                SetFoodEffects(food, effects);
            }
        }
        public class NoCO2 : FoodEffects
        {
            public const string ID = "FE_NOCO2"; 
            public const float CO2 = 0f; 
            public const float Duration = 600f;
            public const string description = "Reduces CO2 Emission to 0!";
            public static readonly List<string> food = new List<string> { "FieldRation", "BasicForagePlant", "ForestForagePlant", "SwampForagePlant", "IceCavesForagePlant", "GardenForagePlant", "MusselTongue" };

            public NoCO2() : base(
                ID,
                CO2,
                Duration,
                description, 
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Clean Breathing", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }

                //effect.SelfModifiers.Add(new AttributeModifier("CO2Emission", CO2, "Reduces CO2 Emission to 0!"));

                SetFoodEffects(food, effects);
            }
        }
        public class Space : FoodEffects
        {
            public const string ID = "FE_SPACE";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "Perfect food for intergalactic travel";
            public static readonly List<string> food = new List<string> { "Pemmican", "FruitCake" };

            public Space() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Astronaut Food", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.SpaceNavigation.Id, x, "Astronaut Food"));
                SetFoodEffects(food, effects);
            }
        }
        public class Healthy : FoodEffects
        {
            public const string ID = "FE_HEALTHY";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "This Duplicant wants to stay away from the Sick Bay";
            public static readonly List<string> food = new List<string> { "GrilledPrickleFruit", "PlantMeat", "Edamame", "Maki" };

            public Healthy() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Healthy Taste", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Caring.Id, x, "Healthy Taste"));
                effect.SelfModifiers.Add(new AttributeModifier("HitPointsDelta", 1f / 60f, "Healthy Taste"));
                SetFoodEffects(food, effects);
            }
        }
        public class Aesthetic : FoodEffects
        {
            public const string ID = "FE_AESTHETIC";
            public const float x = 3f;
            public const float Duration = 600f;
            public const string description = "Sometimes it is not just about the Taste";
            public static readonly List<string> food = new List<string> { "ColdWheatBread", "SpiceBread" };

            public Aesthetic() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Aestheticly pleasing", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Art.Id, x, "Aestheticly pleasing"));
                SetFoodEffects(food, effects);
            }
        }
        public class Earth : FoodEffects
        {
            public const string ID = "FE_DIRTY";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "This Duplicant is sure that their food was still moving!";
            public static readonly List<string> food = new List<string> { "BasicPlantBar", "PickledMeal" };

            public Earth() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Dirty Taste", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Digging.Id, x, "Dirty Taste"));
                SetFoodEffects(food, effects);
            }
        }
        public class Constructive : FoodEffects
        {
            public const string ID = "FE_CONSTRUCTIVE";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "This Duplicant appreciates their food tough and robust";
            public static readonly List<string> food = new List<string> { "WormBasicFood" };

            public Constructive() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Tough Taste", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Construction.Id, x, "Tough Taste"));
                SetFoodEffects(food, effects);
            }
        }
        public class Sweet : FoodEffects
            {
                public const string ID = "FE_SWEET";
                public const float x = 2f;
                public const float Duration = 600f;
                public const string description = "The Sweet taste makes this Duplicant jumpy";
                public static readonly List<string> food = new List<string> { "WormSuperFruit", "WormSuperFood", "BerryPie", "Pancakes", "SwampDelights", "Nigiri" };

                public Sweet() : base(
                    ID,
                    x,
                    Duration,
                    description,
                    food)
                {
                    List<string> effects = new List<string> { ID };

                    var attributes = Db.Get().Attributes;

                    var effectDb = Db.Get().effects;

                    var effect = effectDb.TryGet(ID);

                    // Creates new Effect
                    if (effect == null)
                    {
                        effect = new Effect(ID, "Sugar Rush!", description, Duration, true, true, false);
                        effectDb.Add(effect);
                    }

                    // Creates new SelfModifier
                    if (effect.SelfModifiers == null)
                    {
                        effect.SelfModifiers = new List<AttributeModifier>();
                    }
                    // Add a modifier here
                    effect.SelfModifiers.Add(new AttributeModifier(attributes.Athletics.Id, x, "Sugar Rush!"));
                    SetFoodEffects(food, effects);
                }
            }
        public class Farmer_Food : FoodEffects
            {
                public const string ID = "FE_FARMER_FOOD";
                public const float x = 2;
                public const float Duration = 600f;
                public const string description = "This Duplicant is in touch with Nature!";
                public static readonly List<string> food = new List<string> { "FriedMushroom", "Lettuce", "ColdWheatBread", "SmokedVegetables" };

                public Farmer_Food() : base(
                    ID,
                    x,
                    Duration,
                    description,
                    food)
                {
                    List<string> effects = new List<string> { ID };

                    var attributes = Db.Get().Attributes;

                    var effectDb = Db.Get().effects;

                    var effect = effectDb.TryGet(ID);

                    // Creates new Effect
                    if (effect == null)
                    {
                        effect = new Effect(ID, "Farmer's Food", description, Duration, true, true, false);
                        effectDb.Add(effect);
                    }

                    // Creates new SelfModifier
                    if (effect.SelfModifiers == null)
                    {
                        effect.SelfModifiers = new List<AttributeModifier>();
                    }
                    // Add a modifier here
                    effect.SelfModifiers.Add(new AttributeModifier(attributes.Botanist.Id, x, "Farmer's Food"));
                    effect.SelfModifiers.Add(new AttributeModifier(attributes.Ranching.Id, x, "Farmer's Food"));
                    SetFoodEffects(food, effects);
                }
            }
        public class FarmersDelight : FoodEffects
        {
            public const string ID = "FE_FARMERSDELIGHT";
            public const float x = 5;
            public const float Duration = 600f;
            public const string description = "This Duplicant is in touch with Nature!";
            public static readonly List<string> food = new List<string> { "MushroomWrap", "Quiche" };

            public FarmersDelight() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Taste of Freedom", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Botanist.Id, x, "Farmer's Food"));
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Ranching.Id, x, "Farmer's Food"));
                SetFoodEffects(food, effects);
            }
        }
        public class Reminiscing : FoodEffects
        {
            public const string ID = "FE_REMINISCING";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "Increases Science by 2";
            public static readonly List<string> food = new List<string> { "CookedFish", "Lettuce", "DeepFriedFish", "Quiche" };

            public Reminiscing() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Thoughtful", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Learning.Id, x, "Brain Food"));
                SetFoodEffects(food, effects);
            }
        }
        public class Reminiscing2 : FoodEffects
        {
            public const string ID = "FE_REMINISCING2";
            public const float x = 4f;
            public const float Duration = 600f;
            public const string description = "Increases Science by 4";
            public static readonly List<string> food = new List<string> { "BerryPie", "Salsa", "SurfAndTurf", "DeepFriedShellfish" };

            public Reminiscing2() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Thoughtful", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Learning.Id, x, "Brain Power"));
                SetFoodEffects(food, effects);
            }
        }
        public class Bulking : FoodEffects
        {
            public const string ID = "FE_BULKING";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "It takes a certain type of Duplicant to eat this";
            public static readonly List<string> food = new List<string> { "CookedPikeapple" };

            public Bulking() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Rough Taste", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Strength.Id, x, "Rough Taste"));
                SetFoodEffects(food, effects);
            }
        }
        public class Bulking2 : FoodEffects
        {
            public const string ID = "FE_BULKING2";
            public const float x = 5f;
            public const float Duration = 600f;
            public const string description = "This Duplicant could lift a shovevole with one hand!";
            public static readonly List<string> food = new List<string> { "SpicyTofu", "SpiceBread" };

            public Bulking2() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Powerful", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Strength.Id, x, "Powerful"));
                SetFoodEffects(food, effects);
            }
        }
        public class Greasy : FoodEffects
        {
            public const string ID = "FE_GREASY";
            public const float x = 3f;
            public const float Duration = 600f;
            public const string description = "The oily Taste of Industry";
            public static readonly List<string> food = new List<string> { "FriesCarrot", "DeepFriedNosh", "SmokedFish", "DeepFriedFish" };

            public Greasy() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Oily", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Machinery.Id, x, "Oily"));
                SetFoodEffects(food, effects);
            }
        }
        public class BadFood : FoodEffects
        {
            public const string ID = "FE_BADFOOD";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "This Duplicant wants to eat anything else";
            public static readonly List<string> food = new List<string> { "MushBar", "FriedMushBar" };

            public BadFood() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Bad Taste", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Cooking.Id, x, "Bad Taste"));
                SetFoodEffects(food, effects);
            }
        }
        public class Inspiring : FoodEffects
        {
            public const string ID = "FE_INSPIRING";
            public const float x = 3f;
            public const float Duration = 600f;
            public const string description = "This Duplicant wants to reshape the whole Planetoid";
            public static readonly List<string> food = new List<string> { "SpiceBread" };

            public Inspiring() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Inspired", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Construction.Id, x, "Inspired"));
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Digging.Id, x, "Inspired"));
                SetFoodEffects(food, effects);
            }
        }
        public class Stimulated : FoodEffects
        {
            public const string ID = "FE_STIMULATED";
            public const float x = 3f;
            public const float Duration = 600f;
            public const string description = "This Duplicant is giving it their all";
            public static readonly List<string> food = new List<string> { "Salsa" };

            public Stimulated() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "Stimulated", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Machinery.Id, x, "Stimulated"));
                effect.SelfModifiers.Add(new AttributeModifier(attributes.Cooking.Id, x, "Stimulated"));
                SetFoodEffects(food, effects);
            }
        }
        public class TheBigOne : FoodEffects
        {
            public const string ID = "FE_THEBIGONE";
            public const float x = 2f;
            public const float Duration = 600f;
            public const string description = "Nutritional overdrive";
            public static readonly List<string> food = new List<string> { "Burger" };

            public TheBigOne() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "True Delicacy", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                effect.SelfModifiers = AllAttributesUp(x);
                SetFoodEffects(food, effects);
            }
        }
        public class Range : FoodEffects
        {
            public const string ID = "FE_Effect_Sample";
            public const float x = 1;
            public const float Duration = 600f;
            public const string description = "";
            public static readonly List<string> food = new List<string> { "FieldRation" };

            public Range() : base(
                ID,
                x,
                Duration,
                description,
                food)
            {
                List<string> effects = new List<string> { ID };

                var attributes = Db.Get().Attributes;

                var effectDb = Db.Get().effects;

                var effect = effectDb.TryGet(ID);

                // Creates new Effect
                if (effect == null)
                {
                    effect = new Effect(ID, "more Range", description, Duration, true, true, false);
                    effectDb.Add(effect);
                }

                // Creates new SelfModifier
                if (effect.SelfModifiers == null)
                {
                    effect.SelfModifiers = new List<AttributeModifier>();
                }
                // Add a modifier here
                //effect.SelfModifiers.Add(new AttributeModifier(attributes.Athletics.Id, 2f, "more Range"));
                SetFoodEffects(food, effects);
            }
        }   //WIP

        public static List<AttributeModifier> AllAttributesUp(float increase)
        {

            var attributes = Db.Get().Attributes;
            List<AttributeModifier> AllAttributes = new List<AttributeModifier>();
            List<string> MainAttributes = new List<string>
            {
                attributes.Athletics.Id, 
                attributes.Construction.Id,
                attributes.Digging.Id,
                attributes.Machinery.Id,
                attributes.Learning.Id,
                attributes.Cooking.Id,
                attributes.Caring.Id,
                attributes.Strength.Id,
                attributes.Art.Id,
                attributes.Botanist.Id,
                attributes.Ranching.Id,
                attributes.SpaceNavigation.Id
            };

            foreach (var y in MainAttributes)
            {
                AllAttributes.Add(new AttributeModifier(y, increase, "The Big One"));
            }
            return AllAttributes;
        }
    }
}
