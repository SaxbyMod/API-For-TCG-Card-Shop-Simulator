using List_Definer.Objects;
using System.Collections.Generic;
using System.IO;

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
			string path = ListDefinerBase.DLLPath + "..\\..\\..\\config\\ListDefiner\\Sets.apidat";
			string dir = Path.GetDirectoryName(path);
			
			if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			// Refactor later to allow custom set object types
			var Sets = new StreamWriter(path, false);
			Sets.WriteLine("Sets [");
			foreach (EarlySetData set in sets)
			{
				Sets.WriteLine($"    \"{set.SetName}\" [");
				Sets.WriteLine($"""
								        Description [
								            {set.SetDescription}
								        ] 
								""");
				Sets.WriteLine("        CardsList [");
				foreach (EarlyCardData card in set.Cards)
				{
					Sets.WriteLine($"            \"{set.SetName}|{card.CardName}\" [");
					Sets.WriteLine($"                Roles [");
					foreach (EMonsterRole role in card.Roles)
					{
						Sets.WriteLine($"                    {role.ToString()}");
					}
					Sets.WriteLine($"                ]");
					Sets.WriteLine($"                Skills [");
					foreach (ESkill skill in card.Skills)
					{
						Sets.WriteLine($"                    {skill.ToString()}");
					}
					Sets.WriteLine($"                ]");
					Sets.WriteLine($"""
					                                Artist [
					                                    {card.ArtistName}
					                                ]
					                                Description [
					                                    {card.Description}
					                                ]
					                                EffectAmount [
					                                    {card.EffectAmount.x}
					                                    {card.EffectAmount.y}
					                                    {card.EffectAmount.z}
					                                ]
					                                Element [
					                                    {card.Element.ToString()}
					                                ]
					                                Rarity [
					                                    {card.Rarity.ToString()}
					                                ]
					                                NextForm [
					                                    {card.Next}
					                                ]
					                                PreviousForm [
					                                    {card.Previous}
					                                ]
					                                Stats [
					                                    BaseStats [
					                """);
					foreach (int stat in card.BaseStats)
					{
						Sets.WriteLine($"                        {stat}");
					}
					Sets.WriteLine($"                    ]");
					Sets.WriteLine("                    ModifiedStats [");
					foreach (int stat in card.ModifiedStats)
					{
						Sets.WriteLine($"                        {stat}");
					}
					Sets.WriteLine($"                    ]");
					Sets.WriteLine("                ]");
					Sets.WriteLine("                IconPath [");
					Sets.WriteLine($"                    {card.IconPath}");
					Sets.WriteLine("                ]");
					Sets.WriteLine("                GhostIconPath [");
					Sets.WriteLine($"                    {card.GhostIconPath}");
					Sets.WriteLine("                ]");
					Sets.WriteLine("            ]");
				}
				Sets.WriteLine("        ]");
				Sets.WriteLine("    ]");
			}
			Sets.WriteLine("]");
			Sets.Close();
		}
	}
}