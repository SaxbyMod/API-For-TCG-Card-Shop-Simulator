using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

        public CustomCard(string set, string prefix, string name, string artistname, string description, Sprite icon, Sprite ghosticon, string nextevolution, string previousevolution, string rarity, string element, string role, List<string> skills, int hp, int strength, int magic, int vitality, int spirit, int speed)
        {
            Set = set;
            Prefix = prefix;
            Name = name;
            ArtistName = artistname;
            Description = description;
            Icon = icon;
            GhostIcon = ghosticon;
            NextEvolution = nextevolution;
            PreviousEvolution = previousevolution;
            Rarity = rarity;
            Element = element;
            Role = role;
            Skills = skills;
            HP = hp;
            Strength = strength;
            Magic = magic;
            Vitality = vitality;
            Spirit = spirit;
            Speed = speed;
        }
    };

    // Card Handling Logic
    public class CardHandlingNew
    {
        // Define the ModdedMonsterData Dictionary
        public static List<CustomCard> CustomCards = new List<CustomCard>();
        public static Dictionary<string, List<CustomCard>> ModdedMonsterData = new Dictionary<string, List<CustomCard>> { 
            { "BaseGame", CustomCards }
        };

        // Create New Data for a Card
        public static void CreateNewData(string set, string ID)
        {
            // Create New ID into Set Dict's
            int Count = EnumListScript.SetDict[set].Count;
            EnumListScript.SetDict[set].Add(ID, Count + 1);
            Console.WriteLine("ID Inserted for " + EnumListScript.SetDict[set][ID]);
        }

        // Handle Portraits
        public static Sprite BaseGetPortrait(string path, string set, string ID, string type)
        {
            string newpath = path;
            var file = ID + type;
            if (File.Exists(path))
            {
                newpath = Path.GetDirectoryName(path);
                file = Path.GetFileName(path);
            }
            else
            {
                API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogMessage($"Artwork not found instead using: {ID}{type}.png");
            }
            Sprite Artwork = ImageLoader.GetCustomImage(file, newpath);
            return Artwork;
        }

        // Get Portrait
        public static Sprite GetPortrait(string path, string set, string ID)
        {
            return BaseGetPortrait(path, set, ID, "");
        }

        // Get Ghost Portrait
        public static Sprite GetGhostPortrait(string path, string set, string ID)
        {
            return BaseGetPortrait(path, set, ID, "_ghost");
        }

        // Add Card
        public static void AddBaseCard(string set, string prefix, string name, string artist, string PortaitPath, string GhostPortraitPath, string flavor, string Rarity, string Element, string Role, List<string> Skills, List<int> stats, string NextEvolution, string PreviousEvolution)
        {
            string ID = prefix + "_" + name;
            // Add Data to Set and Fetch Artworks
            CreateNewData(set, ID);
            Sprite Artwork = GetPortrait(PortaitPath, set, ID);
            Sprite GhostPortrait = GetGhostPortrait(GhostPortraitPath, set, ID);

            // Set the New Variants
            var newRarity = EnumListScript.Rarities.Contains(Rarity) ? Rarity : "";
            var newElement = EnumListScript.Elements.Contains(Element) ? Element : "";
            var newRole = EnumListScript.Roles.Contains(Role) ? Role : "";
            var newNextEvolution = EnumListScript.SetDict[set].ContainsKey(NextEvolution) ? NextEvolution : "";
            var newPreviousEvolution = EnumListScript.SetDict[set].ContainsKey(PreviousEvolution) ? PreviousEvolution : "";
            var newSkills = Skills.Where(item => EnumListScript.Skills.Contains(item)).ToList();

            // Stat Variables
            int HP = stats[0];
            int Strength = stats[1];
            int Magic = stats[2];
            int Vitality = stats[3];
            int Spirit = stats[4];
            int Speed = stats[5];

            // Create CustomCard
            CustomCard customCard = new CustomCard
            (
                set,
                prefix,
                name,
                artist,
                flavor,
                Artwork,
                GhostPortrait,
                newNextEvolution,
                newPreviousEvolution,
                newRarity,
                newElement,
                newRole,
                newSkills,
                HP,
                Strength,
                Magic,
                Vitality,
                Spirit,
                Speed
            );
            CustomCards.Add(customCard);
            // Debug Logging
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug($"Verbose logging for card {customCard.Prefix}_{customCard.Name}");
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Set);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Prefix);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Name);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.ArtistName);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Description);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Icon);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.GhostIcon);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.NextEvolution);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.PreviousEvolution);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Rarity);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Element);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Role);
            foreach (string item in customCard.Skills)
            {
                API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Skills.IndexOf(item));
            }
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.HP);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Strength);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Magic);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Vitality);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Spirit);
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogDebug(customCard.Speed);
        }
    }
}