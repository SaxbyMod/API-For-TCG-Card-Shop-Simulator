using System;
using System.Collections.Generic;

namespace API.Util.DecipherEnums
{
	public class GetCardExpansionTypes
	{
		public static List<ECardExpansionType> returnList()
		{
			List<ECardExpansionType> returnList = new List<ECardExpansionType>();
			var enums = Enum.GetNames(typeof(ECardExpansionType));
			foreach (var name in enums)
				returnList.Add(Enum.Parse<ECardExpansionType>(name));
			return returnList;
		}
	}
}