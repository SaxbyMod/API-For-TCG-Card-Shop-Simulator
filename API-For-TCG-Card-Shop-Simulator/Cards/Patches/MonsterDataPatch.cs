using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.UIElements.StyleVariableResolver;

namespace API_For_TCG_Card_Shop_Simulator.Cards.Patches
{
    [HarmonyPatch]
    internal class MonsterDataPatch
    {
        [HarmonyPrepare, HarmonyPatch(nameof(InventoryBase.GetMonsterDataMatchWithType), typeof(InventoryBase))]
        public static bool GetMonsterDataMatchWithTypeModified(Dictionary<int, CustomCard> listMonsterData, CustomCard monsterType, ref CustomCard __result)
        {
            if (listMonsterData == null)
            {
                UnityEngine.Debug.LogError("listMonsterData is null in GetMonsterDataMatchWithTypeModified.");
                __result = null;
                return false;
            }

            if (monsterType == null)
            {
                UnityEngine.Debug.LogError("monsterType is null in GetMonsterDataMatchWithTypeModified.");
                __result = null;
                return false;
            }

            for (int i = 0; i < listMonsterData.Count; i++)
            {
                if (listMonsterData[i] == monsterType)
                {
                    CustomCard customCard = listMonsterData[i];
                    __result = customCard;
                    return false;
                }
            }

            __result = null;
            return false;
        }


        [HarmonyPrefix, HarmonyPatch(nameof(InventoryBase.GetMonsterData), typeof(InventoryBase))]
        public static bool GetMonsterDataModified(int monsterType, ref CustomCard __result)
        {
            CustomCard result = null;
            if (monsterType == 0 || (monsterType >= (int)EnumListScript.MonsterMax["Tetramon"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["CatJob"]))
            {
                __result = null;
                return false;
            }
            if (monsterType < (int)EnumListScript.MonsterMax["Tetramon"])
            {
                GetMonsterDataMatchWithTypeModified(CardHandlingNew.ModdedMonsterData["Tetramon"], CardHandlingNew.ModdedMonsterData["Tetramon"][monsterType], ref result);
                __result = result;
                return false;
            }
            /*
            if (monsterType > (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                GetMonsterDataMatchWithTypeModified(CardHandlingNew.ModdedMonsterData["Megabot"], CardHandlingNew.ModdedMonsterData["Megabot"][monsterType], ref result);
                __result = result;
                return false;
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                GetMonsterDataMatchWithTypeModified(CardHandlingNew.ModdedMonsterData["FantasyRPG"], CardHandlingNew.ModdedMonsterData["FantasyRPG"][monsterType], ref result);
                __result = result;
                return false;
            }
            if (monsterType > (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["CatJob"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                GetMonsterDataMatchWithTypeModified(CardHandlingNew.ModdedMonsterData["CatJob"], CardHandlingNew.ModdedMonsterData["CatJob"][monsterType], ref result);
                __result = result;
                return false;
            }
            */
            GetMonsterDataModified(0, ref result);
            __result = result;
            return false;
        }
    }
}
