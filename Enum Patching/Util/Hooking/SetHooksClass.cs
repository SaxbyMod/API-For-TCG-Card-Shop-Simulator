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
				await Task.Delay(100);
			}

			KeyValuePair<string, int> previousKVP = new KeyValuePair<string, int>();
			foreach (KeyValuePair<string, int> kvp in sets)
			{
				if (kvp.Value == 50)
				{
						CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, "MAX", kvp.Key.Replace("-", "_____").Replace(":", "________"), 50);
				}
				else
				{
					CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, previousKVP.Key.Replace("-", "_____").Replace(":", "________"), kvp.Key.Replace("-", "_____").Replace(":", "________"), kvp.Value);
				}
				previousKVP = kvp;
			}
		}
	}
}