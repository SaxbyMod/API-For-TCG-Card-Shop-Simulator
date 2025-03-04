using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Reflection;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using API_For_TCG_Card_Shop_Simulator.Helpers.FillOurObjectDats;

namespace API_For_TCG_Card_Shop_Simulator
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        public static Harmony harmony = new(PluginGuid);
        public static ManualLogSource Log = new(PluginName);

        // These are variables that exist everywhere in the entire class.
        public const string PluginGuid = "creator.TheAPI";
        public const string PluginName = "The API for TCG Card Shop Simulator";
        public const string PluginVersion = "1.0.0";
        public const string PluginPrefix = "TheAPI";

        // Configs:
        public static ConfigEntry<bool> VerboseLogging;

        public void Awake()
        {
            // Configs;
            VerboseLogging = Config.Bind<bool>("Content.Addition",
                        "Verbose Logging?",
                        false,
                        "Should Verbose Logging be enabled?");

            // Removed 'public' keyword from here
            Assembly assembly = Assembly.GetExecutingAssembly();
            string DLLPath = Path.GetDirectoryName(assembly.Location);
            MonsterType.CheckMonsterMaxes();
            Tetramon.CreateTetramon();
        }
    }
}