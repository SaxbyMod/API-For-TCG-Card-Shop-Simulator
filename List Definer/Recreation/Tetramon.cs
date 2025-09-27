using List_Definer.Util;
using System.Collections.Generic;
using UnityEngine;

namespace List_Definer.Recreation
{
	public class Tetramon
	{
		public static void CreateBaseTetramon()
		{
			StructFiller.AddCardToStruct(
				"Core_API",
				"Pigni",
				"Core_API:Tetramon",
				"Hikoku",
				"Fire element deals XXX extra damage this turn",
				ERarity.Common,
				EElementIndex.Fire,
				new Vector3() { x = 30, y = 0, z = 0 },
				"Core_API:Burpig",
				"",
				new List<EMonsterRole>() { EMonsterRole.PhysicalAttacker },
				new List<ESkill>() { ESkill.FireClaw, ESkill.Sharpen, ESkill.None, ESkill.PoisonFang },
				// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
				new List<int>() { 79, 34, 14, 25, 11, 20 },
				new List<int>() { 0, 0, 0, 0, 0, 0 },
				ListDefinerBase.DLLPath + "\\..\\..\\..\\plugins\\CORE_API_TEAM-The_API_For_TCG_Card_Shop_Simulator"
			);
			StructFiller.AddCardToStruct(
				"Core_API",
				"Burpig",
				"Core_API:Tetramon",
				"Hikoku",
				"Fire element deals XXX extra damage this turn",
				ERarity.Rare,
				EElementIndex.Fire,
				new Vector3() { x = 60, y = 0, z = 0 },
				"Core_API:Inferhog",
				"Core_API:Pigni",
				new List<EMonsterRole>() { EMonsterRole.PhysicalAttacker },
				new List<ESkill>() { ESkill.BlazingClaw, ESkill.Sharpen, ESkill.None, ESkill.PoisonFang },
				// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
				new List<int>() { 81, 35, 14, 25, 12, 18 },
				new List<int>() { 0, 0, 0, 0, 0, 0 },
				ListDefinerBase.DLLPath + "\\..\\..\\..\\plugins\\CORE_API_TEAM-The_API_For_TCG_Card_Shop_Simulator"
			);
			StructFiller.AddCardToStruct(
				"Core_API",
				"Inferhog",
				"Core_API:Tetramon",
				"Hikoku",
				"Fire element deals XXX extra damage this turn",
				ERarity.Epic,
				EElementIndex.Fire,
				new Vector3() { x = 100, y = 0, z = 0 },
				"Core_API:Blazoar",
				"Core_API:Burpig",
				new List<EMonsterRole>() { EMonsterRole.PhysicalAttacker },
				new List<ESkill>() { ESkill.InfernoClaw, ESkill.Sharpen, ESkill.None, ESkill.VenomFang },
				// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
				new List<int>() { 83, 36, 15, 26, 12, 17 },
				new List<int>() { 0, 0, 0, 0, 0, 0 },
				ListDefinerBase.DLLPath + "\\..\\..\\..\\plugins\\CORE_API_TEAM-The_API_For_TCG_Card_Shop_Simulator"
			);
			StructFiller.AddCardToStruct(
				"Core_API",
				"Blazoar",
				"Core_API:Tetramon",
				"Hikoku",
				"Fire element deals double damage this turn",
				ERarity.Epic,
				EElementIndex.Fire,
				new Vector3() { x = 2, y = 0, z = 0 },
				"",
				"Core_API:Inferhog",
				new List<EMonsterRole>() { EMonsterRole.PhysicalAttacker },
				new List<ESkill>() { ESkill.HellfireClaw, ESkill.Sharpen, ESkill.None, ESkill.VenomFang },
				// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
				new List<int>() { 85, 38, 15, 28, 12, 16 },
				new List<int>() { 0, 0, 0, 0, 0, 0 },
				ListDefinerBase.DLLPath + "\\..\\..\\..\\plugins\\CORE_API_TEAM-The_API_For_TCG_Card_Shop_Simulator"
			);
		}
	}
}