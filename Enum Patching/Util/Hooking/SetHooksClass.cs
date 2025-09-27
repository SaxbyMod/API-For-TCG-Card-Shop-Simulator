using Enum_Patcher;
using Enum_Patching.Helpers.Enum_Helpers;
using Mono.Cecil;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enum_Patching.Util
{
	public class SetHooksClass
	{
		public static async Task SetHooks(TypeDefinition type, Dictionary<string, int> sets)
		{
			while (List_Definer.Util.CheckIfAllKeysHaveLoaded.AreThereUnfinishedMods())
			{
				if (List_Definer.Util.CheckIfAllKeysHaveLoaded.AreThereUnfinishedMods() == false)
				{
					KeyValuePair<string, int> previousKVP = new KeyValuePair<string, int>();
					foreach (KeyValuePair<string, int> kvp in sets)
					{
						if (kvp.Value == 50)
						{
							CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, "MAX", EnumPatcher.Initial, 50 - 1);
							CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, EnumPatcher.Initial, kvp.Key, 50);
							continue;
						}
						
						CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, previousKVP.Key, kvp.Key, kvp.Value);
						previousKVP = kvp;
					}
				}
			}
		}
	}
}