using API_For_TCG_Card_Shop_Simulator.Scripts;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace The_Hex_Expansion
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        readonly Harmony harmony = new(PluginGuid);

        // These are variables that exist everywhere in the entire class.
        public const string PluginGuid = "creator.TheAPI";
        public const string PluginName = "The API for TCG Card Shop Simulator";
        public const string PluginVersion = "1.0.0";
        public const string PluginPrefix = "TheAPI";

        // Corrected List initialization
        public List<string> CardsToAdd = new List<string>();

        // Static CardHandler instance
        private static CardHandler cardHandler = new CardHandler();
        public void Awake()
        {
            // Removed 'public' keyword from here
            Assembly assembly = Assembly.GetExecutingAssembly();
            string DLLPath = Path.GetDirectoryName(assembly.Location);
            
            AddCards("Tetramon", "MyPrefix", "TestCard", "Testing Purposes Only", "This card is here for testing and only for testing.", new UnityEngine.Vector3(1, 2, 3), EElementIndex.Wind, EMonsterType.Alpha, EMonsterType.EX0Director, ERarity.Rare, new List<string> { EMonsterRole.PhysicalAttacker.ToString() }, new Stats { HP = 100, Strength = 10, Magic = 15, Vitality = 20, Spirit = 5, Speed = 12, HP_LevelAdd = 5, Strength_LevelAdd = 2 }, new List<string> { ESkill.DoNothing.ToString() }, Path.Combine(DLLPath+ "/Art"));
        }
        
        public void AddCards(string CardSet, string ModPrefix, string CardName, string Artist, string Description, UnityEngine.Vector3 effectAmount, EElementIndex element, EMonsterType nextEvolution, EMonsterType previousEvolution, ERarity rarity, List<string> role, Stats stats, List<string> Skills, string ImagePath)
        {
            Logger.LogInfo($"I Have seen {ModPrefix}_{CardName}");
            MonsterData Card = CardHandler.AddNewCard(CardSet, ModPrefix, CardName, Artist, Description, effectAmount, element, nextEvolution, previousEvolution, rarity, role, stats, Skills, ImagePath);
        }

        // Other methods can go here
    }
}