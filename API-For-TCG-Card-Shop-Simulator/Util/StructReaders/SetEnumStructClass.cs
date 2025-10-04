using BepInEx;
using API.Helpers.NodeHelpers;
using API.Objects;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Util.StructReaders
{
    public static class SetEnumStructClass
    {
        public static List<ECardExpansionType> ReadEnumStruct()
        {
            List<ECardExpansionType> sets = new List<ECardExpansionType>();

            string path = API.Plugin.DLLPath + "..\\..\\..\\config\\ListDefiner\\Sets.apidat";

            if (!File.Exists(path))
                return sets;

            string[] file = File.ReadAllLines(path);
            
            List<Node> Tree = ParseClass.Parse(file);
            
            string[] setNodes = GetNodesClass.GetNodes(Tree, "Enums");

            foreach (string item in setNodes)
            {
                string[] setInformationNodes = GetNodesClass.GetNodes(Tree, $"Enums/\"Sets\"");
                foreach (string jtem in setInformationNodes)
                {
                    sets.Add(Enum.Parse<ECardExpansionType>(jtem.Split("=")[0].TrimEnd()));
                }
            }

            return sets;
        }
    }
}