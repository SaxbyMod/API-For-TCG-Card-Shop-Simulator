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
			Console.WriteLine("Initializing ListDefiner");
			StructSetup.AddStarterSets();
			// Fill Base Data Points;
			Tetramon.CreateBaseTetramon();
			StructSetup.SaveStructAfterRun();
		}

		public static void Patch(AssemblyDefinition assembly)
		{
		}
	}
}