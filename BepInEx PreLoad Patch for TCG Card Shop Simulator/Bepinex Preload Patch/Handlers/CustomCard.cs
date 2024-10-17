using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;

namespace TCGShopNewCardsModPreloader.Handlers
{
    public class CustomCard
    {
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
        public int HP { get; set; }
        public int HPLevelAdd { get; set; }
        public int Magic { get; set; }
        public int MagicLevelAdd { get; set; }
        public int Speed { get; set; }
        public int SpeedLevelAdd { get; set; }
        public int Sprit { get; set; }
        public int SpritLevelAdd { get; set; }
        public int Strength { get; set; }
        public int StrengthLevelAdd { get; set; }

    }
}
