using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace List_Definer.Objects
{
	public class EarlyCardData
	{
		public string CardName { get; set; }
		public string ArtistName { get; set; }
		public string Description { get; set; }
		public string Rarity { get; set; }
		public string Element { get; set; }
		public List<int> EffectAmount { get; set; }
		public string Next { get; set; }
		public string Previous { get; set; }
		public List<string> Roles { get; set; }
		public List<string> Skills { get; set; }
		public string IconPath { get; set; }
		public string GhostIconPath { get; set; }
		public List<int> BaseStats { get; set; }
		public List<int> ModifiedStats { get; set; }
		
		public EarlyCardData(string prefix, string name, string set, string artistName, string description, string rarity, string element, List<int> effectAmount, string next, string previous, List<string> roles,  List<string> skills, List<int> baseStats, List<int> modifiedStats, string pathStart) {
			CardName = prefix + ":" + name;
			ArtistName = artistName;
			Description = description;
			Rarity = rarity;
			Element = element;
			EffectAmount = effectAmount;
			Next = next;
			Previous = previous;
			Roles = roles;
			Skills = skills;
			IconPath = Path.GetFullPath(pathStart + $"\\{(prefix.Equals("") ? prefix : "BaseAssets")}\\{set}\\");
			GhostIconPath = Path.GetFullPath(pathStart + $"\\{(prefix.Equals("") ? prefix : "BaseAssets")}\\{set}\\Ghost\\");
			BaseStats = baseStats;
			ModifiedStats = modifiedStats;
		}
	}
}