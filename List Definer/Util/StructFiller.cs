using List_Definer.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace List_Definer.Util
{
	public class StructFiller
	{
		public static void AddSetToStruct(string prefix, string name, string description)
		{
			EarlySetData set = new EarlySetData(prefix, name, description);
			StructSetup.sets.Add(set);
		}
		
		public static void AddCardToStruct(string prefix, string name, string set, string artistName, string description, string rarity, string element, List<int> effectAmount, string next, string previous, List<string> roles, List<string> skills, List<int> baseStats, List<int> modifiedStats, string pathStart)
		{
			EarlyCardData data = new EarlyCardData(prefix, name, set, artistName, description, rarity, element, effectAmount, next, previous, roles, skills, baseStats, modifiedStats, pathStart);
			StructSetup.sets.Find(setData => setData.SetName == (set)).Cards.Add(data);
			StructSetup.SaveStructAfterRun();
		}
	}
}