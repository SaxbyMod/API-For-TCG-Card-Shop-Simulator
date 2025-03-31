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
        
        [HarmonyPatch(typeof(MonsterData_ScriptableObject), nameof(MonsterData_ScriptableObject.GetMonsterData)), HarmonyPrefix]
        public static bool GetMonsterData(string monsterType, ref MonsterData __result)
        {
	        for (int index = 0; index < CardHandlingNew.DataList.Count; ++index)
	        {
		        if (CardHandlingNew.DataList[index].MonsterType.ToString() == monsterType)
		        {
			        __result = CardHandlingNew.DataList[index];
			        return false;
		        }
	        }
	        __result = CardHandlingNew.DataList[0];
	        return false;
        }
    }
}