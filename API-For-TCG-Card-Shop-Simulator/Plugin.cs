using API_For_TCG_Card_Shop_Simulator.Scripts;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TCGShopNewCardsModPreloader.Handlers;

namespace API_For_TCG_Card_Shop_Simulator
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        readonly Harmony harmony = new(PluginGuid);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        // These are variables that exist everywhere in the entire class.
        public const string PluginGuid = "creator.TheAPI";
        public const string PluginName = "The API for TCG Card Shop Simulator";
        public const string PluginVersion = "1.0.0";
        public const string PluginPrefix = "TheAPI";

        // Corrected List initialization
        public List<string> CardsToAdd = new List<string>();
        public static MonsterData GetMonsterName (EMonsterType Name)
        {
            var InGameName = InventoryBase.GetMonsterData(Name);
            return InGameName;
        }
        // Static CardHandler instance
        //private static CardHandler cardHandler = new CardHandler();
        public void Awake()
        {
            // Removed 'public' keyword from here
            Assembly assembly = Assembly.GetExecutingAssembly();
            string DLLPath = Path.GetDirectoryName(assembly.Location);
            // Log Monster Name - ID - In Game Nmae
            Logger.LogDebug($"ID - ID Int - Monster Name");
            var monstertypename = EMonsterType.PiggyA;
            var monstertypeid = (int)EMonsterType.PiggyA;
            var Type = EMonsterType.PiggyA;
            var Name = GetMonsterName(Type);
            Logger.LogDebug($"{monstertypename} - {monstertypeid} - {Name}");

            // AddCards("Tetramon", "MyPrefix", "TestCard", "Testing Purposes Only", "This card is here for testing and only for testing.", new UnityEngine.Vector3(1, 2, 3), "Wind", "Alpha", "EX0Director", "Rare", new List<string> { EMonsterRole.PhysicalAttacker.ToString() }, new List<int> { 100, 10, 15, 20, 5, 12, 5, 2, 0, 0, 0, 0 }, new List<string> { ESkill.DoNothing.ToString() }, Path.Combine(DLLPath + $"\\Art"));
        }
        
        //public void AddCards(string CardSet, string ModPrefix, string CardName, string Artist, string Description, UnityEngine.Vector3 effectAmount, string element, string nextEvolution, string previousEvolution, string rarity, List<string> role, List<int> stats, List<string> Skills, string ImagePath)
        //{
        //    Logger.LogInfo($"I Have seen {ModPrefix}_{CardName}");
        //    Logger.LogInfo($"Test inputting a Card");
        //    CustomCard Card = CardHandler.AddNewCard(CardSet, ModPrefix, CardName, Artist, Description, effectAmount, element, nextEvolution, previousEvolution, rarity, role, stats, Skills, ImagePath);
        //}

        // Other methods can go here
    }
}