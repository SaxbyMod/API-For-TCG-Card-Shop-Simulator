using API_For_TCG_Card_Shop_Simulator.Scripts;
using System;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/*
namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    internal class Inventory_Base_Patches
    {
        [HarmonyPatch(typeof(InventoryBase))]
        internal class ModifyInvBasePatch
        {
            [HarmonyPrefix]
            public static MonsterData GetMonsterDataPrefix(ref EMonsterType monsterType)
            {
                EnumListScript enumListScript = new EnumListScript(); // Correct instantiation
                int TetraMonInsert = enumListScript.CardsTotal.IndexOf("MAX");
                int MegabotInsert = enumListScript.CardsTotal.IndexOf("MAX_MEGABOT");
                int FantasyRPGInsert = enumListScript.CardsTotal.IndexOf("MAX_FANTASYRPG");
                int CatJobInsert = enumListScript.CardsTotal.IndexOf("MAX_CATJOB");

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
        }
    }
}
*/