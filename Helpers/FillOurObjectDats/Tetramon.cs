using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;

namespace API_For_TCG_Card_Shop_Simulator.Helpers.FillOurObjectDats
{
    // Card Handling Logic
    public class Tetramon
    {
        public static void CreateTetramon()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string DLLPath = Path.GetDirectoryName(assembly.Location);
            List<EMonsterRole> PiggyARoles = new List<EMonsterRole>()
            {
                EMonsterRole.PhysicalAttacker
            };
            Stats PiggyAStats = new Stats()
            {
                HP = 79,
                Strength = 34,
                Magic = 14,
                Vitality = 25,
                Spirit = 11,
                Speed = 20
            };
            List<ESkill> PiggyASkills = new List<ESkill>()
            {
                ESkill.FireClaw,
                ESkill.Sharpen,
                ESkill.None,
                ESkill.PoisonFang
            };
            CardHandlingNew.CreateTetramonCards("", "Pigni", "Hikoku", "Fire element deals XXX extra damage this turn", new Vector3(30,0,0), EElementIndex.Fire, ERarity.Common, MonsterType.EMonsterTypeLocal.PiggyA, MonsterType.EMonsterTypeLocal.PiggyB, MonsterType.EMonsterTypeLocal.None, PiggyARoles, PiggyAStats, PiggyASkills, DLLPath + "\\BaseAssets\\Tetramon\\PiggyA", DLLPath + "\\BaseAssets\\None");
        }
    }
}