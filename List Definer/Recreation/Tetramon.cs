using List_Definer.Objects.UserReferenceLists;
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
				"Common",
				"Fire",
				new List<int>() { 30, 0, 0 },
				"Core_API:Burpig",
				"",
				new List<string>() { "PhysicalAttacker" },
				new List<string>() { "FireClaw", "Sharpen", "None", "PoisonFang" },
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
				Raritys.Rare.ToString(),
				Elements.Fire.ToString(),
				new List<int>() { 60, 0, 0 },
				"Core_API:Inferhog",
				"Core_API:Pigni",
				new List<string>() { Roles.PhysicalAttacker.ToString() },
				new List<string>() { Skills.BlazingClaw.ToString(), Skills.Sharpen.ToString(), Skills.None.ToString(), Skills.PoisonFang.ToString() },
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
				Raritys.Epic.ToString(),
				Elements.Fire.ToString(),
				new List<int>() { 100, 0, 0 },
				"Core_API:Blazoar",
				"Core_API:Burpig",
				new List<string>() { Roles.PhysicalAttacker.ToString() },
				new List<string>() { Skills.InfernoClaw.ToString(), Skills.Sharpen.ToString(), Skills.None.ToString(), Skills.VenomFang.ToString() },
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
				Raritys.Legendary.ToString(),
				Elements.Fire.ToString(),
				new List<int>() { 2, 0, 0 },
				"",
				"Core_API:Inferhog",
				new List<string>() { Roles.PhysicalAttacker.ToString() },
				new List<string>() { Skills.HellfireClaw.ToString(), Skills.Sharpen.ToString(), Skills.None.ToString(), Skills.VenomFang.ToString() },
				// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
				new List<int>() { 85, 38, 15, 28, 12, 16 },
				new List<int>() { 0, 0, 0, 0, 0, 0 },
				ListDefinerBase.DLLPath + "\\..\\..\\..\\plugins\\CORE_API_TEAM-The_API_For_TCG_Card_Shop_Simulator"
			);
		}
	}
}