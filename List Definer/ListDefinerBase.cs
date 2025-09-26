using AnsiConsolePlugin.Util;
using List_Definer.Recreation;
using List_Definer.Util;
using Mono.Cecil;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace List_Definer
{
	public class ListDefinerBase
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		
		public static IEnumerable<string> TargetDLLs { get; } = ["Assembly-CSharp.dll"];
		public static void Initialize()
		{
			Console.WriteLine(GetColorFromTypeFunctions.GetColorFromString("Yellow", "Italic") + "Initializing ListDefiner" + ANSICodeLists.ResetColor);
			StructSetup.AddStarterSets();
			Tetramon.CreateBaseTetramon();
			StructSetup.SaveStructAfterRun();
			var Return = StructReader.ReadCardStruct();
			// Fill Base Data Points;
		}

		public static void Patch(AssemblyDefinition assembly)
		{
		}
	}
}