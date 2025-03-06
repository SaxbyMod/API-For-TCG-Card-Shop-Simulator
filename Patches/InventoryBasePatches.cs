using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    [HarmonyPatch]
    public class InventoryBasePatches
    {
        public static List<MonsterType.ECatJobType> CatJobList = new List<MonsterType.ECatJobType>();
        public static List<MonsterType.EFantasyRPGType> FantasyRPGList = new List<MonsterType.EFantasyRPGType>();
        public static List<MonsterType.EMegaBotType> MegaBotList = new List<MonsterType.EMegaBotType>();
        public static List<MonsterType.EMonsterTypeLocal> MonsterTypeList = new List<MonsterType.EMonsterTypeLocal>();
        public static List<MonsterType.EMonsterTypeLocal> GhostList = new List<MonsterType.EMonsterTypeLocal>();
        
        [HarmonyPrefix, HarmonyPatch(typeof(InventoryBase), nameof(InventoryBase.GetShownMonsterList))]
        public static bool GetShownMonsterList(ECardExpansionType expansionType)
        {
            switch (expansionType)
            {
                case ECardExpansionType.Tetramon:
                case ECardExpansionType.Destiny:
                    MonsterTypeList = Scriptable_Card_Data.CreateInstance<Scriptable_Card_Data>().m_ShownMonsterList;
                    return false;
                case ECardExpansionType.Ghost:
                    GhostList = Scriptable_Card_Data.CreateInstance<Scriptable_Card_Data>().m_ShownGhostMonsterList;
                    return false;
                case ECardExpansionType.Megabot:
                    MegaBotList = Scriptable_Card_Data.CreateInstance<Scriptable_Card_Data>().m_ShownMegabotList;
                    return false;
                case ECardExpansionType.FantasyRPG:
                    FantasyRPGList = Scriptable_Card_Data.CreateInstance<Scriptable_Card_Data>().m_ShownFantasyRPGList;
                    return false;
                case ECardExpansionType.CatJob:
                    CatJobList = Scriptable_Card_Data.CreateInstance<Scriptable_Card_Data>().m_ShownCatJobList;
                    return false;
                default:
                    MonsterTypeList = Scriptable_Card_Data.CreateInstance<Scriptable_Card_Data>().m_ShownMonsterList;
                    return false;
            }
        }

        public class DataHandlers
        {
            // Tetramon Data Handling
            public static TetramonCards GetTetramonData(MonsterType.EMonsterTypeLocal monsterType)
            {
                if ((int)monsterType < CardHandlingNew.TetraIterator && monsterType != MonsterType.EMonsterTypeLocal.None)
                    return GetTetramonDataMatchWithType(CardHandlingNew.TetramonCards, monsterType);
                return (TetramonCards)null;
            }

            public static TetramonCards GetTetramonDataMatchWithType(List<TetramonCards> listMonsterData, MonsterType.EMonsterTypeLocal monsterType)
            {
                for (int index = 0; index < listMonsterData.Count; ++index)
                {
                    if (listMonsterData[index].MonsterType == monsterType)
                        return listMonsterData[index];
                }
                return (TetramonCards)null;
            }

            // Megabot Data Handling
            public static MegabotCards GetMegabotData(MonsterType.EMegaBotType monsterType)
            {
                if ((int)monsterType < CardHandlingNew.TetraIterator && monsterType != MonsterType.EMegaBotType.None)
                    return GetMegabotDataMatchWithType(CardHandlingNew.MegaBotCards, monsterType);
                return (MegabotCards)null;
            }

            public static MegabotCards GetMegabotDataMatchWithType(List<MegabotCards> listMonsterData, MonsterType.EMegaBotType monsterType)
            {
                for (int index = 0; index < listMonsterData.Count; ++index)
                {
                    if (listMonsterData[index].MonsterType == monsterType)
                        return listMonsterData[index];
                }
                return (MegabotCards)null;
            }

            // FantasyRPG Data Handling
            public static FantasyRPGCards GetFantasyRPGData(MonsterType.EFantasyRPGType monsterType)
            {
                if ((int)monsterType < CardHandlingNew.TetraIterator && monsterType != MonsterType.EFantasyRPGType.None)
                    return GetFantasyRPGDataMatchWithType(CardHandlingNew.FantasyRPGCards, monsterType);
                return (FantasyRPGCards)null;
            }

            public static FantasyRPGCards GetFantasyRPGDataMatchWithType(List<FantasyRPGCards> listMonsterData, MonsterType.EFantasyRPGType monsterType)
            {
                for (int index = 0; index < listMonsterData.Count; ++index)
                {
                    if (listMonsterData[index].MonsterType == monsterType)
                        return listMonsterData[index];
                }
                return (FantasyRPGCards)null;
            }

            // CatJob Data Handling
            public static CatJobCards GetCatJobData(MonsterType.ECatJobType monsterType)
            {
                if ((int)monsterType < CardHandlingNew.TetraIterator && monsterType != MonsterType.ECatJobType.None)
                    return GetCatJobDataMatchWithType(CardHandlingNew.CatJobCards, monsterType);
                return (CatJobCards)null;
            }

            public static CatJobCards GetCatJobDataMatchWithType(List<CatJobCards> listMonsterData, MonsterType.ECatJobType monsterType)
            {
                for (int index = 0; index < listMonsterData.Count; ++index)
                {
                    if (listMonsterData[index].MonsterType == monsterType)
                        return listMonsterData[index];
                }
                return (CatJobCards)null;
            }

            // TO DO FOR SPRITEs
             public static Sprite GetAncientArtifactSpriteTetra(MonsterType.EMonsterTypeLocal monsterType) => (Sprite) null;
             public static Sprite GetMonsterGhostIconSpriteTetra(MonsterType.EMonsterTypeLocal monsterType) => (Sprite) null;
             public static Sprite GetTetramonIconSpriteTetra(MonsterType.EMonsterTypeLocal monsterType)
             {
                 return monsterType == MonsterType.EMonsterTypeLocal.None ? (Sprite) null : CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_TetramonImageList[(int)monsterType % CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_TetramonImageList.Count];
             }
             public static Sprite GetSpecialCardImageTetra(MonsterType.EMonsterTypeLocal monsterType) {
                 if (monsterType == MonsterType.EMonsterTypeLocal.None)
                     return (Sprite) null;
                 for (int index = 0; index < CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_SpecialCardImageList.Count; ++index) {
                     if (Scripted_Card_Setup.data.m_ShownMonsterList[index] == monsterType)
                         return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_SpecialCardImageList[index].GetIcon(ECardExpansionType.None);
                 }
                 return (Sprite) null;
             }
        }
    }
}