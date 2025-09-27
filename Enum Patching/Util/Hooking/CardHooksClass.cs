using Enum_Patcher;
using Enum_Patching.Helpers.Enum_Helpers;
using Mono.Cecil;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enum_Patching.Util
{
	public class CardHooksClass
	{
		public static async Task CardHooks(TypeDefinition type, Dictionary<string, int> cards)
		{
			while (List_Definer.Util.CheckIfAllKeysHaveLoaded.AreThereUnfinishedMods())
			{
				if (List_Definer.Util.CheckIfAllKeysHaveLoaded.AreThereUnfinishedMods() == false)
				{
					KeyValuePair<string, int> previousKVP = new KeyValuePair<string, int>();
					foreach (KeyValuePair<string, int> kvp in cards)
					{
						if (kvp.Value == 100000)
						{
							CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, "MAX_CATJOB", EnumPatcher.Initial, 100000 - 1);
							CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, EnumPatcher.Initial, kvp.Key, 100000);
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