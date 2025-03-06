using API_For_TCG_Card_Shop_Simulator.Helpers;
using API_For_TCG_Card_Shop_Simulator.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using BepInEx;
using UnityEngine;
using Logger = HarmonyLib.Tools.Logger;

namespace API_For_TCG_Card_Shop_Simulator.Cards
{
    // Card Handling Logic
    public class CardHandlingNew
    {
        // Define the ModdedMonsterData Dictionary
        public static List<TetramonCards> TetramonCards = new List<TetramonCards>() { };
        public static List<MegabotCards> MegaBotCards = new List<MegabotCards>() { };
        public static List<FantasyRPGCards> FantasyRPGCards = new List<FantasyRPGCards>() { };
        public static List<CatJobCards> CatJobCards = new List<CatJobCards>() { };

        // Handle Portraits
        public static Sprite BaseGetPortrait(string path,  string type)
        {
            string newpath = Path.GetDirectoryName(path);
            string file = Path.GetFileName(path);
            if (type == "ghost")
            {
                file = Path.GetFileName(path);
            }
            Sprite Artwork = ImageLoader.GetCustomImage(file, newpath);
            return Artwork;
        }

        // Get Portrait
        public static Sprite GetPortrait(string path)
        {
            return BaseGetPortrait(path, "");
        }

        // Get Ghost Portrait
        public static Sprite GetGhostPortrait(string path)
        {
            return BaseGetPortrait(path, "_ghost");
        }
        public static int TetraIterator = 0;
        // Create a Tetramon Card Data
        public static void CreateTetramonCards(string modId, string name, string artistName, string description, Vector3 effectAmount, EElementIndex elementIndex, ERarity rarity, MonsterType.EMonsterTypeLocal monsterType, MonsterType.EMonsterTypeLocal nextEvolution, MonsterType.EMonsterTypeLocal previousEvolution, List<EMonsterRole> roles, Stats stats, List<ESkill> skillList, string icon, string ghostIcon)
        {
            string NewName = "";
            // Format Our Input
            if (!modId.IsNullOrWhiteSpace())
            {
                NewName = modId + "_" + name;
            }
            else
            {
                NewName = name;
            }
            Sprite Icon = GetPortrait(icon);
            Sprite GhostIcon = GetPortrait(ghostIcon);
            

            TetramonCards tetramonCard = new TetramonCards()
            {
                Name = NewName,
                ArtistName = artistName,
                Description = description,
                EffectAmount = effectAmount,
                Rarity = rarity,
                MonsterType = monsterType,
                NextEvolution = nextEvolution,
                PreviousEvolution = previousEvolution,
                Roles = roles,
                Stats = stats,
                SkillList = skillList,
                Icon = Icon,
                GhostIcon = GhostIcon,
            };
            if (Plugin.VerboseLogging.Value == true)
            {
                Console.WriteLine($"Creating Tetramon card for: {NewName}");
                Console.WriteLine($"Name = {NewName}");
                Console.WriteLine($"ArtistName = {artistName}");
                Console.WriteLine($"Description = {description}");
                Console.WriteLine($"EffectAmount = {effectAmount}");
                Console.WriteLine($"ElementIndex = {elementIndex}");
                Console.WriteLine($"Rarity = {rarity}");
                Console.WriteLine($"MonsterType = {monsterType}");
                Console.WriteLine($"NextEvolution = {nextEvolution}");
                Console.WriteLine($"PreviousEvolution = {previousEvolution}");
                Console.WriteLine($"Roles = {roles}");
                Console.WriteLine($"Stats = {stats}");
                Console.WriteLine($"SkillList = {skillList}");
                Console.WriteLine($"Icon = {icon}");
                Console.WriteLine($"GhostIcon = {ghostIcon}");
            }
            TetramonCards.Add(tetramonCard);
            Console.WriteLine($"Creation Process done for: {NewName} Total Completed as of this Entry {TetraIterator}");
            TetraIterator++;
        }
    }
}