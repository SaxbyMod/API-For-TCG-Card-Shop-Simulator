using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TCGShopNewCardsModPreloader.Handlers;
using UnityEngine;
using BepInEx.Logging;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace API_For_TCG_Card_Shop_Simulator.Scripts
{
    internal class CardHandler
    {
        private static Dictionary<string, List<MonsterData>> cardSets = new Dictionary<string, List<MonsterData>>();
        public static List<CustomCard> newMonstersList = new List<CustomCard>();

        // Method to add a new card and store it under the specified CardSet
        public static MonsterData AddNewCard(string CardSet, string ModPrefix, string CardName, string Artist, string Description, UnityEngine.Vector3 effectAmount, EElementIndex element, EMonsterType nextEvolution, EMonsterType previousEvolution, ERarity rarity, List<string> role, Stats stats, List<string> Skills, string ImagePath)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo("Creating and adding new card...");

            MonsterData newCard = CreateCard(CardSet, ModPrefix, CardName, Artist, Description, effectAmount, element, nextEvolution, previousEvolution, rarity, role, stats, Skills, ImagePath);

            if (!cardSets.ContainsKey(CardSet))
            {
                cardSets[CardSet] = new List<MonsterData>();
            }
            cardSets[CardSet].Add(newCard);

            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo($"Added card {CardName} to set {CardSet}.");

            return newCard;
        }

        private static MonsterData CreateCard(string CardSet, string ModPrefix, string CardName, string Artist, string Description,
                                      UnityEngine.Vector3 effectAmount, EElementIndex element, EMonsterType nextEvolution,
                                      EMonsterType previousEvolution, ERarity rarity, List<string> role, Stats stats,
                                      List<string> Skills, string ImagePath)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo("Creating card...");

            AssemblyDefinition loadedAssembly = GetAssemblyDefinition("Assembly-CSharp.dll");

            // Proceed with other logic
            TypeDefinition typeDefinition = loadedAssembly.MainModule.Types.First(t => t.Name == "EMonsterType");
            CustomMonsterHandler.CloneAndAddEnumValue(typeDefinition, "FireChickenB", ModPrefix + "_" + CardName, 9999);
            Console.WriteLine("Added new monster");

            foreach (var field in typeDefinition.Fields)
            {
                Plugin.Log.LogDebug($"{field.Name} {field.InitialValue}");
            }

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
                    API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogWarning($"Skill '{s}' could not be parsed to ESkill. Defaulting to None.");
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
                GhostIcon = ImageLoader.GetCustomImage($"{ModPrefix}_{CardName}_Ghost", ImagePath),
                Icon = ImageLoader.GetCustomImage($"{ModPrefix}_{CardName}", ImagePath)
            };
        }

        private static AssemblyDefinition GetAssemblyDefinition(string assemblyName = "Assembly-CSharp.dll")
        {
            Process[] processes = Process.GetProcessesByName("Card Shop Simulator");
            var cardShopSim = processes.FirstOrDefault();
            // Get the full path of the process executable
            string processPath = cardShopSim.MainModule.FileName;

            // Extract the directory from the full path
            string processDirectory = Path.GetDirectoryName(processPath);
            Console.WriteLine("Process Directory: " + processDirectory);
            string baseDirectory = processDirectory;

            string dllPath = baseDirectory + $@"\Card Shop Simulator_Data\Managed\{assemblyName}";
            AssemblyDefinition loadedAssembly = new();
            try
            {
                // Load the assembly from the specified path
                loadedAssembly = AssemblyDefinition.ReadAssembly(Assembly.LoadFile(dllPath).Location);

                // Display the assembly's full name as confirmation
                Console.WriteLine("Loaded Assembly: " + loadedAssembly.FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading DLL: " + ex.Message);
            }
            return loadedAssembly;
        }

        // Retrieve cards by CardSet
        public static List<MonsterData> GetCardsBySet(string CardSet)
        {
            return cardSets.ContainsKey(CardSet) ? cardSets[CardSet] : new List<MonsterData>();
        }

        // Retrieve all CardSets
        public static Dictionary<string, List<MonsterData>> GetAllCardSets()
        {
            return cardSets;
        }

        // Class to convert card data to dictionaries and handle enum updates
        public class CardDataConverter
        {
            // Convert all cards in a CardSet to a list of dictionaries
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
                var tetramonCards = ConvertCardSetToDictList("Tetramon");
                var fantasyRPGCards = ConvertCardSetToDictList("FantasyRPG");
                var megabotCards = ConvertCardSetToDictList("Megabot");
                var catJobCards = ConvertCardSetToDictList("CatJob");

                int maxCatJob = catJobCards.Count + 3040;
                int maxMegabot = megabotCards.Count + 1113;
                int maxFantasyRPG = fantasyRPGCards.Count + 2050;
                int maxTetramonCards = tetramonCards.Count + 122;

                var assemblyPath = Path.Combine("path_to_assembly", "Assembly-CSharp.dll");
                AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyPath);

                TypeDefinition enumType = assembly.MainModule.Types.First(t => t.Name == "MonsterTypeEnum");

                List<CustomMonsterAttribute> monsters = new List<CustomMonsterAttribute>
                {
                    new CustomMonsterAttribute { Name = "CatJob", MaxValue = maxCatJob },
                    new CustomMonsterAttribute { Name = "FantasyRPG", MaxValue = maxFantasyRPG },
                    new CustomMonsterAttribute { Name = "Megabot", MaxValue = maxMegabot },
                    new CustomMonsterAttribute { Name = "Tetramon", MaxValue = maxTetramonCards }
                };

                CustomMonsterHandler.ChangeMaxValues(enumType, monsters);

                return (tetramonCards, fantasyRPGCards, megabotCards, catJobCards, maxCatJob, maxFantasyRPG, maxMegabot, maxTetramonCards);
            }

            private static Dictionary<string, object> ConvertToDict(MonsterData monsterData)
            {
                var monstersToAdd = new Dictionary<string, (string MonsterType, int MonsterTypeID)>();
                int monsterTypeID = GetMonsterTypeID(monsterData.MonsterType);

                monstersToAdd[monsterData.Name] = (monsterData.MonsterType.ToString(), monsterTypeID);

                var assemblyPath = Path.Combine("path_to_assembly", "Assembly-CSharp.dll");
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

            // Retrieve MonsterTypeID (implementation example)
            private static int GetMonsterTypeID(EMonsterType monsterType)
            {
                return (int)monsterType;
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
        }
    }
}