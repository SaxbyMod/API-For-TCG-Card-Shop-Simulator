using System.Collections.Generic;
using UnityEngine;

namespace List_Definer.Objects
{
	public class MiddleCardData
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
		
		public MiddleCardData(string cardName, string artistName, string description, ERarity rarity, EElementIndex element, Vector3 effectAmount, string next, string previous, List<EMonsterRole> roles,  List<ESkill> skills, List<int> baseStats, List<int> modifiedStats, string iconPath, string ghostIconPath) {
			CardName = cardName;
			ArtistName = artistName;
			Description = description;
			Rarity = rarity;
			Element = element;
			EffectAmount = effectAmount;
			Next = next;
			Previous = previous;
			Roles = roles;
			Skills = skills;
			IconPath = iconPath;
			GhostIconPath = ghostIconPath;
			BaseStats = baseStats;
			ModifiedStats = modifiedStats;
		}
	}
}