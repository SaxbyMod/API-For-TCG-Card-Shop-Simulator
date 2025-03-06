using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;

namespace API_For_TCG_Card_Shop_Simulator.Cards {
    public static class Scripted_Card_Setup
    {
        public static Scriptable_Card_Data data = new Scriptable_Card_Data()
        {
            m_ShownMonsterList = MonsterType.TetramonEnumList,
            m_ShownGhostMonsterList = MonsterType.TetramonEnumList,
            m_ShownMegabotList = MonsterType.MegaBotEnumList,
            m_ShownFantasyRPGList = MonsterType.FantasyRPGEnumList,
            m_ShownCatJobList = MonsterType.CatJobEnumList,
            m_DataList = CardHandlingNew.TetramonCards,
            m_MegabotDataList = CardHandlingNew.MegaBotCards,
            m_FantasyRPGDataList = CardHandlingNew.FantasyRPGCards,
            m_CatJobDataList = CardHandlingNew.CatJobCards
        };
    }
}