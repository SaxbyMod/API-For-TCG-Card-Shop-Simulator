using System.Collections.Generic;
using UnityEngine;

namespace System.Runtime.CompilerServices.Objects
{
	public class EarlyCardData
	{
		public string CardName { get; set; }
		public string ArtistName { get; set; }
		public string Description { get; set; }
		public ERarity Rarity { get; set; }
		public EElementIndex Element { get; set; }
		public Vector3 EffectAmount { get; set; }
		public string Next { get; set; }
		public string Previous { get; set; }
		public List<EMonsterRole> Roles { get; set; }
		public List<ESkill> Skills { get; set; }
		public string IconPath { get; set; }
		public string GhostIconPath { get; set; }
		public List<int> BaseStats { get; set; }
		public List<int> ModifiedStats { get; set; }
		
		public EarlyCardData(string prefix, string name, string set, string artistName, string description, ERarity rarity, EElementIndex element, Vector3 effectAmount, string next, string previous, List<EMonsterRole> roles,  List<ESkill> skills, List<int> baseStats, List<int> modifiedStats, string pathStart) {
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
			IconPath = pathStart + $"\\{(prefix.Equals("") ? prefix : "BaseAssets")}\\{set}\\";
			GhostIconPath = pathStart + $"\\{(prefix.Equals("") ? prefix : "BaseAssets")}\\{set}\\Ghost\\";
			BaseStats = baseStats;
			ModifiedStats = modifiedStats;
		}
	}
}