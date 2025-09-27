using System.Collections.Generic;

namespace List_Definer.Util
{
	public class AddKeyClass
	{
		public static List<string> startkeys = new List<string>();
		public static List<string> finishedKeys = new List<string>();

		public static void AddKeyStart(string key)
		{
			startkeys.Add(key);
		}
		
		public static void MarkKeyFinished(string key)
		{
			finishedKeys.Add(key);
		}
	}
}