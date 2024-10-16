using HarmonyLib;
using TCGShopNewCardsModPreloader.Handlers;

namespace TCGShopNewCardsMod.Patches
{
    [HarmonyPatch]
    internal class MonsterDataPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(InventoryBase), "GetMonsterData")]
        public static bool GetMonsterData(EMonsterType monsterType, ref MonsterData __result)
        {
            if (monsterType == EMonsterType.None)
            {
                __result = null;
                return false;
            }
            if (monsterType < (EMonsterType)CustomMonsterHandler.tetramonMax)
            {
                __result = InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList, monsterType);
                return false;
            }
            if (monsterType > (EMonsterType)CustomMonsterHandler.tetramonMax && monsterType < (EMonsterType)CustomMonsterHandler.megabotMax)
            {
                __result = InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_MegabotDataList, monsterType);
                return false;
            }
            if (monsterType > (EMonsterType)CustomMonsterHandler.megabotMax && monsterType < (EMonsterType)CustomMonsterHandler.fantasyRPGMax)
            {
                __result = InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_FantasyRPGDataList, monsterType);
                return false;
            }
            if (monsterType > (EMonsterType)CustomMonsterHandler.fantasyRPGMax && monsterType < (EMonsterType)CustomMonsterHandler.catJobMax)
            {
                __result = InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_CatJobDataList, monsterType);
                return false;
            }
            __result = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList[(int)monsterType];
            return false;
        }
    }
}
