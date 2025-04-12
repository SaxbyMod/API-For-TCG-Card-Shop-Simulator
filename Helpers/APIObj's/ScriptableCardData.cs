using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using HarmonyLib;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s
{
	[HarmonyPatch]
    public class ScriptableCardData : MonsterData_ScriptableObject
    {
        // Tetramon
        public TetramonCards GetTetramonCards(string monsterType)
        {
            for (int index = 0; index < CardHandlingNew.DataList.Count; ++index)
            {
                if (CardHandlingNew.DataList[index].MonsterType.ToString() == monsterType)
                    return CardHandlingNew.DataList[index];
            }
            return CardHandlingNew.DataList[0];
        }
    }
}