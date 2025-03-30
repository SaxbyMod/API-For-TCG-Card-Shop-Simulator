using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
	[HarmonyPatch]
	public class InventoryBasePatches
	{
		[HarmonyPatch(nameof(InventoryBase.GetMonsterData), typeof(InventoryBase)), HarmonyPrefix]
		public static bool GetMonsterData(EMonsterType monsterType, ref MonsterData __result)
		{
			MonsterType.EMonsterTypeLocal type = MonsterTypetoLocalMonsterType(monsterType);
			if (monsterType == EMonsterType.None || monsterType >= EMonsterType.MAX && monsterType < EMonsterType.Alpha)
			{
				__result = (MonsterData)null;
				return false;
			}
			if (monsterType < EMonsterType.MAX)
			{
				__result = GetTetramonDataMatchWithType(Scriptable_Card_Data.m_DataList, type);
				return false;
			}
			if (monsterType > EMonsterType.MAX && monsterType < EMonsterType.MAX_MEGABOT)
			{
				__result = GetMegabotDataMatchWithType(Scriptable_Card_Data.m_MegabotDataList, type);
				return false;
			}
			if (monsterType > EMonsterType.MAX_MEGABOT && monsterType < EMonsterType.MAX_FANTASYRPG)
			{
				__result = GetFantasyRPGDataMatchWithType(Scriptable_Card_Data.m_FantasyRPGDataList, type);
				return false;
			}
			__result = monsterType > EMonsterType.MAX_FANTASYRPG && monsterType < EMonsterType.MAX_CATJOB ? GetCatJobDataMatchWithType(Scriptable_Card_Data.m_CatJobDataList, type) : Scriptable_Card_Data.m_DataList[(int)type];
			return false;
		}
		
		public static MonsterType.EMonsterTypeLocal MonsterTypetoLocalMonsterType(EMonsterType type)
		{
			foreach (var Name in Enum.GetValues(typeof(MonsterType.EMonsterTypeLocal)))
			{
				if (Name == type.ToString())
				{
					var newName = Enum.Parse<MonsterType.EMonsterTypeLocal>(Name.ToString(), true);
					return newName;
				}
			}
			return MonsterType.EMonsterTypeLocal.None;
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

		public static MegabotCards GetMegabotDataMatchWithType(List<MegabotCards> listMonsterData, MonsterType.EMonsterTypeLocal monsterType)
		{
			for (int index = 0; index < listMonsterData.Count; ++index)
			{
				if (listMonsterData[index].MonsterType == monsterType)
					return listMonsterData[index];
			}
			return (MegabotCards)null;
		}

		public static FantasyRPGCards GetFantasyRPGDataMatchWithType(List<FantasyRPGCards> listMonsterData, MonsterType.EMonsterTypeLocal monsterType)
		{
			for (int index = 0; index < listMonsterData.Count; ++index)
			{
				if (listMonsterData[index].MonsterType == monsterType)
					return listMonsterData[index];
			}
			return (FantasyRPGCards)null;
		}

		public static CatJobCards GetCatJobDataMatchWithType(List<CatJobCards> listMonsterData, MonsterType.EMonsterTypeLocal monsterType)
		{
			for (int index = 0; index < listMonsterData.Count; ++index)
			{
				if (listMonsterData[index].MonsterType == monsterType)
					return listMonsterData[index];
			}
			return (CatJobCards)null;
		}
	}
}