using API.Objects;
using System;

namespace API.Helpers.NodeHelpers
{
	public class PrintNodesClass
	{
		/// <summary>
		///This is for debug purposes, calling it prints out the entire tree.
		///While the parser is capable of parsing a file with multiple root nodes, this can only print trees with a single root node.
		///So in order for this to work you must use smth like Parent[0] instead of just passing in the list.
		/// </summary>
		/// <param name="node">The node in which to print from.</param>
		/// <param name="level">The depth into the tree which the print will begin with.</param>
		/// <returns>A printed output of the full tree starting at the node.</returns>
		/// This code is provided by the amazing `kesikek` on discord.
		public static void PrintNodes(Node node, int level)
		{
			Console.Write(new string('\t', level) + "⤷ ");

			if (node.Value != "")
			{
				System.Console.WriteLine($"{node.Value}");
			}
			else
			{
				System.Console.WriteLine("NULL");
			}

			if (node.Children != null)
			{
				foreach (Node child in node.Children)
				{
					PrintNodes(child, level + 1);
				}
			}
		}
	}
}