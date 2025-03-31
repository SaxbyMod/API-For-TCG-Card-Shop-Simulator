using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using HarmonyLib;
using System;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
	[HarmonyPatch]
	public class InventoryBasePatches
	{
		[HarmonyPatch(nameof(InventoryBase.GetMonsterData))]
		[HarmonyPrefix]
		public static bool GetMonsterData(EMonsterType monsterType, ref MonsterData __result)
		{
			if ((int)monsterType < 122)
			{
				__result = GetTetramonDataMatchWithType(CardHandlingNew.DataList, monsterType);
				return false;
			}
			if((int)monsterType >= 200000)
			{
				return false;
			}
			return true;
		}

		public static TetramonCards GetTetramonDataMatchWithType(List<TetramonCards> listMonsterData, EMonsterType monsterType)
		{
			var properEnum = MonsterType.EMonsterTypeLocal.None;
			foreach (string name in Enum.GetValues(typeof(MonsterType.EMonsterTypeLocal)))
			{
				if (name == monsterType.ToString())
				{
					properEnum = Enum.Parse<MonsterType.EMonsterTypeLocal>(name.ToString(), true);
					break;
				}
			}
			
			for (int index = 0; index < listMonsterData.Count; ++index)
			{
				if (listMonsterData[index].MonsterType == properEnum)
					return listMonsterData[index];
			}
			return null;
		}
	}
}