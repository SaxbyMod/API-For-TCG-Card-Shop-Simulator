using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    [HarmonyPatch(typeof(MonsterData_ScriptableObject))]
    internal class AddCardPatch
    {
        private static CardHandler cardHandler = new CardHandler(); // Correct instantiation

        [HarmonyPrefix]
        public static string GetMonsterDataPrefix(ref string monsterType)
        {
            // Loop through each card in CardsTotal
            for (int i = 0; i < cardHandler.CardsTotal.Count; i++)
            {
                // Compare the current card with the provided monsterType
                if (cardHandler.CardsTotal[i] == monsterType)
                {
                    return cardHandler.CardsTotal[i]; // Return the matched string
                }
            }
            // Return the first card if no match is found, or null if the list is empty
            return cardHandler.CardsTotal.Count > 0 ? cardHandler.CardsTotal[0] : null;
        }
    }

    [HarmonyPatch(typeof(InventoryBase))]
    internal class ModifyInvBasePatch
    {
        [HarmonyPrefix]
        public static MonsterData GetMonsterDataPrefix(ref EMonsterType monsterType)
        {
            CardHandler cardHandler = new CardHandler(); // Correct instantiation
            int TetraMonInsert = cardHandler.CardsTotal.IndexOf("MAX");
            int MegabotInsert = cardHandler.CardsTotal.IndexOf("MAX_MEGABOT");
            int FantasyRPGInsert = cardHandler.CardsTotal.IndexOf("MAX_FANTASYRPG");
            int CatJobInsert = cardHandler.CardsTotal.IndexOf("MAX_CATJOB");

            // Check for invalid monsterType
            if (monsterType == 0)
            {
                return null; // Consider returning a default MonsterData if applicable
            }

            // Use explicit casting to compare enum with int
            if ((int)monsterType < TetraMonInsert)
            {
                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList, monsterType);
            }

            if ((int)monsterType > MegabotInsert && (int)monsterType < (int)EMonsterType.MAX_MEGABOT)
            {
                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_MegabotDataList, monsterType);
            }

            if ((int)monsterType > FantasyRPGInsert && (int)monsterType < (int)EMonsterType.MAX_FANTASYRPG)
            {
                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_FantasyRPGDataList, monsterType);
            }

            if ((int)monsterType == CatJobInsert && (int)monsterType < (int)EMonsterType.MAX_CATJOB)
            {
                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_CatJobDataList, monsterType);
            }

            // Default return
            return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList[(int)monsterType];
        }
        // ToDO: Add Art stuff as well as the other elements of the MonsterData classes.
    }
}