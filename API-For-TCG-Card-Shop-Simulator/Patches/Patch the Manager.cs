using API_For_TCG_Card_Shop_Simulator.Scripts;
using System;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using I2.Loc;
/*
namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    internal class Patch_the_Manager
    {
        [HarmonyPatch(typeof(MonsterData))]
        public class MonsterData
        {
            public string GetName()
            {
                return LocalizationManager.GetTranslation(this.Name, true, 0, true, false, null, null, true);
            }
            public string GetArtistName()
            {
                return "Illus. " + this.ArtistName;
            }
            public string GetDescription()
            {
                if (this.Description == "")
                {
                    return LocalizationManager.GetTranslation("No effect", true, 0, true, false, null, null, true);
                }
                return LocalizationManager.GetTranslation(this.Description, true, 0, true, false, null, null, true).Replace("XXX", this.EffectAmount.x.ToString()).Replace("YYY", this.EffectAmount.y.ToString()).Replace("ZZZ", this.EffectAmount.z.ToString());
            }
            public string GetRarityName()
            {
                return LocalizationManager.GetTranslation(this.Rarity.ToString(), true, 0, true, false, null, null, true);
            }
            public string GetElementName()
            {
                return LocalizationManager.GetTranslation(this.ElementIndex.ToString(), true, 0, true, false, null, null, true);
            }
            public string GetRoleName()
            {
                string text = "";
                string result = "";
                for (int i = 0; i < this.Roles.Count; i++)
                {
                    if (i > 0)
                    {
                        text += ", ";
                    }
                    string translation = LocalizationManager.GetTranslation(this.Roles[i].ToString(), true, 0, true, false, null, null, true);
                    if (this.Roles[i] == EMonsterRole.AllRounder)
                    {
                        translation = LocalizationManager.GetTranslation("All Rounder", true, 0, true, false, null, null, true);
                    }
                    else if (this.Roles[i] == EMonsterRole.MagicalAttacker)
                    {
                        translation = LocalizationManager.GetTranslation("Magical Attacker", true, 0, true, false, null, null, true);
                    }
                    else if (this.Roles[i] == EMonsterRole.PhysicalAttacker)
                    {
                        translation = LocalizationManager.GetTranslation("Physical Attacker", true, 0, true, false, null, null, true);
                    }
                    text += translation;
                    if (i == 0)
                    {
                        result = translation;
                    }
                }
                if (text.Length > 27)
                {
                    return result;
                }
                return text;
            }
            public Sprite GetIcon(ECardExpansionType cardExpansionType)
            {
                if (cardExpansionType == ECardExpansionType.Ghost)
                {
                    return this.GhostIcon;
                }
                if (!(this.Icon == null))
                {
                    return this.Icon;
                }
                if (cardExpansionType == ECardExpansionType.None)
                {
                    return LoadStreamTexture.GetImage("Special_" + this.MonsterType.ToString());
                }
                return LoadStreamTexture.GetImage(cardExpansionType.ToString() + "_" + this.MonsterType.ToString());
            }
            public string Name;
            public string ArtistName;
            public string Description;
            public Vector3 EffectAmount;
            public EElementIndex ElementIndex;
            public ERarity Rarity;
            public EMonsterType MonsterType;
            public EMonsterType NextEvolution;
            public EMonsterType PreviousEvolution;
            public List<EMonsterRole> Roles;
            public Stats BaseStats;
            public List<ESkill> SkillList;
            public Sprite Icon;
            public Sprite GhostIcon;
        }
    }
}
*/