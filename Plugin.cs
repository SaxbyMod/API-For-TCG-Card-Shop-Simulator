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
            cardHandler.AddCardsToPool("MyPrefix", "TestCard", Path.Combine(DLLPath+ "/Art"), "Tetramon");
        }

        public static void AddCards(string Prefix, string Name, string ImagePath, string Set)
        {
            cardHandler.AddCardsToPool(Prefix, Name, ImagePath, Set);
        }

        // Other methods can go here
    }
}