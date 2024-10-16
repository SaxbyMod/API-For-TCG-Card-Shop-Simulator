using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TCGShopNewCardsModPreloader.Handlers;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Scripts
{
    internal class CardHandler
    {
        // Dictionary to store cards grouped by CardSet
        private static Dictionary<string, List<MonsterData>> cardSets = new Dictionary<string, List<MonsterData>>();

        // Method to add a new card and store it under the specified CardSet
        public static MonsterData AddNewCard(string CardSet, string ModPrefix, string CardName, string Artist, string Description, UnityEngine.Vector3 effectAmount, EElementIndex element, EMonsterType nextEvolution, EMonsterType previousEvolution, ERarity rarity, List<string> role, Stats stats, List<string> Skills, string ImagePath)
        {
            MonsterData newCard = CreateCard(CardSet, ModPrefix, CardName, Artist, Description, effectAmount, element, nextEvolution, previousEvolution, rarity, role, stats, Skills, ImagePath);

            // Store the card in the dictionary based on its CardSet
            if (!cardSets.ContainsKey(CardSet))
            {
                cardSets[CardSet] = new List<MonsterData>();
            }
            cardSets[CardSet].Add(newCard);

            return newCard;
        }

        // Helper method to create a new card (similar to the existing AddNewCard method)
        private static MonsterData CreateCard(string CardSet, string ModPrefix, string CardName, string Artist, string Description, UnityEngine.Vector3 effectAmount, EElementIndex element, EMonsterType nextEvolution, EMonsterType previousEvolution, ERarity rarity, List<string> role, Stats stats, List<string> Skills, string ImagePath)
        {
            // (existing code for creating MonsterData remains here)

            EMonsterType monsterType = (EMonsterType)Enum.Parse(typeof(EMonsterType), ModPrefix + "_" + CardName);

            var convertedRoles = role.Select(r =>
            {
                if (Enum.TryParse(typeof(EMonsterRole), r, out var parsedEnum))
                {
                    return (EMonsterRole)parsedEnum;
                }
                else
                {
                    throw new ArgumentException($"Role '{r}' is not a valid EMonsterRole");
                }
            }).ToList();

            var convertedSkills = Skills.Select(s =>
            {
                if (Enum.TryParse(typeof(ESkill), s, out var parsedSkill))
                {
                    return (ESkill)parsedSkill;
                }
                else
                {
                    Console.WriteLine($"Warning: Skill '{s}' could not be parsed to ESkill");
                    return ESkill.None;
                }
            }).ToList();

            return new MonsterData
            {
                Name = CardName,
                ArtistName = Artist,
                Description = Description,
                EffectAmount = effectAmount,
                ElementIndex = element,
                MonsterType = monsterType,
                NextEvolution = nextEvolution,
                PreviousEvolution = previousEvolution,
                Rarity = rarity,
                Roles = convertedRoles,
                BaseStats = stats,
                SkillList = convertedSkills,
                GhostIcon = ImageLoader.GetCustomImage(ModPrefix + "_" + CardName + "_Ghost", ImagePath),
                Icon = ImageLoader.GetCustomImage(ModPrefix + "_" + CardName, ImagePath)
            };
        }

        // Method to retrieve all cards from a specific CardSet
        public static List<MonsterData> GetCardsBySet(string CardSet)
        {
            if (cardSets.ContainsKey(CardSet))
            {
                return cardSets[CardSet];
            }
            else
            {
                return new List<MonsterData>(); // Return empty list if CardSet does not exist
            }
        }

        // Method to retrieve all CardSets
        public static Dictionary<string, List<MonsterData>> GetAllCardSets()
        {
            return cardSets;
        }



        public class CardDataConverter
        {
            // Method to convert all cards in a CardSet to a list of dictionaries
            public static List<Dictionary<string, object>> ConvertCardSetToDictList(string CardSet)
            {
                var cards = CardHandler.GetCardsBySet(CardSet);
                return cards.Select(ConvertToDict).ToList();
            }

            public static (List<Dictionary<string, object>> TetramonCards,
                           List<Dictionary<string, object>> FantasyRPGCards,
                           List<Dictionary<string, object>> MegabotCards,
                           List<Dictionary<string, object>> CatJobCards,
                           int MaxCatJob,
                           int MaxFantasyRPG,
                           int MaxMegabot,
                           int MaxTetramonCards) GetFourSpecificCardSetsAndUpdateEnum()
            {
                // Retrieve the card dictionaries for each specific CardSet
                var tetramonCards = ConvertCardSetToDictList("Tetramon");
                var fantasyRPGCards = ConvertCardSetToDictList("FantasyRPG");
                var megabotCards = ConvertCardSetToDictList("Megabot");
                var catJobCards = ConvertCardSetToDictList("CatJob");

                // Calculate max values for each card set
                int maxCatJob = catJobCards.Count + 3040;
                int maxMegabot = megabotCards.Count + 1113;
                int maxFantasyRPG = fantasyRPGCards.Count + 2050;
                int maxTetramonCards = tetramonCards.Count + 122;

                // Load the assembly and retrieve the enum type definition (update with correct paths)
                var assemblyPath = Path.Combine("path_to_assembly", "Assembly-CSharp.dll");
                AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyPath);

                // Assuming the enum you need is inside a type like "MonsterTypeEnum" (replace with actual type name)
                TypeDefinition enumType = assembly.MainModule.Types.First(t => t.Name == "MonsterTypeEnum");

                // Call ChangeMaxValues to update the enum with new max values
                CustomMonsterHandler.ChangeMaxValues(enumType, maxTetramonCards, maxMegabot, maxFantasyRPG, maxCatJob);

                // Return the four lists and the max values as a tuple
                return (tetramonCards, fantasyRPGCards, megabotCards, catJobCards, maxCatJob, maxFantasyRPG, maxMegabot, maxTetramonCards);
            }


            private static Dictionary<string, object> ConvertToDict(MonsterData monsterData)
            {
                // Create a dictionary to hold monster information for adding to the enum
                Dictionary<string, (string MonsterType, int MonsterTypeID)> monstersToAdd = new Dictionary<string, (string MonsterType, int MonsterTypeID)>();

                // Assuming you have a way to get MonsterTypeID from monsterData (you may need to define this)
                int monsterTypeID = GetMonsterTypeID(monsterData.MonsterType); // Replace with your method to retrieve ID

                // Fill the dictionary with the monster data
                monstersToAdd[monsterData.Name] = (monsterData.MonsterType.ToString(), monsterTypeID);

                // Call to add new monsters to the enum
                var assemblyPath = Path.Combine("path_to_assembly", "Assembly-CSharp.dll"); // Ensure correct path
                AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyPath);
                TypeDefinition enumType = assembly.MainModule.Types.First(t => t.Name == "MonsterTypeEnum");

                CustomMonsterHandler.AddNewMonstersToEnum(enumType, monstersToAdd);

                return new Dictionary<string, object>
        {
            { "Name", monsterData.Name },
            { "Artist", monsterData.ArtistName },
            { "Description", monsterData.Description },
            { "EffectAmount", monsterData.EffectAmount },
            { "ElementIndex", monsterData.ElementIndex },
            { "MonsterType", monsterData.MonsterType },
            { "NextEvolution", monsterData.NextEvolution },
            { "PreviousEvolution", monsterData.PreviousEvolution },
            { "Rarity", monsterData.Rarity },
            { "Roles", monsterData.Roles },
            { "BaseStats", monsterData.BaseStats },
            { "SkillList", monsterData.SkillList },
            { "GhostIcon", monsterData.GhostIcon },
            { "Icon", monsterData.Icon }
        };
            }

            // Sample method to retrieve MonsterTypeID (Implement according to your logic)
            private static int GetMonsterTypeID(EMonsterType monsterType)
            {
                // Implement logic to convert EMonsterType to an ID
                return (int)monsterType; // Example conversion; replace with your logic
            }
        }

        public static MonsterData ModifyCard(MonsterData original, EMonsterType newMonsterType, string newName)
        {
            return new MonsterData
            {
                Name = newName,
                ArtistName = GetNewArtistName((int)newMonsterType),
                Description = original.Description,
                EffectAmount = original.EffectAmount,
                ElementIndex = original.ElementIndex,
                GhostIcon = original.GhostIcon,
                Icon = original.Icon,
                MonsterType = newMonsterType,
                NextEvolution = original.NextEvolution,
                PreviousEvolution = original.PreviousEvolution,
                Rarity = original.Rarity,
                Roles = original.Roles,
                BaseStats = original.BaseStats,
                SkillList = original.SkillList
            };
        }

        public static string GetNewArtistName(int monsterType)
        {
            switch (monsterType)
            {
                case 121: //
                    return "NewName";
                default: return null;
            }
        }
    }


    public static class ImageLoader
    {
        // Load a custom texture from the specified path
        public static Texture2D LoadCustomTexture(string fileName, string imagePath)
        {
            string imageToLoad = Path.Combine(imagePath, fileName + ".png");
            if (File.Exists(imageToLoad))
            {
                byte[] data = File.ReadAllBytes(imageToLoad);
                Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, false); // Use RGBA32 format for better color representation
                texture2D.LoadImage(data);
                return texture2D;
            }
            Debug.LogWarning($"Texture not found at path: {imageToLoad}");
            return null;
        }

        // Load a custom PNG texture from the specified path
        public static Texture2D LoadCustomPNG(string fileName, string imagePath)
        {
            return LoadCustomTexture(fileName, imagePath); // Reuse LoadCustomTexture for PNG files
        }

        // Create a Sprite from a custom image file
        public static Sprite GetCustomImage(string fileName, string imagePath)
        {
            Texture2D texture2D = LoadCustomPNG(fileName, imagePath);
            if (texture2D != null)
            {
                Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
                sprite.name = fileName; // Name the sprite for easy identification
                return sprite;
            }
            Debug.LogWarning($"Sprite creation failed for: {fileName} at path: {imagePath}");
            return null;
        }

        // Old Method's DO NOT USE
        /*
        public Dictionary<string, MonsterData> _monsterDataDict = new Dictionary<string, MonsterData>();
        public class ModdedMonsterData
        {
            private EnumListScript enumListScript = new EnumListScript(); // Correct instantiation
            public ModdedStats MonsterStats { get; set; } // New property for stats
            public string Name { get; set; }
            public string Artist { get; set; }
            public string Description { get; set; }
            public System.Numerics.Vector3 EffectAmount { get; set; }
            public string Element { get; set; }
            public string Rarity { get; set; }
            public string MonsterType { get; set; }
            public string NextEvolution { get; set; }
            public string PreviousEvolution { get; set; }
            public List<string> Roles { get; set; } = new List<string>(); // Initialize list
            public List<string> Skills { get; set; } = new List<string>(); // Initialize list

            // Icon properties for the monster
            public Sprite GhostIcon { get; set; }
            public Sprite DefaultIcon { get; set; }

            // Constructor that takes 12 arguments, with the element as a string
            public ModdedMonsterData(
                string name,
                string artist,
                string description,
                float x,
                float y,
                float z,
                string elementName,
                string rarity,
                string monsterType,
                string nextEvolution,
                string previousEvolution,
                List<string> roles,
                ModdedStats stats,
                List<string> skills,
                Sprite ghostIcon,
                Sprite defaultIcon)
            {
                Name = name;
                Artist = artist;
                Description = description;
                EffectAmount = new System.Numerics.Vector3(x, y, z); // Initialize EffectAmount using x, y, z

                // Element validation
                if (enumListScript.Elements.Contains(elementName))
                {
                    Element = elementName;
                }
                else
                {
                    Debug.LogWarning($"Element '{elementName}' not found!"); // Warning for invalid element name
                }

                // Rarity validation
                if (enumListScript.Rarities.Contains(rarity))
                {
                    Rarity = rarity;
                }
                else
                {
                    Debug.LogWarning($"Rarity '{rarity}' not found!"); // Warning for invalid rarity name
                }

                // Monster Type validation
                if (enumListScript.CardsTotal.Contains(monsterType))
                {
                    MonsterType = monsterType;
                }
                else
                {
                    Debug.LogWarning($"Monster Type '{monsterType}' not found!"); // Warning for invalid Monster Type name
                }

                // Next Evolution validation
                if (enumListScript.CardsTotal.Contains(nextEvolution))
                {
                    NextEvolution = nextEvolution;
                }
                else
                {
                    Debug.LogWarning($"Next Evolution '{nextEvolution}' not found!"); // Warning for invalid Next Evolution name
                }

                // Previous Evolution validation
                if (enumListScript.CardsTotal.Contains(previousEvolution))
                {
                    PreviousEvolution = previousEvolution;
                }
                else
                {
                    Debug.LogWarning($"Previous Evolution '{previousEvolution}' not found!"); // Warning for invalid Previous Evolution name
                }

                // Role validation
                foreach (var role in roles.ToList())
                {
                    if (enumListScript.Roles.Contains(role))
                    {
                        Roles.Add(role); // Add valid role to the Roles list
                    }
                    else
                    {
                        Debug.LogWarning($"Role '{role}' not found!"); // Warning for invalid role
                    }
                }

                // Skill validation
                foreach (var skill in skills.ToList())
                {
                    if (enumListScript.Skills.Contains(skill))
                    {
                        Skills.Add(skill); // Add valid skill to the Skills list
                    }
                    else
                    {
                        Debug.LogWarning($"Skill '{skill}' not found!"); // Warning for invalid skill
                    }
                }

                MonsterStats = stats;

                // Set the icons directly
                GhostIcon = ghostIcon;
                DefaultIcon = defaultIcon;
            }

            // Method to update EffectAmount later if needed
            public void SetEffectAmount(float x, float y, float z)
            {
                EffectAmount = new System.Numerics.Vector3(x, y, z);
            }

            // Method to get the icon based on the expansion type
            public Sprite GetIcon(ECardExpansionType cardExpansionType)
            {
                if (cardExpansionType == ECardExpansionType.Ghost)
                {
                    return GhostIcon; // Return the Ghost icon
                }

                if (DefaultIcon != null)
                {
                    return DefaultIcon; // Return the default icon if available
                }

                // If the specific cardExpansionType is not found, fallback to special icon
                return LoadStreamTexture.GetImage("Special_" + MonsterType);
            }
        }

        public List<Sprite> CardPortraits = new List<Sprite> { };

        // This method should not be static to access the instance variable
        public void AddCardsToPool(string ModPrefix, string CardName, string ImagePath, string CardSet)
        {
            EnumListScript enumListScript = new EnumListScript();
            Stats stats = new Stats();

            // Combine ModPrefix and CardName to form the key
            string CardEnum = ModPrefix + "_" + CardName;
            string Set = CardSet;
            string ImagePathNew = Path.Combine(ImagePath, CardEnum);

            // Setup Base Game Cards as An Array

            // Check if ModdedCards has any entries
            if (enumListScript.CardsTotal != null && enumListScript.CardsTotal.Count > 0)
            {
                // Find the index of MAX
                int TetraMonInsert = enumListScript.CardsTotal.IndexOf("MAX");
                int MegabotInsert = enumListScript.CardsTotal.IndexOf("MAX_MEGABOT");
                int FantasyRPGInsert = enumListScript.CardsTotal.IndexOf("MAX_FANTASYRPG");
                int CatJobInsert = enumListScript.CardsTotal.IndexOf("MAX_CATJOB");
                // Insert the modded cards before MAX if the Set is "MAX"
                foreach (var card in enumListScript.CardsTotal.ToList())
                {

                    if (CardSet == "Tetramon") // Check if the Set is "Tetramon"
                    {
                        // Insert each CardEnum at the found index
                        enumListScript.CardsTotal.Insert(TetraMonInsert, CardEnum); // Using card.Value to get the CardEnum
                        TetraMonInsert++; // Increment the index to insert subsequent cards
                    }
                    if (CardSet == "Megabot") // Check if the Set is "MegaBot"
                    {
                        // Insert each CardEnum at the found index
                        enumListScript.CardsTotal.Insert(MegabotInsert, CardEnum); // Using card.Value to get the CardEnum
                        MegabotInsert++; // Increment the index to insert subsequent cards
                    }
                    if (CardSet == "FantasyRPG") // Check if the Set is "FantasyRPG"
                    {
                        // Insert each CardEnum at the found index
                        enumListScript.CardsTotal.Insert(FantasyRPGInsert, CardEnum); // Using card.Value to get the CardEnum
                        FantasyRPGInsert++; // Increment the index to insert subsequent cards
                    }
                    if (CardSet == "CatJob") // Check if the Set is "CatJob"
                    {
                        // Insert each CardEnum at the found index
                        enumListScript.CardsTotal.Insert(CatJobInsert, CardEnum); // Using card.Value to get the CardEnum
                        CatJobInsert++; // Increment the index to insert subsequent cards
                    }
                }
                // Example of creating a MonsterData object with an element name
                ModdedStats teststats = new ModdedStats(100, 20, 15, 10, 5, 10, 0, 2, 5, 3, 1, 74);
                // MonsterData MyMonster = CreateCopy(EMonsterType.AncientHammer, EMonsterType.AncientHammer, "Alpha");
            }
        }

        // Method to fetch a MonsterData by name
        public MonsterData GetMonsterData(string name)
        {
            if (_monsterDataDict.TryGetValue(name, out var monsterData))
            {
                return monsterData;
            }
            Debug.LogWarning($"MonsterData with name '{name}' not found!");
            return null;
        }

        // Optional: Method to fetch all MonsterData
        public List<MonsterData> GetAllMonsterData()
        {
            return new List<MonsterData>(_monsterDataDict.Values);
        }
        */
    }
}