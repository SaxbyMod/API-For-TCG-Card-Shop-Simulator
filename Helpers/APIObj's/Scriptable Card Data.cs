using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using System.Collections.Generic;
using UnityEngine;
namespace API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s
{
    public class Scriptable_Card_Data
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
        public List<Color> m_RarityColor;
        public List<Sprite> m_CardBorderList;
        public List<Sprite> m_CardBGList;
        public List<Sprite> m_CardFrontImageList;
        public List<Sprite> m_CardBackImageList;
        public List<Sprite> m_CardFoilMaskImageList;
        public List<CardUISetting> m_CardUISettingList;
        public List<Sprite> m_TetramonImageList;
        public List<MonsterData> m_SpecialCardImageList;
        
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
        // Color Funcs
        public Color GetRarityColor(ERarity rarity) => this.m_RarityColor[(int) rarity];
        // Sprite Funcs
        public Sprite GetCardBorderSprite(ERarity rarity) => this.m_CardBorderList[(int) rarity];
        public Sprite GetCardBGSprite(EElementIndex element)
        {
            return element == EElementIndex.None ? (Sprite) null : this.m_CardBGList[(int) element];
        }
        public Sprite GetCardFrontSprite(EElementIndex elementIndex)
        {
            return this.m_CardFrontImageList[(int) elementIndex];
        }
        public Sprite GetCardBackSprite(ECardExpansionType cardExpansionType)
        {
            return this.m_CardBackImageList[(int) cardExpansionType];
        }
        public Sprite GetCardFoilMaskSprite(ECardExpansionType cardExpansionType)
        {
            return this.m_CardFoilMaskImageList[(int) cardExpansionType];
        }
    }
}