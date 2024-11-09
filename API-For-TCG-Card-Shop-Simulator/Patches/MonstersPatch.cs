using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TCGShopNewCardsModPreloader.Handlers;
using API_For_TCG_Card_Shop_Simulator.Scripts;

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
            if (hasAddedNewCardsData == false)
            {
                addNewMonsterData();
                hasAddedNewCardsData = true;
            }
        }
        public static void addNewMonsterData()//Works
        {
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
                            EMonsterType FireChickenB = TryParseEnum<EMonsterType>("FireChickenB", EMonsterType.None);
                            EMonsterType MAX = TryParseEnum<EMonsterType>("MAX", EMonsterType.None);

                            EMonsterType WingBooster = TryParseEnum<EMonsterType>("WingBooster", EMonsterType.None);
                            EMonsterType MAX_MEGABOT = TryParseEnum<EMonsterType>("MAX_MEGABOT", EMonsterType.None);

                            EMonsterType WolfFantasy = TryParseEnum<EMonsterType>("WolfFantasy", EMonsterType.None);
                            EMonsterType MAX_FANTASYRPG = TryParseEnum<EMonsterType>("MAX_FANTASYRPG", EMonsterType.None);

                            EMonsterType EX0Pirate = TryParseEnum<EMonsterType>("EX0Pirate", EMonsterType.None);
                            EMonsterType MAX_CATJOB = TryParseEnum<EMonsterType>("MAX_CATJOB", EMonsterType.None);

                            List<MonsterData> dataList = new List<MonsterData>();
                            List<MonsterData> catJobDataList = new List<MonsterData>();
                            List<MonsterData> fantasyRPGDataList = new List<MonsterData>();
                            List<MonsterData> megabotDataList = new List<MonsterData>();
                            List<EMonsterType> shownMonsterList = new List<EMonsterType>();
                            List<EMonsterType> shownGhostList = new List<EMonsterType>();
                            List<EMonsterType> shownCatJobList = new List<EMonsterType>();
                            List<EMonsterType> shownFantasyRPGList = new List<EMonsterType>();
                            List<EMonsterType> shownMegabotList = new List<EMonsterType>();

                            dataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList;
                            catJobDataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_CatJobDataList;
                            fantasyRPGDataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_FantasyRPGDataList;
                            megabotDataList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_MegabotDataList;
                            shownMonsterList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMonsterList;
                            shownGhostList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownGhostMonsterList;
                            shownCatJobList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownCatJobList;
                            shownFantasyRPGList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownFantasyRPGList;
                            shownMegabotList = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_ShownMegabotList;

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
