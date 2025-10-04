using API.Objects;
using System.Collections.Generic;
using System.Linq;

namespace API.Util
{
	public class GetSetLists
	{
		public static List<PostSetData> FinalizedSets(List<FinalSetData> sets, List<ECardExpansionType> expansionTypes, List<EMonsterType> monsterTypes)
		{
			List<PostSetData> postSets = new List<PostSetData>();
			for (int i = 0; i < sets.Count; i++)
			{
				List<PostCardData> postCards = new List<PostCardData>();
				EMonsterType typeStart = monsterTypes.Where(type => type.ToString().Split("________")[1].Split("_____")[0] == sets[i].SetName).ToList()[0];
				EMonsterType typeEnd = (!monsterTypes.Where(type => type.ToString().Split("________")[1].Split("_____")[1] == sets[i].SetName).Any() ? monsterTypes.Where(type => type.ToString().Split("________")[1].Split("_____")[1] == sets[i].SetName) : monsterTypes.Where(type => type.ToString().Split("________")[1].Split("_____")[1] == "END")).ToList()[0];
				int Start = (int)typeStart;
				int End = (int)typeEnd;
				List<EMonsterType> typesToPassThrough = new List<EMonsterType>();
				int indexer = Start;
				foreach (EMonsterType type in monsterTypes)
				{
					if (Start < End && (int)type > Start)
					{
						typesToPassThrough.Add(type);
					}
					indexer++;
				}
				int Indexer = 0;
				foreach (EMonsterType type in typesToPassThrough)
				{
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