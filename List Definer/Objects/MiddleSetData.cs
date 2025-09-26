using System.Collections.Generic;

namespace List_Definer.Objects
{
	public class MiddleSetData
	{
		public string SetName { get; set; }
		public string SetDescription { get; set; }
		public List<MiddleCardData> Cards { get; set; }
		
		public MiddleSetData(string setName, string description,  List<MiddleCardData> cards) {
			SetName = setName;
			SetDescription = description;
			Cards = cards;
		}
	}
}