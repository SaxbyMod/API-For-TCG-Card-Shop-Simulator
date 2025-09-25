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
				new Vector3(){x = 30, y=0, z=0}, 
				"Core_API:Burpig", 
				"", 
				new List<EMonsterRole>() {EMonsterRole.PhysicalAttacker}, 
				new List<ESkill>() {ESkill.FireClaw, ESkill.Sharpen, ESkill.None, ESkill.PoisonFang}, 
				// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
				new List<int>() {79, 34, 14, 25, 11, 20}, 
				new List<int>() {0, 0, 0, 0, 0, 0},
				ListDefinerBase.DLLPath + "\\..\\..\\..\\plugins\\CORE_API_TEAM-The_API_For_TCG_Card_Shop_Simulator"
				);
		}
	}
}