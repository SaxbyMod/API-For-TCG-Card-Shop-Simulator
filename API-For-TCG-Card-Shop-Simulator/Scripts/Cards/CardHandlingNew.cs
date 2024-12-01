﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var file = ID + type + ".png";
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
        public static void AddBaseCard(string set, string name, string prefix, string artist, string PortaitPath, string GhostPortraitPath, string flavor, string Rarity, string Element, string Role, List<string> Skills, List<int> stats, string NextEvolution, string PreviousEvolution)
        {
            string ID = prefix + name;
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