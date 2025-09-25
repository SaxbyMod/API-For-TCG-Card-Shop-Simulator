using System.Collections.Generic;
using System.Runtime.CompilerServices.Objects;

namespace List_Definer.Objects
{
	public class EarlySetData
	{
		public string SetName { get; set; }
		public string SetDescription { get; set; }
		public List<EarlyCardData> Cards { get; set; }
		
		public EarlySetData(string prefix, string name, string description) {
			SetName = prefix + ":" + name;
			SetDescription = description;
			Cards = new List<EarlyCardData>();
		}
	}
}