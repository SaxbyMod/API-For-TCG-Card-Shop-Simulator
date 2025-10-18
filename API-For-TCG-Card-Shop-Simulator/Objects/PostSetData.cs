using System.Collections.Generic;

namespace API.Objects
{
	public class PostSetData
	{
		public string SetName { get; set; }
		public string SetDescription { get; set; }
		public ECardExpansionType CardExpansion { get; set; }
		public List<EMonsterType> SetCardEnumerators { get; set; }
		public List<PostCardData> SetCardData { get; set; }

		public PostSetData(FinalSetData set, List<PostCardData> cardData, List<EMonsterType> cardEnumerators, ECardExpansionType expansion)
		{
			SetName = set.SetName;
			SetDescription = set.SetDescription;
			CardExpansion = expansion;
			SetCardEnumerators = cardEnumerators;
			SetCardData = cardData;
		}
	}
}