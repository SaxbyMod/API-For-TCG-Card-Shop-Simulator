using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.Cards.Patches
{
    [HarmonyPatch]
    internal class MonsterDataPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(InventoryBase), "GetMonsterDataMatchWithType")]
        public static CustomCard GetMonsterDataMatchWithType(List<CustomCard> listMonsterData, CustomCard monsterType)
        {
            for (int i = 0; i < listMonsterData.Count; i++)
            {
                if (listMonsterData[i] == monsterType)
                {
                    return listMonsterData[i];
                }
            }
            return null;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(InventoryBase), "GetMonsterData")]
        public static CustomCard GetMonsterData(int monsterType)
        {
            if (monsterType == 0 || (monsterType >= (int)EnumListScript.MonsterMax["Tetramon"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["CatJob"]))
            {
                return null;
            }
            if (monsterType < (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetMonsterDataMatchWithType(CardHandlingNew.ModdedMonsterData["Tetramon"], CardHandlingNew.ModdedMonsterData["Tetramon"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetMonsterDataMatchWithType(CardHandlingNew.ModdedMonsterData["Megabot"], CardHandlingNew.ModdedMonsterData["Megabot"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetMonsterDataMatchWithType(CardHandlingNew.ModdedMonsterData["FantasyRPG"], CardHandlingNew.ModdedMonsterData["FantasyRPG"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["CatJob"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetMonsterDataMatchWithType(CardHandlingNew.ModdedMonsterData["CatJob"], CardHandlingNew.ModdedMonsterData["CatJob"][monsterType]);
            }
            return GetMonsterData(0);
        }
    }
}
