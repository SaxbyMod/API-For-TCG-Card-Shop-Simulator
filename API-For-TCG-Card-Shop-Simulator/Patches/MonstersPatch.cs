using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TCGShopNewCardsModPreloader.Handlers;
using API_For_TCG_Card_Shop_Simulator.Scripts;
using System.Linq;
using static UnityEngine.UIElements.StyleVariableResolver;
using Mono.Cecil;
using System.Reflection;

namespace TCGShopNewCardsMod.Patches
{
    [HarmonyPatch]
    internal class NewDataHelper
    {
        public static bool hasAddedNewCardsData = false;

        [HarmonyPostfix]// Does the adding once when game first loads into world
        [HarmonyPatch(typeof(InventoryBase), "Awake")]
        public static void InventoryBase_Awake_Postfix()
        {
            Console.WriteLine("InventoryBase_Awake_Postfix");
            if (hasAddedNewCardsData == false)
            {
                addNewMonsterData();
                hasAddedNewCardsData = true;
            }
        }
        public static void addNewMonsterData()//Works
        {

            // can refactor this method by using a combination of reflection iteration technique in MonsterDataPatch.cs and to create the emonstertype could use what's done in CustomMonsterHandler.cs
            List<CustomCard> newMonsterDataList = CardHandler.newMonstersList;
            if (newMonsterDataList != null)
            {
                foreach (CustomCard customCard in newMonsterDataList)
                {
                    string loadedMonsterType = customCard.MonsterType;
                    if (Enum.TryParse(loadedMonsterType, out EMonsterType monsterType))
                    {
                        MonsterData baseMonsterData = InventoryBase.GetMonsterData(EMonsterType.PiggyA);
                        MonsterData newMonsterData = CreateNewMonsterData(customCard);
                        if (baseMonsterData != null && newMonsterData != null)
                        {
                            // this is getting the first and last member of the expansion range
                            EMonsterType FireChickenB = TryParseEnum<EMonsterType>("FireChickenB", EMonsterType.None);
                            EMonsterType MAX = TryParseEnum<EMonsterType>("MAX", EMonsterType.None);
                            List<MonsterData> dataList = new List<MonsterData>();
                            List<EMonsterType> shownMonsterList = new List<EMonsterType>();
                            dataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList;
                            shownMonsterList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMonsterList;


                            EMonsterType WingBooster = TryParseEnum<EMonsterType>("WingBooster", EMonsterType.None);
                            EMonsterType MAX_MEGABOT = TryParseEnum<EMonsterType>("MAX_MEGABOT", EMonsterType.None);
                            List<MonsterData> megabotDataList = new List<MonsterData>();
                            List<EMonsterType> shownMegabotList = new List<EMonsterType>();
                            megabotDataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_MegabotDataList;
                            shownMegabotList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMegabotList;


                            EMonsterType WolfFantasy = TryParseEnum<EMonsterType>("WolfFantasy", EMonsterType.None);
                            EMonsterType MAX_FANTASYRPG = TryParseEnum<EMonsterType>("MAX_FANTASYRPG", EMonsterType.None);
                            List<MonsterData> fantasyRPGDataList = new List<MonsterData>();
                            List<EMonsterType> shownFantasyRPGList = new List<EMonsterType>();
                            fantasyRPGDataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_FantasyRPGDataList;
                            shownFantasyRPGList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownFantasyRPGList;


                            EMonsterType EX0Pirate = TryParseEnum<EMonsterType>("EX0Pirate", EMonsterType.None);
                            EMonsterType MAX_CATJOB = TryParseEnum<EMonsterType>("MAX_CATJOB", EMonsterType.None);
                            List<MonsterData> catJobDataList = new List<MonsterData>();
                            List<EMonsterType> shownCatJobList = new List<EMonsterType>();
                            catJobDataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_CatJobDataList;
                            shownCatJobList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownCatJobList;


                            List<EMonsterType> shownGhostList = new List<EMonsterType>();
                            shownGhostList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownGhostMonsterList;


                            var minMaxPairs = GetMinMaxPair();
                            //----------------------
                            for (int i = 0; i < minMaxPairs.Count; i += 2)
                            {
                                var min = minMaxPairs[i]["Min"];
                                var max = minMaxPairs[i + 1]["Max"];

                            }
                            //--------------------------

                            if (monsterType > FireChickenB && monsterType < MAX)
                            {
                                if (dataList != null && shownMonsterList != null)
                                {
                                    Log("Adding " + monsterType.ToString() + " to base data and shown list");
                                    dataList.Add(newMonsterData);
                                    shownMonsterList.Add(monsterType);
                                }
                                if (newMonsterData.GhostIcon != null)
                                {
                                    Log("Adding " + monsterType.ToString() + " to shown ghost list");
                                    shownGhostList.Add(monsterType);
                                }
                            }
                            else if (monsterType > WingBooster && monsterType < MAX_MEGABOT)
                            {
                                if (megabotDataList != null && shownMegabotList != null)
                                {
                                    Log("Adding " + monsterType.ToString() + " to megabot data and shown list");
                                    megabotDataList.Add(newMonsterData);
                                    shownMegabotList.Add(monsterType);
                                }
                            }
                            else if (monsterType > WolfFantasy && monsterType < MAX_FANTASYRPG)
                            {
                                if (fantasyRPGDataList != null && shownFantasyRPGList != null)
                                {
                                    Log("Adding " + monsterType.ToString() + " to fantasyrpg data and shown list");
                                    fantasyRPGDataList.Add(newMonsterData);
                                    shownFantasyRPGList.Add(monsterType);
                                }
                            }
                            else if (monsterType > EX0Pirate && monsterType < MAX_CATJOB)
                            {
                                if (catJobDataList != null && shownCatJobList != null)
                                {
                                    Log("Adding " + monsterType.ToString() + " to catjob data and shown list");
                                    catJobDataList.Add(newMonsterData);
                                    shownCatJobList.Add(monsterType);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static TEnum TryParseEnum<TEnum>(string value, TEnum defaultValue) where TEnum : struct
        {
            if (Enum.TryParse<TEnum>(value, true, out var result))
            {
                return result;
            }
            return defaultValue;
        }

        public static List<EMonsterRole> ParseRoles(List<string> roles)
        {
            List<EMonsterRole> parsedRoles = new List<EMonsterRole>();

            foreach (string role in roles)
            {
                if (Enum.TryParse<EMonsterRole>(role, true, out var result))
                {
                    parsedRoles.Add(result);
                }
            }

            return parsedRoles;
        }

        public static List<ESkill> ParseSkills(List<string> skills)
        {
            List<ESkill> parsedSkills = new List<ESkill>();

            foreach (string skill in skills)
            {
                if (Enum.TryParse<ESkill>(skill, true, out var result))
                {
                    parsedSkills.Add(result);
                }
            }

            return parsedSkills;
        }

        public static Stats GetBaseStats(TCGShopNewCardsModPreloader.Handlers.CustomCard monsterData)
        {
            Stats stats = new Stats();
            stats.HP = monsterData.HP;
            stats.HP_LevelAdd = monsterData.HPLevelAdd;
            stats.Magic = monsterData.Magic;
            stats.Magic_LevelAdd = monsterData.MagicLevelAdd;
            stats.Speed = monsterData.Speed;
            stats.Speed_LevelAdd = monsterData.SpeedLevelAdd;
            stats.Spirit = monsterData.Sprit;
            stats.Spirit_LevelAdd = monsterData.SpritLevelAdd;
            stats.Strength = monsterData.Strength;
            stats.Strength_LevelAdd = monsterData.StrengthLevelAdd;
            return stats;
        }

        public static MonsterData CreateNewMonsterData(TCGShopNewCardsModPreloader.Handlers.CustomCard newMonsterData)
        {
            return new MonsterData
            {
                ArtistName = newMonsterData.ArtistName,
                BaseStats = GetBaseStats(newMonsterData),
                Description = newMonsterData.Description,
                EffectAmount = new UnityEngine.Vector3(),
                ElementIndex = TryParseEnum<EElementIndex>(newMonsterData.ElementIndex, EElementIndex.None),
                GhostIcon = newMonsterData.GhostIcon,
                Icon = newMonsterData.Icon,
                MonsterType = TryParseEnum<EMonsterType>(newMonsterData.MonsterType, EMonsterType.None),
                Name = newMonsterData.Name,
                NextEvolution = TryParseEnum<EMonsterType>(newMonsterData.NextEvolution, EMonsterType.None),
                PreviousEvolution = TryParseEnum<EMonsterType>(newMonsterData.PreviousEvolution, EMonsterType.None),
                Rarity = TryParseEnum<ERarity>(newMonsterData.Rarity, ERarity.None),
                Roles = ParseRoles(newMonsterData.Roles),
                SkillList = ParseSkills(newMonsterData.Skills)
            };
        }

        private static List<Dictionary<string, EMonsterType>> GetMinMaxPair()
        {
            List<EMonsterType> eMonsterTypes = GetEMonsterTypeList();
            var eMonsterTypesMaxIndex = eMonsterTypes
                                            .Select((value, index) => new { value, index })
                                            .Where(obj => obj.ToString().Take(3).Equals("MAX"))
                                            .Select(obj => obj.index)
                                            .ToList();
            List<Dictionary<string, EMonsterType>> minMaxPairs = new List<Dictionary<string, EMonsterType>>(eMonsterTypesMaxIndex.Count());

            // start 1 = first index, max = first index with max
            // start 2 = first index after max, max = 2nd index with max
            minMaxPairs[0]["Min"] = eMonsterTypes[0];
            minMaxPairs[0]["Max"] = eMonsterTypes[eMonsterTypesMaxIndex.First()];

            for (int i = 0; i < eMonsterTypesMaxIndex.Count; i++)
            {
                EMonsterType start = (eMonsterTypesMaxIndex[i] + 1 < eMonsterTypes.Count)
                                    ? eMonsterTypes[eMonsterTypesMaxIndex[i] + 1]
                                    : EMonsterType.None;
                EMonsterType end = (i + 1 < eMonsterTypesMaxIndex.Count && eMonsterTypesMaxIndex[i + 1] < eMonsterTypes.Count)
                                    ? eMonsterTypes[eMonsterTypesMaxIndex[i + 1]]
                                    : EMonsterType.None;

                minMaxPairs.Add(new Dictionary<string, EMonsterType> { { "Min", start }, { "Max", end } });
            }

            foreach (var pair in minMaxPairs)
            {
                Console.WriteLine($"GetMinMaxPair() min {pair["Min"]} max {pair["Max"]}");
            }
            return minMaxPairs;
        }

        private static List<EMonsterType> GetEMonsterTypeList()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dllPath = baseDirectory + @"\Card Shop Simulator_Data\Managed\Assembly-CSharp.dll";

            AssemblyDefinition loadedAssembly = new();
            try
            {
                // Load the assembly from the specified path
                loadedAssembly = AssemblyDefinition.ReadAssembly(Assembly.LoadFile(dllPath).Location);

                // Display the assembly's full name as confirmation
                Console.WriteLine("Loaded Assembly: " + loadedAssembly.FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading DLL: " + ex.Message);
            }

            TypeDefinition typeDefinition = loadedAssembly.MainModule.Types.First((TypeDefinition t) => t.Name == "EMonsterType");
            List<EMonsterType> eMonsterTypeList = new List<EMonsterType>();

            /// print all EMonsterType names
            foreach (var field in typeDefinition.Fields)
            {
                EMonsterType monsterType = (EMonsterType)Enum.Parse(typeof(EMonsterType), field.Name);
                Console.WriteLine($"GetEMonsterTypeList() monsterType {monsterType}");
            }
            return eMonsterTypeList;
        }

        /* Old but leaving it as a reference
        public static MonsterData CreateCopy(MonsterData original, EMonsterType newMonsterType, string newName)
        {
            return new MonsterData
            {
                ArtistName = original.ArtistName,
                BaseStats = original.BaseStats,
                Description = original.Description,
                EffectAmount = original.EffectAmount,
                ElementIndex = original.ElementIndex,
                GhostIcon = original.GhostIcon,
                Icon = original.Icon,
                MonsterType = newMonsterType,
                Name = newName,
                NextEvolution = original.NextEvolution,
                PreviousEvolution = original.PreviousEvolution,
                Rarity = original.Rarity,
                Roles = original.Roles,
                SkillList = original.SkillList
            };
        }
        */

        public static void Log(String log)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogInfo(log);
        }
        public static void LogError(String log)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogError(log);
        }
        public static void LogWarn(String log)
        {
            API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogWarning(log);
        }
    }
}
