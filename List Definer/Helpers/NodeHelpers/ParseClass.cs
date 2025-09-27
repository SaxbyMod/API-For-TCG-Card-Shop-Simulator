using List_Definer.Objects;
using System;
using System.Collections.Generic;

namespace List_Definer.Helpers.NodeHelpers
{
	public class ParseClass
	{
            
            public static int ParsingIterator = 0;
            
            /// <summary>
            ///This is the main function that converts the text file into the node tree.
            ///The node tree is several lists of nodes inside other nodes, making up a treebranch-like structure.
            ///A node has a "Value" variable, which contains the actual data we need.
            /// </summary>
            /// <param name="file">The file in which to parse the tree from.</param>
            /// <returns>The tree of nodes from the inputted 'apidat' file..</returns>
            /// This code is provided by the amazing `kesikek` on discord.
            public static List<Node> Parse(string[] file)
            {
                List<Node> nodes = new List<Node>();
                while (ParsingIterator < file.Length)
                {
                    string line = file[ParsingIterator];
                    Node cur = new Node();
                    cur.Value = line.Trim();

                    if (line.EndsWith("["))
                    {
                        ParsingIterator++;
                        cur.Value = line.Substring(0, line.Length - 2).Trim();
                        cur.Children = Parse(file);
                    }
                    else if (line.Contains("]"))
                    {
                        return nodes;
                    }

                    ParsingIterator++;

                    nodes.Add(cur);
                }

                return nodes;
            }

            
	}
}