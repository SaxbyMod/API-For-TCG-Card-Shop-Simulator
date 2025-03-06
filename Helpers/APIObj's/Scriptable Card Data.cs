using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s
{
    public class Scriptable_Card_Data : MonsterData_ScriptableObject
    {
        // Lists/WhatTheDataIS
        public List<MonsterType.EMonsterTypeLocal> m_ShownMonsterList;
        public List<MonsterType.EMonsterTypeLocal> m_ShownGhostMonsterList;
        public List<MonsterType.EMegaBotType> m_ShownMegabotList;
        public List<MonsterType.EFantasyRPGType> m_ShownFantasyRPGList;
        public List<MonsterType.ECatJobType> m_ShownCatJobList;
        public List<TetramonCards> m_DataList;
        public List<MegabotCards> m_MegabotDataList;
        public List<FantasyRPGCards> m_FantasyRPGDataList;
        public List<CatJobCards> m_CatJobDataList;
        
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
        // Megabot
        public MegabotCards GetMegabotCards(string monsterType)
        {
            for (int index = 0; index < m_MegabotDataList.Count; ++index)
            {
                if (m_MegabotDataList[index].MonsterType.ToString() == monsterType)
                    return m_MegabotDataList[index];
            }
            return m_MegabotDataList[0];
        }
        // FantasyRPG
        public FantasyRPGCards GetFantasyRpgCards(string monsterType)
        {
            for (int index = 0; index < m_FantasyRPGDataList.Count; ++index)
            {
                if (m_FantasyRPGDataList[index].MonsterType.ToString() == monsterType)
                    return m_FantasyRPGDataList[index];
            }
            return m_FantasyRPGDataList[0];
        }
        // CatJob
        public CatJobCards GetCatJobCards(string monsterType)
        {
            for (int index = 0; index < m_CatJobDataList.Count; ++index)
            {
                if (m_CatJobDataList[index].MonsterType.ToString() == monsterType)
                    return m_CatJobDataList[index];
            }
            return m_CatJobDataList[0];
        }
    }
}