using API.Objects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace API.Util
{
	public class GetSetLists
	{
		public static List<PostSetData> FinalizedSets(List<FinalSetData> sets, List<ECardExpansionType> expansionTypes, List<EMonsterType> monsterTypes)
		{
			List<PostSetData> postSets = new List<PostSetData>();
			var separators = monsterTypes.Select(t => t.ToString()).Where(s => s.StartsWith("Seperator________")).ToList();
			for (int i = 0; i < sets.Count; i++)
			{
				List<PostCardData> postCards = new List<PostCardData>();
				string setName = sets[i].SetName.Replace(":", "________");
				string startSep = separators.FirstOrDefault(s => s.EndsWith($"_____{setName}"));
				string endSep = separators.FirstOrDefault(s => s.Contains($"{setName}_____"));

				if (startSep == null)
					startSep = separators.FirstOrDefault(s => s.Contains("baseGame_____"));
				if (endSep == null)
					endSep = separators.FirstOrDefault(s => s.Contains("_____END"));
				if (startSep == null || endSep == null)
				{
					Debug.LogError($"[GetSetLists] Could not find separators for set {setName}");
					continue;
				}
				
				Debug.Log($"[DEBUG] {setName} → StartSep={startSep} | EndSep={endSep}");

				EMonsterType typeStart = monsterTypes.First(t => t.ToString() == startSep);
				EMonsterType typeEnd = monsterTypes.First(t => t.ToString() == endSep);
				int Start = (int)typeStart;
				int End = (int)typeEnd;
				
				var typesToPassThrough = monsterTypes.Where(t => (int)t > Start && (int)t < End).ToList();
				
				int Indexer = 0;
				foreach (EMonsterType type in typesToPassThrough)
				{
					if (Indexer >= sets[i].Cards.Count) 
						break;
					FinalCardData card = sets[i].Cards[Indexer];
					PostCardData Postcard = new PostCardData(card, type);
					postCards.Add(Postcard);
					Indexer++;
				}
				PostSetData setData = new PostSetData(sets[i], postCards, typesToPassThrough, expansionTypes[i]);
				postSets.Add(setData);
			}
			return postSets;
		}
	}
}