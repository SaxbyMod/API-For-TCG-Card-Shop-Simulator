using System.Collections.Generic;

namespace API.Objects
{
	public class FinalSetData
	{
		public string SetName { get; set; }
		public string SetDescription { get; set; }
		public List<FinalCardData> Cards { get; set; }
		
		public FinalSetData(string setName, string description,  List<FinalCardData> cards) {
			SetName = setName;
			SetDescription = description;
			Cards = cards;
		}
	}
}