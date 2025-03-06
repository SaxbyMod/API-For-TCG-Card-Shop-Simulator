using System;
using UnityEngine;
using System.Collections.Generic;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;

namespace API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s
{
    public class TetramonCards : MonsterData
    {
        public string Name;
        public string ArtistName;
        public string Description;
        public Vector3 EffectAmount;
        public EElementIndex ElementIndex;
        public ERarity Rarity;
        public MonsterType.EMonsterTypeLocal MonsterType;
        public MonsterType.EMonsterTypeLocal NextEvolution;
        public MonsterType.EMonsterTypeLocal PreviousEvolution;
        public List<EMonsterRole> Roles;
        public Stats Stats;
        public List<ESkill> SkillList;
        public Sprite Icon;
        public Sprite GhostIcon;
    }
}