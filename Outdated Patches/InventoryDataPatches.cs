//using I2.Loc;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using UnityEngine;
//using HarmonyLib;

//namespace API_For_TCG_Card_Shop_Simulator.Patches
//{

//    internal class InventoryBasePatches
//    {
//        [HarmonyPatch(typeof(InventoryBase))]
//        public static List<EMonsterType> GetShownMonsterList(ECardExpansionType expansionType)
//        {
//            if (expansionType == ECardExpansionType.Tetramon || expansionType == ECardExpansionType.Destiny)
//            {
//                return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMonsterList;
//            }
//            if (expansionType == ECardExpansionType.Ghost)
//            {
//                return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownGhostMonsterList;
//            }
//            if (expansionType == ECardExpansionType.Megabot)
//            {
//                return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMegabotList;
//            }
//            if (expansionType == ECardExpansionType.FantasyRPG)
//            {
//                return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownFantasyRPGList;
//            }
//            if (expansionType == ECardExpansionType.CatJob)
//            {
//                return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownCatJobList;
//            }
//            return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMonsterList;
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        public static MonsterData GetMonsterData(EMonsterType monsterType)
//        {
//            if (monsterType == EMonsterType.None || (monsterType >= EMonsterType.MAX && monsterType < EMonsterType.Alpha))
//            {
//                return null;
//            }
//            if (monsterType < EMonsterType.MAX)
//            {
//                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList, monsterType);
//            }
//            if (monsterType > EMonsterType.MAX && monsterType < EMonsterType.MAX_MEGABOT)
//            {
//                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_MegabotDataList, monsterType);
//            }
//            if (monsterType > EMonsterType.MAX_MEGABOT && monsterType < EMonsterType.MAX_FANTASYRPG)
//            {
//                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_FantasyRPGDataList, monsterType);
//            }
//            if (monsterType > EMonsterType.MAX_FANTASYRPG && monsterType < EMonsterType.MAX_CATJOB)
//            {
//                return InventoryBase.GetMonsterDataMatchWithType(CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_CatJobDataList, monsterType);
//            }
//            return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList[(int)monsterType];
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        private static MonsterData GetMonsterDataMatchWithType(List<MonsterData> listMonsterData, EMonsterType monsterType)
//        {
//            for (int i = 0; i < listMonsterData.Count; i++)
//            {
//                if (listMonsterData[i].MonsterType == monsterType)
//                {
//                    return listMonsterData[i];
//                }
//            }
//            return null;
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        public static UnityEngine.Sprite GetTetramonIconSprite(EMonsterType monsterType)
//        {
//            if (monsterType == EMonsterType.None)
//            {
//                return null;
//            }
//            int index = (((int)monsterType) % (int)(EMonsterType)CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_TetramonImageList.Count);
//            return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_TetramonImageList[index];
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        public static UnityEngine.Sprite GetSpecialCardImage(EMonsterType monsterType)
//        {
//            if (monsterType == EMonsterType.None)
//            {
//                return null;
//            }
//            for (int i = 0; i < CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_SpecialCardImageList.Count; i++)
//            {
//                if (CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_SpecialCardImageList[i].MonsterType == monsterType)
//                {
//                    return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_SpecialCardImageList[i].GetIcon(ECardExpansionType.None);
//                }
//            }
//            return null;
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        public static ECardExpansionType GetCardExpansionType(ECollectionPackType collectionPackType)
//        {
//            if (collectionPackType == ECollectionPackType.BasicCardPack || collectionPackType == ECollectionPackType.RareCardPack || collectionPackType == ECollectionPackType.EpicCardPack || collectionPackType == ECollectionPackType.LegendaryCardPack)
//            {
//                return ECardExpansionType.Tetramon;
//            }
//            if (collectionPackType == ECollectionPackType.DestinyBasicCardPack || collectionPackType == ECollectionPackType.DestinyRareCardPack || collectionPackType == ECollectionPackType.DestinyEpicCardPack || collectionPackType == ECollectionPackType.DestinyLegendaryCardPack)
//            {
//                return ECardExpansionType.Destiny;
//            }
//            if (collectionPackType == ECollectionPackType.GhostPack)
//            {
//                return ECardExpansionType.Ghost;
//            }
//            if (collectionPackType == ECollectionPackType.MegabotPack)
//            {
//                return ECardExpansionType.Megabot;
//            }
//            if (collectionPackType == ECollectionPackType.FantasyRPGPack)
//            {
//                return ECardExpansionType.FantasyRPG;
//            }
//            if (collectionPackType == ECollectionPackType.CatJobPack)
//            {
//                return ECardExpansionType.CatJob;
//            }
//            return ECardExpansionType.None;
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        public static ECollectionPackType ItemTypeToCollectionPackType(EItemType itemType)
//        {
//            if (itemType == EItemType.BasicCardPack || itemType == EItemType.BasicCardBox)
//            {
//                return ECollectionPackType.BasicCardPack;
//            }
//            if (itemType == EItemType.RareCardPack || itemType == EItemType.RareCardBox)
//            {
//                return ECollectionPackType.RareCardPack;
//            }
//            if (itemType == EItemType.EpicCardPack || itemType == EItemType.EpicCardBox)
//            {
//                return ECollectionPackType.EpicCardPack;
//            }
//            if (itemType == EItemType.LegendaryCardPack || itemType == EItemType.LegendaryCardBox)
//            {
//                return ECollectionPackType.LegendaryCardPack;
//            }
//            if (itemType == EItemType.DestinyBasicCardPack || itemType == EItemType.DestinyBasicCardBox)
//            {
//                return ECollectionPackType.DestinyBasicCardPack;
//            }
//            if (itemType == EItemType.DestinyRareCardPack || itemType == EItemType.DestinyRareCardBox)
//            {
//                return ECollectionPackType.DestinyRareCardPack;
//            }
//            if (itemType == EItemType.DestinyEpicCardPack || itemType == EItemType.DestinyEpicCardBox)
//            {
//                return ECollectionPackType.DestinyEpicCardPack;
//            }
//            if (itemType == EItemType.DestinyLegendaryCardPack || itemType == EItemType.DestinyLegendaryCardBox)
//            {
//                return ECollectionPackType.DestinyLegendaryCardPack;
//            }
//            if (itemType == EItemType.GhostPack)
//            {
//                return ECollectionPackType.GhostPack;
//            }
//            if (itemType == EItemType.MegabotPack)
//            {
//                return ECollectionPackType.MegabotPack;
//            }
//            if (itemType == EItemType.FantasyRPGPack)
//            {
//                return ECollectionPackType.FantasyRPGPack;
//            }
//            if (itemType == EItemType.CatJobPack)
//            {
//                return ECollectionPackType.CatJobPack;
//            }
//            return ECollectionPackType.None;
//        }

//        [HarmonyPatch(typeof(InventoryBase))]
//        public static string GetCardExpansionName(ECardExpansionType cardExpansion)
//        {
//            return LocalizationManager.GetTranslation(CSingleton<InventoryBase>.Instance.m_TextSO.m_CardExpansionNameList[(int)cardExpansion], true, 0, true, false, null, null, true);
//        }

//        // Token: 0x0400036F RID: 879
//        public MonsterData_ScriptableObject m_MonsterData_SO;

//        // Token: 0x04000371 RID: 881
//        public Text_ScriptableObject m_TextSO;

//        // Token: 0x04000372 RID: 882
//        public static InventoryBase m_Instance;
//    }
//}
