using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using TCGShopNewCardsModPreloader.Handlers;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace API_For_TCG_Card_Shop_Simulator.Scripts
{
    internal class CardHandler
    {
        private static Dictionary<string, List<CustomCard>> cardSets = new Dictionary<string, List<CustomCard>>();
        public static List<CustomCard> newMonstersList = new List<CustomCard>();

        // Method to add a new card and store it under the specified CardSet
        public static CustomCard AddNewCard(string CardSet, string ModPrefix, string CardName, string Artist, string Description, UnityEngine.Vector3 effectAmount, string element, string nextEvolution, string previousEvolution, string rarity, List<string> role, List<int> stats, List<string> Skills, string ImagePath)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo("Creating and adding new card...");

            CustomCard newCard = CreateCard(CardSet, ModPrefix, CardName, Artist, Description, effectAmount, element, nextEvolution, previousEvolution, rarity, role, stats, Skills, ImagePath);

            if (!cardSets.ContainsKey(CardSet))
            {
                cardSets[CardSet] = new List<CustomCard>();
            }
            cardSets[CardSet].Add(newCard);

            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo($"Added card {CardName} to set {CardSet}.");

            return newCard;
        }

        // Define a static dictionary to hold dynamic enum-like mappings
        private static Dictionary<string, EMonsterType> dynamicMonsterTypes = new Dictionary<string, EMonsterType>();

        private static CustomCard CreateCard(string CardSet, string ModPrefix, string CardName, string Artist, string Description,
                                             UnityEngine.Vector3 effectAmount, string element, string nextEvolution,
                                             string previousEvolution, string rarity, List<string> role, List<int> stats,
                                             List<string> Skills, string ImagePath)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo("Creating card...");

            // Load the assembly
            AssemblyDefinition loadedAssembly = GetAssemblyDefinition("Assembly-CSharp.dll");

            // Construct monster type string
            string monsterType = ModPrefix + "_" + CardName;

            // Add the new value to the dictionary (acting as a dynamic enum)
            if (!dynamicMonsterTypes.ContainsKey(monsterType))
            {
                dynamicMonsterTypes.Add(monsterType, EMonsterType.WeirdBirdA);  // Default value, or you can choose an appropriate value
                Plugin.Log.LogInfo($"Dynamically registered monster type '{monsterType}'");
            }

            // Attempt to retrieve the monster type from the dictionary
            if (!dynamicMonsterTypes.TryGetValue(monsterType, out var monsterTypeValue))
            {
                Debug.LogError($"Failed to find '{monsterType}' in dynamic monster types.");
                monsterTypeValue = EMonsterType.WeirdBirdA; // Fallback value
            }

            

            // Return the newly created card
            return new CustomCard
            {
                MonsterTypeType = monsterTypeValue,
                Name = CardName,
                ArtistName = Artist,
                Description = Description,
                EffectAmount = effectAmount,
                ElementIndex = element,
                MonsterType = monsterType,
                NextEvolution = nextEvolution,
                PreviousEvolution = previousEvolution,
                Rarity = rarity,
                Roles = role,
                Skills = Skills,
                GhostIcon = ImageLoader.GetCustomImage($"{ModPrefix}_{CardName}_Ghost", ImagePath),
                Icon = ImageLoader.GetCustomImage($"{ModPrefix}_{CardName}", ImagePath),
                BaseStats = NewStats(stats)
            };
        }

        public static Stats NewStats(List<int> Stats)
        {
            return new Stats()
                {
                HP = Stats[0],
                HP_LevelAdd = Stats[1],
                Magic = Stats[2],
                Magic_LevelAdd = Stats[3],
                Speed = Stats[4],
                Speed_LevelAdd = Stats[5],
                Spirit = Stats[6],
                Spirit_LevelAdd = Stats[7],
                Strength = Stats[8],
                Strength_LevelAdd = Stats[9],
                Vitality = Stats[10],
                Vitality_LevelAdd = Stats[11]
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
        public static List<CustomCard> GetCardsBySet(string CardSet)
        {
            return cardSets.ContainsKey(CardSet) ? cardSets[CardSet] : new List<CustomCard>();
        }

        // Retrieve all CardSets
        public static Dictionary<string, List<CustomCard>> GetAllCardSets()
        {
            return cardSets;
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