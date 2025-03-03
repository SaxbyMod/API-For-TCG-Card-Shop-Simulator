using API_For_TCG_Card_Shop_Simulator.Helpers;
using API_For_TCG_Card_Shop_Simulator.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Cards
{
    // Card Handling Logic
    public class CardHandlingNew
    {
        // Define the ModdedMonsterData Dictionary
        public static Dictionary<int, MonsterData> CustomCards = new Dictionary<int, MonsterData>() { };
        public static Dictionary<string, Dictionary<int, MonsterData>> ModdedMonsterData = new Dictionary<string, Dictionary<int, MonsterData>> {
            { "Tetramon", CustomCards }
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
                Plugin.Log.LogMessage($"Artwork not found instead using: {ID}{type}.png");
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
        /*// Add Card
        public static void AddBaseCard(string set, string prefix, string name, string artist, string PortaitPath, string GhostPortraitPath, string flavor, ERarity Rarity, string Element, string Role, List<string> Skills, List<int> stats, string NextEvolution, string PreviousEvolution)
        {
            int i = 0;
            string ID = prefix + "_" + name;
            // Add Data to Set and Fetch Artworks
            CreateNewData(set, ID);
            Sprite Artwork = GetPortrait(PortaitPath, set, ID);
            Sprite GhostPortrait = GetGhostPortrait(GhostPortraitPath, set, ID);

            // Set the New Variants
            var newRarity = Rarity;
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
            int Id = EnumListScript.SetDict[set][ID];

            // Create CustomCard
            MonsterDataModded customCard = new MonsterDataModded
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
                Speed,
                Id
            );
            CustomCards.Add(i, customCard);
            // Debug Logging
            if (Plugin.VerboseLogging.Value == true)
            {
                Console.WriteLine($"Verbose logging for card {customCard.Prefix}_{customCard.Name}");
                Console.WriteLine("Set: " + customCard.Set);
                Console.WriteLine("Prefix:" + customCard.Prefix);
                Console.WriteLine("Name: " + customCard.Name);
                Console.WriteLine("Artist: " + customCard.ArtistName);
                Console.WriteLine("Description: " + customCard.Description);
                Console.WriteLine("Icon: " + customCard.Icon);
                Console.WriteLine("Ghost Icon: " + customCard.GhostIcon);
                Console.WriteLine("Next Evolution: " + customCard.NextEvolution);
                Console.WriteLine("Previous Evolution: " + customCard.PreviousEvolution);
                Console.WriteLine("Rarity: " + customCard.Rarity);
                Console.WriteLine("Element: " + customCard.Element);
                Console.WriteLine("Role: " + customCard.Role);
                int g = 0;
                foreach (string item in customCard.Skills)
                {
                    Console.WriteLine($"Skills {g}: " + customCard.Skills.IndexOf(item));
                    g++;
                }
                Console.WriteLine("HP: " + customCard.HP);
                Console.WriteLine("Strength: " + customCard.Strength);
                Console.WriteLine("Magic: " + customCard.Magic);
                Console.WriteLine("Vitality: " + customCard.Vitality);
                Console.WriteLine("Spirit: " + customCard.Spirit);
                Console.WriteLine("Speed: " + customCard.Speed);
                Console.WriteLine("Id: " + customCard.ID);
            }
            int CurrentMax = (int)EnumListScript.MonsterMax[set];
            EnumListScript.MonsterMax.Remove(set);
            EnumListScript.MonsterMax.Add(set, CurrentMax + 1);
            i++;
        }*/
    }
}