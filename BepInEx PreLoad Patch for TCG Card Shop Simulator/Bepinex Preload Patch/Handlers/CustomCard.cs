using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;

namespace TCGShopNewCardsModPreloader.Handlers
{
    public class CustomCard
    {
        public EMonsterType MonsterTypeType { get; set; }
        public string Header { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public UnityEngine.Vector3 EffectAmount { get; set; }
        public string ElementIndex { get; set; }
        public Sprite Icon { get; set; }
        public Sprite GhostIcon { get; set; }
        public string MonsterType { get; set; }
        public int MonsterTypeID { get; set; }
        public string Name { get; set; }
        public string NextEvolution { get; set; }
        public string PreviousEvolution { get; set; }
        public string Rarity { get; set; }
        public List<String> Roles { get; set; }
        public List<String> Skills { get; set; }
        public Stats BaseStats { get; set; }
    }
}
