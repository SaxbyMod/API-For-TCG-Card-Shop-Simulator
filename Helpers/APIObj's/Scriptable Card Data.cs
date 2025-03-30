using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using HarmonyLib;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s
{
	[HarmonyPatch]
    public class Scriptable_Card_Data : MonsterData_ScriptableObject
    {
        // Lists/WhatTheDataIS
        public List<MonsterType.EMonsterTypeLocal> m_ShownMonsterList;
        public List<MonsterType.EMonsterTypeLocal> m_ShownGhostMonsterList;
        public List<MonsterType.EMegaBotType> m_ShownMegabotList;
        public List<MonsterType.EFantasyRPGType> m_ShownFantasyRPGList;
        public List<MonsterType.ECatJobType> m_ShownCatJobList;
        public static List<TetramonCards> m_DataList;
        public static List<MegabotCards> m_MegabotDataList;
        public static List<FantasyRPGCards> m_FantasyRPGDataList;
        public static List<CatJobCards> m_CatJobDataList;
        
        // Tetramon
        public TetramonCards GetTetramonCards(string monsterType)
        {
            for (int index = 0; index < m_DataList.Count; ++index)
            {
                if (m_DataList[index].MonsterType.ToString() == monsterType)
                    return m_DataList[index];
            }
            return m_DataList[0];
        }
        
        [HarmonyPatch(typeof(MonsterData_ScriptableObject), nameof(MonsterData_ScriptableObject.GetMonsterData)), HarmonyPrefix]
        public static bool GetMonsterData(string monsterType, ref MonsterData __result)
        {
	        for (int index = 0; index < m_DataList.Count; ++index)
	        {
		        if (m_DataList[index].MonsterType.ToString() == monsterType)
		        {
			        __result = m_DataList[index];
			        return false;
		        }
	        }
	        __result = m_DataList[0];
	        return false;
        }
    }
}