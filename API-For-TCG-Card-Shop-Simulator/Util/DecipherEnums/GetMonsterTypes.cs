using System;
using System.Collections.Generic;

namespace API.Util.DecipherEnums
{
	public class GetMonsterTypes
	{
		public static List<EMonsterType> returnList ()
		{
			List<EMonsterType> returnList = new List<EMonsterType>();
			var enums = Enum.GetNames(typeof(EMonsterType));
			foreach (var name in enums)
				returnList.Add(Enum.Parse<EMonsterType>(name));
			return returnList;
		}
	}
}