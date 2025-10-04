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
				await Task.Delay(100);
			}
			
			KeyValuePair<string, int> previousKVP = new KeyValuePair<string, int>();
			foreach (KeyValuePair<string, int> kvp in cards)
			{
				if (kvp.Value == 100000)
				{
					CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, "MAX_CATJOB", EnumPatcher.Initial.Replace("-", "_____").Replace(":", "________"), 100000 - 1);
					CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, EnumPatcher.Initial.Replace("-", "_____").Replace(":", "________"), kvp.Key.Replace("-", "_____").Replace(":", "________"), 100000);
					continue;
				}
				
				CloneAndAddEnumValueClass.CloneAndAddEnumValue(type, previousKVP.Key.Replace("-", "_____").Replace(":", "________"), kvp.Key.Replace("-", "_____").Replace(":", "________"), kvp.Value);
				previousKVP = kvp;
			}
			StructSetup.enumsToSave.Add("Cards", EnumPatcher.cards);
			StructSetup.SaveStructAfterRun();
		}
	}
}