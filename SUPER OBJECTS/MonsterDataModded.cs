using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects
{
    public class MonsterDataModded
    {
        public string Set { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public Sprite Icon { get; set; }
        public Sprite GhostIcon { get; set; }
        public string NextEvolution { get; set; }
        public string PreviousEvolution { get; set; }
        public ERarity Rarity { get; set; }
        public string Element { get; set; }
        public string Role { get; set; }
        public List<string> Skills { get; set; }
        public int HP { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int Vitality { get; set; }
        public int Spirit { get; set; }
        public int Speed { get; set; }
        public int ID { get; set; }

        public MonsterDataModded(string set, string prefix, string name, string artistname, string description, Sprite icon, Sprite ghosticon, string nextevolution, string previousevolution, ERarity rarity, string element, string role, List<string> skills, int hp, int strength, int magic, int vitality, int spirit, int speed, int id)
        {
            Set = set;
            Prefix = prefix;
            Name = name;
            ArtistName = artistname;
            Description = description;
            Icon = icon;
            GhostIcon = ghosticon;
            NextEvolution = nextevolution;
            PreviousEvolution = previousevolution;
            Rarity = rarity;
            Element = element;
            Role = role;
            Skills = skills;
            HP = hp;
            Strength = strength;
            Magic = magic;
            Vitality = vitality;
            Spirit = spirit;
            Speed = speed;
            ID = id;
        }
    };
}
