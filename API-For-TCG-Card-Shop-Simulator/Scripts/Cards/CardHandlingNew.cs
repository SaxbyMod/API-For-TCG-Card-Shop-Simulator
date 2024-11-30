using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Scripts.Cards
{
    // Define a Custom Card
    public class CustomCard
    {
        // Required Parameters
        public string Set { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public Sprite Artwork { get; set; }
        // Additional Parameters added on from Sets
        Dictionary<string, object> AddedParams { get; set; }

        // Set the values
        public CustomCard(string name, string set, string prefix, string artist, Sprite portrait, Dictionary<string, object> setParams)
        {
            Name = name;
            Set = set;
            Prefix = prefix;
            ArtistName = artist;
            Artwork = portrait;
            AddedParams = setParams;
        }

        // Handle Additional Parameters
        public void CreateWithAdditionalParameters<T>(Dictionary<string, object> additionalParams, params object[] constructorArgs) where T : class
        {
            // Create the object using the standard constructor
            T obj = (T)Activator.CreateInstance(typeof(T), constructorArgs);

            // Set additional parameters using reflection
            foreach (var param in additionalParams)
            {
                PropertyInfo property = typeof(T).GetProperty(param.Key, BindingFlags.Public | BindingFlags.Instance);
                if (property != null && property.CanWrite)
                {
                    property.SetValue(obj, Convert.ChangeType(param.Value, property.PropertyType));
                }
            }
        }
    }

    // Card Handling Logic
    public class CardHandlingNew
    {
        // Define the ModdedMonsterData Dictionary
        public static Dictionary<string, List<CustomCard>> ModdedMonsterData = new Dictionary<string, List<CustomCard>> { };

        // Create New Data for a Card
        public static void CreateNewData(string set, string name, string prefix, string artist, Sprite Portait, Dictionary<string, object> additionalParams)
        {
            // Create New ID into Set Dict's
            string ID = prefix + name;
            int Count = EnumListScript.SetDict[set].Count;
            EnumListScript.SetDict[set].Add(ID, Count + 1);
            Console.WriteLine("ID Inserted for " + EnumListScript.SetDict[set][ID]);
            // Set Custom Cards
            CustomCard customCard = new CustomCard(set, name, prefix, artist, Portait, additionalParams);
        }

        public static void AddTetra(string Rarity, string Element, string Role, List<string> Skills, Dictionary<string, int> stats, string NextEvolution, string PreviousEvolution, Sprite GhostArtwork)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string DLLPath = Path.GetDirectoryName(assembly.Location);
            string MySecretPath = Path.Combine(DLLPath + $"\\Art");
            Sprite MyImage = ImageLoader.GetCustomImage($"MyTest_Mythos", MySecretPath);

            var newRarity = "";
            var newElement = "";
            var newRole = "";
            List<string> newSkills = [];
            // Rarity Validation
            if (EnumListScript.Rarities.Contains(Rarity))
            {
                newRarity = Rarity;
            }
            // Element Validation
            if (EnumListScript.Elements.Contains(Rarity))
            {
                newElement = Element;
            }
            // Role Validation
            if (EnumListScript.Roles.Contains(Rarity))
            {
                newRole = Role;
            }
            // Skill Validation
            foreach (string item in Skills)
            {
                if (EnumListScript.Skills.Contains(item))
                {
                    newSkills.Add(item);
                }
            }

            Dictionary<string, object> additionalParams = new Dictionary<string, object>
            {
                { "Rarity", newRarity },
                { "Element", newElement },
                { "Roles", newRole },
                { "Skills", EnumListScript.Skills },
                { "Stats", EnumListScript.Stats },
                { "Next Evolution", string.Empty },
                { "Previous Evolution", string.Empty },
                { "Ghost Artwork", Sprite }
            };
            CreateNewData("Tetramon", "Mythos", "Debug", "Creator", MyImage, additionalParams);
        }
    }
}
