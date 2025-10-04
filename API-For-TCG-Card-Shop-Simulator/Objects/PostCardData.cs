using System.Collections.Generic;
using UnityEngine;

namespace API.Objects
{
	public class PostCardData
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
		public EMonsterType MonsterType { get; set; }

		public PostCardData(FinalCardData card, EMonsterType monsterType)
		{
			CardName = card.CardName;
			ArtistName = card.ArtistName;
			Description = card.Description;
			Rarity = card.Rarity;
			Element = card.Element;
			EffectAmount = card.EffectAmount;
			Next = card.Next;
			Previous = card.Previous;
			Roles = card.Roles;
			Skills = card.Skills;
			IconPath = card.IconPath;
			GhostIconPath = card.GhostIconPath;
			CardStats = card.CardStats;
			MonsterType = monsterType;
		}
	}
}