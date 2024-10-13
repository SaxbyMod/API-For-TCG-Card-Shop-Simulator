using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;

namespace The_Hex_Expansion
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]

    public class Plugin : BaseUnityPlugin
    {
        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        readonly Harmony harmony = new(PluginGuid);

        // These are variables that exist everywhere in the entire class.
        public const string PluginGuid = "creator.TheAPI";
        public const string PluginName = "The API for TCG Card Shop Simulator";
        public const string PluginVersion = "1.0.0";
        public const string PluginPrefix = "TheAPI";
        public List<string> CardsToAdd = [""];
        public void Awake()
        {
            
        }

        public static void AddCards(string Prefix, string Name, string ImagePath, string Set)
        {
            
        }

        // Methods
    }
}