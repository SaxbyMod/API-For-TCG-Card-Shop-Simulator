namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    internal class MonsterDataPatches
    {
        /*
        using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

// Token: 0x02000041 RID: 65
[Serializable]
    public class MonsterData
    {
        // Token: 0x0600030F RID: 783 RVA: 0x0001D65C File Offset: 0x0001B85C
        public string GetName()
        {
            return LocalizationManager.GetTranslation(this.Name, true, 0, true, false, null, null, true);
        }

        // Token: 0x06000310 RID: 784 RVA: 0x0001D670 File Offset: 0x0001B870
        public string GetArtistName()
        {
            return "Illus. " + this.ArtistName;
        }

        // Token: 0x06000311 RID: 785 RVA: 0x0001D684 File Offset: 0x0001B884
        public string GetDescription()
        {
            if (this.Description == "")
            {
                return LocalizationManager.GetTranslation("No effect", true, 0, true, false, null, null, true);
            }
            return LocalizationManager.GetTranslation(this.Description, true, 0, true, false, null, null, true).Replace("XXX", this.EffectAmount.x.ToString()).Replace("YYY", this.EffectAmount.y.ToString()).Replace("ZZZ", this.EffectAmount.z.ToString());
        }

        // Token: 0x06000312 RID: 786 RVA: 0x0001D715 File Offset: 0x0001B915
        public string GetRarityName()
        {
            return LocalizationManager.GetTranslation(this.Rarity.ToString(), true, 0, true, false, null, null, true);
        }

        // Token: 0x06000313 RID: 787 RVA: 0x0001D734 File Offset: 0x0001B934
        public string GetElementName()
        {
            return LocalizationManager.GetTranslation(this.ElementIndex.ToString(), true, 0, true, false, null, null, true);
        }

        // Token: 0x06000314 RID: 788 RVA: 0x0001D754 File Offset: 0x0001B954
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

        // Token: 0x06000315 RID: 789 RVA: 0x0001D844 File Offset: 0x0001BA44
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

        // Token: 0x040003D2 RID: 978
        public string Name;

        // Token: 0x040003D3 RID: 979
        public string ArtistName;

        // Token: 0x040003D4 RID: 980
        public string Description;

        // Token: 0x040003D5 RID: 981
        public Vector3 EffectAmount;

        // Token: 0x040003D6 RID: 982
        public EElementIndex ElementIndex;

        // Token: 0x040003D7 RID: 983
        public ERarity Rarity;

        // Token: 0x040003D8 RID: 984
        public EMonsterType MonsterType;

        // Token: 0x040003D9 RID: 985
        public EMonsterType NextEvolution;

        // Token: 0x040003DA RID: 986
        public EMonsterType PreviousEvolution;

        // Token: 0x040003DB RID: 987
        public List<EMonsterRole> Roles;

        // Token: 0x040003DC RID: 988
        public Stats BaseStats;

        // Token: 0x040003DD RID: 989
        public List<ESkill> SkillList;

        // Token: 0x040003DE RID: 990
        public Sprite Icon;

        // Token: 0x040003DF RID: 991
        public Sprite GhostIcon;
    }
*/
    }
}
