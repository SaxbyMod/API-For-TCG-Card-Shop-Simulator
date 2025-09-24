using List_Definer.Util;
using System.IO;
using System.Reflection;

namespace System.Runtime.CompilerServices
{
	public class ListDefinerBase
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		
		public static void Awake()
		{
			StructSetup.AddStarterSets();
			// Fill Base Data Points;
		}
	}
}