using List_Definer.Objects;
using System.Collections.Generic;

namespace List_Definer.Helpers.NodeHelpers
{
	public class GetNodesClass
	{
		/// <summary>
		///This takes in the tree and returns the value of a node inside it.
		///The formatting looks like this: Path/To/Node, This/Has/"\Apostrophes\".
		///This will return the values of nodes directly under the last supplied one in the path.
		///So for example Path/To/Node will get all values under "Node".
		///If your value has apostrophes in it you must use \" to write them out.
		/// </summary>
		/// <param name="tree">The tree of nodes in which nodes will be fetched from.</param>
		/// <param name="path">The path into the tree in which to find and return nodes from.</param>
		/// <returns>A selection of nodes from the tree following the path.</returns>
		/// This code is provided by the amazing `kesikek` on discord.
		public static string[] GetNodes(List<Node> tree, string path)
		{
			string[] output = [];
			string nextNode = path.Split('/')[0];

			for (int i = 0; i < tree.Count; i++)
			{
				if (tree[i].Value == nextNode)
				{
					if (path.Contains("/"))
					{
						output = GetNodes(tree[i].Children, path.Substring(nextNode.Length + 1));
					}
					else
					{
						List<string> values = new List<string>();

						for (int j = 0; j < tree[i].Children.Count; j++)
						{
							values.Add(tree[i].Children[j].Value);
						}

						output = values.ToArray();
						return output;
					}
				}
			}

			return output;
		}
	}
}