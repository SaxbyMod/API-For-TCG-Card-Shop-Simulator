namespace List_Definer.Util
{
	public class CheckIfAllKeysHaveLoaded
	{
		public static bool AreThereUnfinishedMods()
		{
			if (AddKeyClass.startkeys.Count == AddKeyClass.finishedKeys.Count)
			{
				return false;
			}
			return true;
		}
	}
}