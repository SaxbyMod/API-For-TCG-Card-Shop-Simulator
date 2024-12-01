using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Scripts.Cards
{
    // Define a Base Game Custom Card
    public class CustomCard
    {
        public string Set { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public Sprite Icon { get; set; }
        public Sprite GhostIcon { get; set; }
        public string NextEvolution { get; set; }
        public string PreviousEvolution { get; set; }
        public string Rarity { get; set; }
        public string Element { get; set; }
        public string Role { get; set; }
        public List<string> Skills { get; set; }
        public int HP { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int Vitality { get; set; }
        public int Spirit { get; set; }
        public int Speed { get; set; }
    };

    // Card Handling Logic
    public class CardHandlingNew
    {
        // Define the ModdedMonsterData Dictionary
        public static Dictionary<string, List<CustomCard>> ModdedMonsterData = new Dictionary<string, List<CustomCard>> { };
        public static List<CustomCard> CustomCards = new List<CustomCard>();
        // Create New Data for a Card
        public static void CreateNewData(string set, string ID)
        {
            // Create New ID into Set Dict's
            int Count = EnumListScript.SetDict[set].Count;
            EnumListScript.SetDict[set].Add(ID, Count + 1);
            Console.WriteLine("ID Inserted for " + EnumListScript.SetDict[set][ID]);
        }

        // Get Portrait
        public static Sprite GetPortrait(string path, string set, string ID)
        {
            string newpath = path;
            var file = ID + ".png";
            if (File.Exists(path))
            {
                newpath = Path.GetDirectoryName(path);
                file = Path.GetFileName(path);
            }
            else
            {
                API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogMessage($"Artwork not found instead using: {ID}.png");
            }
            Sprite Artwork = ImageLoader.GetCustomImage(file, newpath);
            return Artwork;
        }

        // Get Ghost Portrait
        public static Sprite GetGhostPortrait(string path, string set, string ID)
        {
            string newpath = path;
            var file = ID + ".png";
            if (File.Exists(path))
            {
                newpath = Path.GetDirectoryName(path);
                file = Path.GetFileName(path);
            }
            else
            {
                API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogMessage($"Ghost Artwork not found instead using: {ID}_ghost.png");
            }
            Sprite GhostArtwork = ImageLoader.GetCustomImage(file, newpath);
            return GhostArtwork;
        }

        // Add Card
        public static void AddBaseCard(string set, string name, string prefix, string artist, string PortaitPath, string GhostPortraitPath, string flavor, string Rarity, string Element, string Role, List<string> Skills, List<int> stats, string NextEvolution, string PreviousEvolution)
        {
            string ID = prefix + name;
            // Add Data to Set and Fetch Artworks
            CreateNewData(set, ID);
            Sprite Artwork = GetPortrait(PortaitPath, set, ID);
            Sprite GhostPortrait = GetGhostPortrait(GhostPortraitPath, set, ID);

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
            // Stat Variables
            int HP = stats[0];
            int Strength = stats[1];
            int Magic = stats[2];
            int Vitality = stats[3];
            int Spirit = stats[4];
            int Speed = stats[5];

            string newNextEvolution = "";
            string newPreviousEvolution = "";

            // Validate Next Evolution
            if (EnumListScript.SetDict[set].ContainsKey(NextEvolution))
            {
                newNextEvolution = NextEvolution;
            }
            // Validate Previous Evolution
            if (EnumListScript.SetDict[set].ContainsKey(PreviousEvolution))
            {
                newNextEvolution = PreviousEvolution;
            }
            // Create CustomCard
            CustomCard customCard = new CustomCard
            {
                Set = set,
                Prefix = prefix,
                Name = name,
                ArtistName = artist,
                Description = flavor,
                Icon = Artwork,
                GhostIcon = GhostPortrait,
                NextEvolution = newNextEvolution,
                PreviousEvolution = newPreviousEvolution,
                Rarity = newRarity,
                Element = newElement,
                Role = newRole,
                Skills = newSkills,
                HP = HP,
                Strength = Strength,
                Magic = Magic,
                Vitality = Vitality,
                Spirit = Spirit,
                Speed = Speed
            };
            CustomCards.Add(customCard);
        }
    }
}