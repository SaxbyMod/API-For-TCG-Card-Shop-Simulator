using System.Collections.Generic;
using System.Linq;

namespace API.Helpers.Pathing
{
	public class HandleAPIPathingClass
	{
		/// <summary>
		/// Takes a path passed in and replaces when we are allowed to the ':' seperators with '(' and finishes the segment with a ')'.
		/// </summary>
		/// <param name="fullPath">The full path that we will parse.</param>
		/// <returns>A Formatted Valid path.</returns>
		/// This code is provided by the amazing thincreator3483 on discord, SaxbyMod on Github, and Creator on Thunderstore.
		public static string HandleAPIPathing(string fullPath)
		{
			List<string> pathSegments = fullPath.Split('\\').ToList();
			bool canWeStartReplacing = false;
			List<string> newPathSegments = new List<string>();
			foreach (string segment in pathSegments)
			{
				string newSegment = segment;
				if (segment == "BaseAssets" || segment == "ModdedAssets")
				{
					canWeStartReplacing = true;
				}
				if (canWeStartReplacing)
				{
					if (segment.Contains(':'))
					{
						newSegment = segment.Replace(':', '(') + ")";
					}
				}
				newPathSegments.Add(newSegment);
			}
			string outputString = "";
			foreach (string segment in newPathSegments)
			{
				outputString += segment + "\\";
			}
			outputString = outputString.Replace("\\\\", "\\");
			return outputString;
		}
	}
}