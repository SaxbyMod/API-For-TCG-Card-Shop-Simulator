using BepInEx.Logging;
using Enum_Patching.Util;
using List_Definer.Objects;
using Mono.Cecil;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enum_Patcher
{
	public class EnumPatcher
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		public static string Initial = "";
		public static ManualLogSource log = Logger.CreateLogSource("Patcher");
		public static Dictionary<int, MiddleSetData> cardExpansions = new Dictionary<int, MiddleSetData>();
		public static Dictionary<string, int> sets = new Dictionary<string, int>();
		public static Dictionary<string, int> cards = new Dictionary<string, int>();
		
		public static IEnumerable<string> TargetDLLs { get; } = ["Assembly-CSharp.dll"];

		public static void Patch(AssemblyDefinition assembly)
		{
			Task.Run(async () =>
			{
				Console.WriteLine("Patching the Lists from ListDefiner into the game");
				List<MiddleSetData> ReadInput = List_Definer.Util.StructReader.ReadCardStruct();

				var monsterType = assembly.MainModule.Types.First(Type => Type.Name == "EMonsterType");
				var cardExpansionType = assembly.MainModule.Types.First(Type => Type.Name == "ECardExpansionType");

				int iterator = 0;
				foreach (MiddleSetData data in ReadInput)
				{
					cardExpansions.Add(50 + iterator, data);
					iterator++;
				}
				int CurrentSeperator = 100000;
				Initial = $"Seperator:baseGame-{cardExpansions[50].SetName}";
				for (int iteratorNew = 0; iteratorNew < cardExpansions.Count; iteratorNew++)
				{
					sets.Add(cardExpansions[iteratorNew + 50].SetName, 50 + iteratorNew);

					foreach (MiddleCardData data in cardExpansions[iteratorNew + 50].Cards)
					{
						cards.Add(data.CardName, CurrentSeperator);
						CurrentSeperator += 1;
					}
					cards.Add($"Seperator:{cardExpansions[iteratorNew + 50].SetName}-{((iteratorNew + 1 + 1 > cardExpansions.Count) ? "END" : cardExpansions[iteratorNew + 50 + 1].SetName)}", CurrentSeperator);
					CurrentSeperator += 1;
				}

				await Task.WhenAll(
				CardHooksClass.CardHooks(monsterType, cards),
				SetHooksClass.SetHooks(cardExpansionType, sets)
				);
			}).Wait();
		}
	}
}