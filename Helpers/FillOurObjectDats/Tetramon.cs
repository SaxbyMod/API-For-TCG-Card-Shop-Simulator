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
            // Register all of our Tetramon
            CreateNone();
            CreatePigni();
            CreateBurpig();
            CreateInferhog();
            CreateBlazoar();
            CreateKidsune();
            CreateBonifox();
            
            // Add None to the Pool
            static void CreateNone()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string DLLPath = Path.GetDirectoryName(assembly.Location);
                List<EMonsterRole> NoneRoles = new List<EMonsterRole>()
                {
                    
                };
                Stats NoneStats = new Stats()
                {
                    HP = 0,
                    Strength = 0,
                    Magic = 0,
                    Vitality = 0,
                    Spirit = 0,
                    Speed = 0,
                    HP_LevelAdd = 0,
                    Strength_LevelAdd = 0,
                    Magic_LevelAdd = 0,
                    Vitality_LevelAdd = 0,
                    Spirit_LevelAdd = 0,
                    Speed_LevelAdd = 0
                };
                List<ESkill> NoneSkills = new List<ESkill>()
                {
	                
                };
                CardHandlingNew.CreateTetramonCards(
                    "",
                    "None",
                    "",
                    "",
                    new Vector3(0, 0, 0),
                    EElementIndex.None,
                    ERarity.Common,
                    MonsterType.EMonsterTypeLocal.None,
                    MonsterType.EMonsterTypeLocal.None,
                    MonsterType.EMonsterTypeLocal.None,
                    NoneRoles,
                    NoneStats,
                    NoneSkills,
                    DLLPath + "\\BaseAssets\\None",
                    DLLPath + "\\BaseAssets\\None"
                    );
            }
            
            // Add Pigni to the Pool
            static void CreatePigni()
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
                    Speed = 20,
                    HP_LevelAdd = 0,
                    Strength_LevelAdd = 0,
                    Magic_LevelAdd = 0,
                    Vitality_LevelAdd = 0,
                    Spirit_LevelAdd = 0,
                    Speed_LevelAdd = 0
                };
                List<ESkill> PiggyASkills = new List<ESkill>()
                {
                    ESkill.FireClaw,
                    ESkill.Sharpen,
                    ESkill.None,
                    ESkill.PoisonFang
                };
                CardHandlingNew.CreateTetramonCards(
                    "",
                    "Pigni",
                    "Hikoku",
                    "Fire element deals XXX extra damage this turn",
                    new Vector3(30, 0, 0),
                    EElementIndex.Fire,
                    ERarity.Common,
                    MonsterType.EMonsterTypeLocal.PiggyA,
                    MonsterType.EMonsterTypeLocal.PiggyB,
                    MonsterType.EMonsterTypeLocal.None,
                    PiggyARoles,
                    PiggyAStats,
                    PiggyASkills,
                    DLLPath + "\\BaseAssets\\Tetramon\\PiggyA",
                    DLLPath + "\\BaseAssets\\None"
                    );
            }
            
            // Add Burpig to the Pool
            static void CreateBurpig()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string DLLPath = Path.GetDirectoryName(assembly.Location);
                List<EMonsterRole> BurpigRoles = new List<EMonsterRole>()
                {
                    EMonsterRole.PhysicalAttacker
                };
                Stats BurpigStats = new Stats()
                {
                    HP = 81,
                    Strength = 35,
                    Magic = 14,
                    Vitality = 25,
                    Spirit = 12,
                    Speed = 18,
                    HP_LevelAdd = 0,
                    Strength_LevelAdd = 0,
                    Magic_LevelAdd = 0,
                    Vitality_LevelAdd = 0,
                    Spirit_LevelAdd = 0,
                    Speed_LevelAdd = 0
                };
                List<ESkill> BurpigSkills = new List<ESkill>()
                {
                    ESkill.BlazingClaw,
                    ESkill.Sharpen,
                    ESkill.None,
                    ESkill.PoisonFang
                };
                CardHandlingNew.CreateTetramonCards(
                    "",
                    "Burpig",
                    "Hikoku",
                    "Fire element deals XXX extra damage this turn",
                    new Vector3(60, 0, 0),
                    EElementIndex.Fire,
                    ERarity.Rare,
                    MonsterType.EMonsterTypeLocal.PiggyB,
                    MonsterType.EMonsterTypeLocal.PiggyC,
                    MonsterType.EMonsterTypeLocal.PiggyA,
                    BurpigRoles,
                    BurpigStats,
                    BurpigSkills,
                    DLLPath + "\\BaseAssets\\Tetramon\\PiggyB",
                    DLLPath + "\\BaseAssets\\None"
                );
            }
            
            // Add Inferhog to the Pool
            static void CreateInferhog()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string DLLPath = Path.GetDirectoryName(assembly.Location);
                List<EMonsterRole> InferhogRoles = new List<EMonsterRole>()
                {
                    EMonsterRole.PhysicalAttacker
                };
                Stats InferhogStats = new Stats()
                {
                    HP = 83,
                    Strength = 36,
                    Magic = 15,
                    Vitality = 26,
                    Spirit = 12,
                    Speed = 17,
                    HP_LevelAdd = 0,
                    Strength_LevelAdd = 0,
                    Magic_LevelAdd = 0,
                    Vitality_LevelAdd = 0,
                    Spirit_LevelAdd = 0,
                    Speed_LevelAdd = 0
                };
                List<ESkill> InferhogSkills = new List<ESkill>()
                {
                    ESkill.InfernoClaw,
                    ESkill.Sharpen,
                    ESkill.None,
                    ESkill.VenomFang
                };
                CardHandlingNew.CreateTetramonCards(
                    "",
                    "Inferhog",
                    "Hikoku",
                    "Fire element deals XXX extra damage this turn",
                    new Vector3(100, 0, 0),
                    EElementIndex.Fire,
                    ERarity.Epic,
                    MonsterType.EMonsterTypeLocal.PiggyC,
                    MonsterType.EMonsterTypeLocal.PiggyD,
                    MonsterType.EMonsterTypeLocal.PiggyB,
                    InferhogRoles,
                    InferhogStats,
                    InferhogSkills,
                    DLLPath + "\\BaseAssets\\Tetramon\\PiggyC",
                    DLLPath + "\\BaseAssets\\None"
                );
            }
            
            // Add Blazoar to the Pool
            static void CreateBlazoar()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string DLLPath = Path.GetDirectoryName(assembly.Location);
                List<EMonsterRole> BlazoarRoles = new List<EMonsterRole>()
                {
                    EMonsterRole.PhysicalAttacker
                };
                Stats BlazoarStats = new Stats()
                {
                    HP = 85,
                    Strength = 38,
                    Magic = 15,
                    Vitality = 28,
                    Spirit = 12,
                    Speed = 16,
                    HP_LevelAdd = 0,
                    Strength_LevelAdd = 0,
                    Magic_LevelAdd = 0,
                    Vitality_LevelAdd = 0,
                    Spirit_LevelAdd = 0,
                    Speed_LevelAdd = 0
                };
                List<ESkill> BlazoarSkills = new List<ESkill>()
                {
                    ESkill.HellfireClaw,
                    ESkill.Sharpen,
                    ESkill.None,
                    ESkill.VenomFang
                };
                CardHandlingNew.CreateTetramonCards(
                    "",
                    "Blazoar",
                    "Hikoku",
                    "Fire element deals double damage this turn",
                    new Vector3(2, 0, 0),
                    EElementIndex.Fire,
                    ERarity.Legendary,
                    MonsterType.EMonsterTypeLocal.PiggyD,
                    MonsterType.EMonsterTypeLocal.None,
                    MonsterType.EMonsterTypeLocal.PiggyC,
                    BlazoarRoles,
                    BlazoarStats,
                    BlazoarSkills,
                    DLLPath + "\\BaseAssets\\Tetramon\\PiggyD",
                    DLLPath + "\\BaseAssets\\Tetramon\\Ghost\\Ghost_PiggyD"
                );
            }
            
            // Add Kidsune to the Pool
            static void CreateKidsune()
            {
	            Assembly assembly = Assembly.GetExecutingAssembly();
	            string DLLPath = Path.GetDirectoryName(assembly.Location);
	            List<EMonsterRole> KidsuneRoles = new List<EMonsterRole>()
	            {
		            EMonsterRole.MagicalAttacker,
		            EMonsterRole.Disruptor
	            };
	            Stats KidsuneStats = new Stats()
	            {
		            HP = 75,
		            Strength = 12,
		            Magic = 33,
		            Vitality = 13,
		            Spirit = 28,
		            Speed = 24,
		            HP_LevelAdd = 0,
		            Strength_LevelAdd = 0,
		            Magic_LevelAdd = 0,
		            Vitality_LevelAdd = 0,
		            Spirit_LevelAdd = 0,
		            Speed_LevelAdd = 0
	            };
	            List<ESkill> KidsuneSkills = new List<ESkill>()
	            {
		            ESkill.FlamePillar,
		            ESkill.Cover,
		            ESkill.None,
		            ESkill.PowerDrip
	            };
	            CardHandlingNew.CreateTetramonCards(
		            "",
		            "Kidsune",
		            "Hikoku",
		            "Fire element deals XXX extra damage this turn, draw YYY",
		            new Vector3(15, 1, 0),
		            EElementIndex.Fire,
		            ERarity.Common,
		            MonsterType.EMonsterTypeLocal.FoxA,
		            MonsterType.EMonsterTypeLocal.FoxB,
		            MonsterType.EMonsterTypeLocal.None,
		            KidsuneRoles,
		            KidsuneStats,
		            KidsuneSkills,
		            DLLPath + "\\BaseAssets\\Tetramon\\FoxA",
		            DLLPath + "\\BaseAssets\\None"
	            );
            }
            
            // Add Bonifox to the Pool
            static void CreateBonifox()
            {
	            Assembly assembly = Assembly.GetExecutingAssembly();
	            string DLLPath = Path.GetDirectoryName(assembly.Location);
	            List<EMonsterRole> BonifoxRoles = new List<EMonsterRole>()
	            {
		            EMonsterRole.MagicalAttacker,
		            EMonsterRole.Disruptor
	            };
	            Stats BonifoxStats = new Stats()
	            {
		            HP = 78,
		            Strength = 12,
		            Magic = 34,
		            Vitality = 13,
		            Spirit = 29,
		            Speed = 25,
		            HP_LevelAdd = 0,
		            Strength_LevelAdd = 0,
		            Magic_LevelAdd = 0,
		            Vitality_LevelAdd = 0,
		            Spirit_LevelAdd = 0,
		            Speed_LevelAdd = 0
	            };
	            List<ESkill> BonifoxSkills = new List<ESkill>()
	            {
		            ESkill.BlazingPillar,
		            ESkill.Cover,
		            ESkill.None,
		            ESkill.PowerDrip
	            };
	            CardHandlingNew.CreateTetramonCards(
		            "",
		            "Bonifox",
		            "Faiahaato",
		            "Fire element deals XXX extra damage this turn, draw YYY",
		            new Vector3(30, 1, 0),
		            EElementIndex.Fire,
		            ERarity.Rare,
		            MonsterType.EMonsterTypeLocal.FoxB,
		            MonsterType.EMonsterTypeLocal.FoxC,
		            MonsterType.EMonsterTypeLocal.FoxA,
		            BonifoxRoles,
		            BonifoxStats,
		            BonifoxSkills,
		            DLLPath + "\\BaseAssets\\Tetramon\\FoxB",
		            DLLPath + "\\BaseAssets\\None"
	            );
            }
            
            // Add Honobi to the Pool
            static void CreateHonobi()
            {
	            Assembly assembly = Assembly.GetExecutingAssembly();
	            string DLLPath = Path.GetDirectoryName(assembly.Location);
	            List<EMonsterRole> HonobiRoles = new List<EMonsterRole>()
	            {
		            EMonsterRole.MagicalAttacker,
		            EMonsterRole.Disruptor
	            };
	            Stats HonobiStats = new Stats()
	            {
		            HP = 81,
		            Strength = 13,
		            Magic = 36,
		            Vitality = 14,
		            Spirit = 31,
		            Speed = 26,
		            HP_LevelAdd = 0,
		            Strength_LevelAdd = 0,
		            Magic_LevelAdd = 0,
		            Vitality_LevelAdd = 0,
		            Spirit_LevelAdd = 0,
		            Speed_LevelAdd = 0
	            };
	            List<ESkill> HonobiSkills = new List<ESkill>()
	            {
		            ESkill.InfernoPillar,
		            ESkill.Cover,
		            ESkill.None,
		            ESkill.PowerLeak
	            };
	            CardHandlingNew.CreateTetramonCards(
		            "",
		            "Honobi",
		            "Faiahaato",
		            "Fire element deals XXX extra damage this turn, draw YYY",
		            new Vector3(50, 1, 0),
		            EElementIndex.Fire,
		            ERarity.Epic,
		            MonsterType.EMonsterTypeLocal.FoxC,
		            MonsterType.EMonsterTypeLocal.FoxD,
		            MonsterType.EMonsterTypeLocal.FoxB,
		            HonobiRoles,
		            HonobiStats,
		            HonobiSkills,
		            DLLPath + "\\BaseAssets\\Tetramon\\FoxC",
		            DLLPath + "\\BaseAssets\\None"
	            );
            }
        }
    }
}