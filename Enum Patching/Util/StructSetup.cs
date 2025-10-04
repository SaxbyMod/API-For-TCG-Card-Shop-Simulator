using Enum_Patcher;
using System.Collections.Generic;
using System.IO;

namespace Enum_Patching.Util
{
	public class StructSetup
	{
		public static Dictionary<string, Dictionary<string,int>> enumsToSave = new Dictionary<string, Dictionary<string,int>>();
		public static void SaveStructAfterRun()
		{
			string path = EnumPatcher.DLLPath + "..\\..\\..\\config\\EnumPatcher\\Enums.apidat";
			string dir = Path.GetDirectoryName(path);
			
			if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			// Refactor later to allow custom set object types
			var Enums = new StreamWriter(path, false);
			Enums.WriteLine("Enums [");
			foreach (string type in enumsToSave.Keys)
			{
				Enums.WriteLine($"    \"{type}\" [");
				foreach (KeyValuePair<string,int> enumType in enumsToSave[type])
				{
					Enums.WriteLine($"        {enumType.Key.Replace("-", "_____").Replace(":", "________")} = {enumType.Value}");
				}
				Enums.WriteLine("    ]⇵");
			}
			Enums.WriteLine("]⇵");
			Enums.Close();
		}
	}
}