using API.Helpers.Images;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace API.Objects
{
	public class FinalCardData
	{
		public string CardName { get; set; }
		public string ArtistName { get; set; }
		public string Description { get; set; }
		public ERarity Rarity { get; set; }
		public EElementIndex Element { get; set; }
		public Vector3 EffectAmount { get; set; }
		public EMonsterType Next { get; set; }
		public EMonsterType Previous { get; set; }
		public List<EMonsterRole> Roles { get; set; }
		public List<ESkill> Skills { get; set; }
		public Sprite IconPath { get; set; }
		public Sprite GhostIconPath { get; set; }
		public Stats CardStats { get; set; }

		public FinalCardData(string cardName, string artistName, string description, string rarity, string element, List<int> effectAmount, string next, string previous, List<string> roles, List<string> skills, List<int> baseStats, List<int> modifiedStats, string iconPath, string ghostIconPath)
		{
			CardName = cardName;
			ArtistName = artistName;
			Description = description;
			Rarity = Enum.Parse<ERarity>(rarity);
			Element = Enum.Parse<EElementIndex>(element);
			EffectAmount = new Vector3(x: effectAmount[0], y: effectAmount[1], z: effectAmount[2]);
			Next = Enum.Parse<EMonsterType>(next.Replace(":", "________"));
			Previous = Enum.Parse<EMonsterType>(previous.Replace(":", "________"));
			List<EMonsterRole> NewRoles = new List<EMonsterRole>();
			foreach (string Role in roles)
			{
				NewRoles.Add(Enum.Parse<EMonsterRole>(Role));
			}
			Roles = NewRoles;
			List<ESkill> NewSkills = new List<ESkill>();
			foreach (string Skill in skills)
			{
				NewSkills.Add(Enum.Parse<ESkill>(Skill));
			}
			Skills = NewSkills;
			IconPath = GetCustomImageClass.GetCustomImage(cardName.Split(':')[1], iconPath);
			GhostIconPath = GetCustomImageClass.GetCustomImage(cardName.Split(':')[1], ghostIconPath);
			// Order; HP, STRENGTH, MAGIC, VITALITY, SPIRIT, SPEED
			CardStats = new Stats()
			{
				HP = baseStats[0],
				HP_LevelAdd = modifiedStats[0],
				Strength = baseStats[1],
				Strength_LevelAdd = modifiedStats[1],
				Magic = baseStats[2],
				Magic_LevelAdd = modifiedStats[2],
				Vitality = baseStats[3],
				Vitality_LevelAdd = modifiedStats[3],
				Spirit = baseStats[4],
				Spirit_LevelAdd = modifiedStats[4],
				Speed = baseStats[5],
				Speed_LevelAdd = modifiedStats[5],
			};
		}
	}
}