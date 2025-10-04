using API.Objects;
using API.Util;
using API.Util.StructReaders;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace API
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        public static Harmony harmony = new(PluginGuid);
        public static ManualLogSource Log = new ManualLogSource(PluginName);
        
        public static Assembly assembly = Assembly.GetExecutingAssembly();
        public static string DLLPath = Path.GetDirectoryName(assembly.Location);

        // These are variables that exist everywhere in the entire class.
        public const string PluginGuid = "creator.TheAPI";
        public const string PluginName = "The API for TCG Card Shop Simulator";
        public const string PluginVersion = "1.0.0";
        public const string PluginPrefix = "TheAPI";

        // Configs:
        public static ConfigEntry<bool> VerboseLogging;

        public void Awake()
        {
            Logger.LogDebug(string.Join("\n", Enum.GetNames(typeof(EMonsterType))));
            Logger.LogDebug(string.Join("\n", Enum.GetNames(typeof(ECardExpansionType))));
            List<FinalSetData> sets = SetStructClass.ReadCardStruct();
            List<ECardExpansionType> expansionTypes = SetEnumStructClass.ReadEnumStruct();
            List<EMonsterType> monsterTypes = CardEnumStructClass.ReadEnumStruct();
            List<PostSetData> postSets = GetSetLists.FinalizedSets(sets, expansionTypes, monsterTypes);
        }
    }
}