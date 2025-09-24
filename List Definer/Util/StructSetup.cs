using List_Definer.Objects;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.CompilerServices.Objects;
using System.Text;

namespace List_Definer.Util
{
	public class StructSetup
	{
		public static List<EarlySetData> sets = new List<EarlySetData>();

		public static void AddStarterSets()
		{
			EarlySetData tetramon = new EarlySetData("Core_API", "Tetramon", "The API's Set for tetramon, this can be modified by adding to this set.");
			EarlySetData destiny = new EarlySetData("Core_API", "Destiny", "The API's Set for destiny, this can be modified by adding to this set.");
			EarlySetData megabot = new EarlySetData("Core_API", "Megabot", "The API's Set for megabot, this can be modified by adding to this set.");
			EarlySetData fantasyrpg = new EarlySetData("Core_API", "FantasyRPG", "The API's Set for fantasyrpg, this can be modified by adding to this set.");
			EarlySetData catjob = new EarlySetData("Core_API", "CatJob", "The API's Set for catjob, this can be modified by adding to this set.");
			sets.Add(tetramon);
			sets.Add(destiny);
			sets.Add(megabot);
			sets.Add(fantasyrpg);
			sets.Add(catjob);
		}

		public static void SaveStructAfterRun()
		{
			var Sets = File.CreateText(ListDefinerBase.DLLPath + "..\\..\\Config\\ListDefiner\\Sets.apidat");
			Sets.WriteLine("Sets [");
			foreach (EarlySetData set in sets)
			{
				Sets.WriteLine($"\t\"{set.SetName}\" [");
				Sets.WriteLine($"""
								\t\tDescription [
								\t\t\t{set.SetDescription}
								\t\t] 
								""");
				Sets.WriteLine("\t\tCardsList [");
				foreach (EarlyCardData card in set.Cards)
				{
					Sets.WriteLine($"\t\t\t\"{card.CardName}\" [");
					Sets.WriteLine($"\t\t\t\tRoles [");
					foreach (EMonsterRole role in card.Roles)
					{
						Sets.WriteLine($"\t\t\t\t\t{role.ToString()}");
					}
					Sets.WriteLine($"\t\t\t\t]");
					Sets.WriteLine($"\t\t\t\tSkills [");
					foreach (ESkill skill in card.Skills)
					{
						Sets.WriteLine($"\t\t\t\t\t{skill.ToString()}");
					}
					Sets.WriteLine($"\t\t\t\t]");
					Sets.WriteLine($"""
					                \t\t\t\tArtist [
					                \t\t\t\t\t{card.ArtistName}
					                \t\t\t\t]
					                \t\t\t\tDescription [
					                \t\t\t\t\t{card.Description}
					                \t\t\t\t]
					                \t\t\t\tEffectAmount [
					                \t\t\t\t\t{card.EffectAmount.x}
					                \t\t\t\t\t{card.EffectAmount.y}
					                \t\t\t\t\t{card.EffectAmount.z}
					                \t\t\t\t]
					                \t\t\t\tElement [
					                \t\t\t\t\t{card.Element}
					                \t\t\t\t]
					                \t\t\t\tRarity [
					                \t\t\t\t\t{card.Rarity}
					                \t\t\t\t]
					                \t\t\t\tNextForm [
					                \t\t\t\t\t{card.Next}
					                \t\t\t\t]
					                \t\t\t\tPreviousForm [
					                \t\t\t\t\t{card.Previous}
					                \t\t\t\t]
					                \t\t\t\tStats [
					                \t\t\t\t\tBaseStats [
					                """);
					foreach (int stat in card.BaseStats)
					{
						Sets.WriteLine($"\t\t\t\t\t\t{stat}");
					}
					Sets.WriteLine($"\t\t\t\t\t]");
					Sets.WriteLine("\t\t\t\t\tModifiedStats [");
					foreach (int stat in card.ModifiedStats)
					{
						Sets.WriteLine($"\t\t\t\t\t\t{stat}");
					}
					Sets.WriteLine($"\t\t\t\t\t]");
					Sets.WriteLine("\t\t\t\t]");
					Sets.WriteLine("\t\t\t\tIconPath [");
					Sets.WriteLine($"\t\t\t\t\t{card.IconPath}");
					Sets.WriteLine("\t\t\t\t]");
					Sets.WriteLine("\t\t\t\tGhostIconPath [");
					Sets.WriteLine($"\t\t\t\t\t{card.GhostIconPath}");
					Sets.WriteLine("\t\t\t\t]");
					Sets.WriteLine("\t\t\t]");
				}
				Sets.WriteLine("\t\t]");
				Sets.WriteLine("\t]");
			}
			Sets.WriteLine("]");
		}
	}
}