using BepInEx;
using API.Helpers.NodeHelpers;
using API.Objects;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Util.StructReaders
{
	public static class CardEnumStructClass
	{
		public static List<EMonsterType> ReadEnumStruct()
		{
			List<EMonsterType> cards = new List<EMonsterType>();

			string path = API.Plugin.DLLPath + "..\\..\\..\\config\\ListDefiner\\Sets.apidat";

			if (!File.Exists(path))
				return cards;

			string[] file = File.ReadAllLines(path);
            
			List<Node> Tree = ParseClass.Parse(file);
            
			string[] setNodes = GetNodesClass.GetNodes(Tree, "Enums");

			foreach (string item in setNodes)
			{
				string[] setInformationNodes = GetNodesClass.GetNodes(Tree, $"Enums/\"Cards\"");
				foreach (string jtem in setInformationNodes)
				{
					cards.Add(Enum.Parse<EMonsterType>(jtem.Split("=")[0].TrimEnd()));
				}
			}

			return cards;
		}
	}
}