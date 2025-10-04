using System.Collections.Generic;

namespace API.Objects
{
	/// <summary>
	/// This is simply the definition of a node in which is utilized within the Helper/NodeHelpers classes.
	/// </summary>
	/// This code is provided by the amazing `kesikek` on discord.
	public class Node
	{
		public string Value { get; set; } = "";
		public List<Node> Children { get; set; } = new List<Node>();
	}
}