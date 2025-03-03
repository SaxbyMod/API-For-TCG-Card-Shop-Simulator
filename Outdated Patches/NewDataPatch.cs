//using API_For_TCG_Card_Shop_Simulator.Scripts;
//using HarmonyLib;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using TCGShopNewCardsModPreloader.Handlers;
//using UnityEngine;
//using UnityEngine.Experimental.Rendering;
//using UnityEngine.SceneManagement;

//namespace API_For_TCG_Card_Shop_Simulator.Patches
//{
//    // Token: 0x02000007 RID: 7
//    [HarmonyPatch]
//    internal class NewDataHelper
//    {
//        // Token: 0x06000009 RID: 9 RVA: 0x000021E4 File Offset: 0x000003E4
//        public static void ClearAllTempLists()
//        {
//            for (int i = 0; i < NewDataHelper.tempDataList.Count; i++)
//            {
//                NewDataHelper.tempDataList[i] = null;
//            }
//            NewDataHelper.tempDataList.Clear();
//            for (int j = 0; j < NewDataHelper.tempCatJobDataList.Count; j++)
//            {
//                NewDataHelper.tempCatJobDataList[j] = null;
//            }
//            NewDataHelper.tempCatJobDataList.Clear();
//            for (int k = 0; k < NewDataHelper.tempFantasyRPGDataList.Count; k++)
//            {
//                NewDataHelper.tempFantasyRPGDataList[k] = null;
//            }
//            NewDataHelper.tempFantasyRPGDataList.Clear();
//            for (int l = 0; l < NewDataHelper.tempMegabotDataList.Count; l++)
//            {
//                NewDataHelper.tempMegabotDataList[l] = null;
//            }
//            NewDataHelper.tempMegabotDataList.Clear();
//            NewDataHelper.tempShownMonsterList.Clear();
//            NewDataHelper.tempShownGhostList.Clear();
//            NewDataHelper.tempShownCatJobList.Clear();
//            NewDataHelper.tempShownFantasyRPGList.Clear();
//            NewDataHelper.tempShownMegabotList.Clear();
//        }

//        // Token: 0x0600000A RID: 10 RVA: 0x00002304 File Offset: 0x00000504
//        [HarmonyPrefix]
//        [HarmonyPatch(typeof(CGameData), "PropagateLoadData")]
//        public static void CGameData_PropagateLoadData_Prefix(CGameData __instance, ref CGameData gameData)
//        {
//            int num = CPlayerData.GetCardCollectionDataCount() + 100;
//            bool flag = gameData.m_CardCollectedList.Count < num;
//            if (flag)
//            {
//                int num2 = num - gameData.m_CardCollectedList.Count;
//                for (int i = 0; i < num2; i++)
//                {
//                    gameData.m_CardCollectedList.Add(0);
//                    gameData.m_CardCollectedListDestiny.Add(0);
//                    gameData.m_CardCollectedListGhost.Add(0);
//                    gameData.m_CardCollectedListGhostBlack.Add(0);
//                    gameData.m_CardCollectedListMegabot.Add(0);
//                    gameData.m_CardCollectedListFantasyRPG.Add(0);
//                    gameData.m_CardCollectedListCatJob.Add(0);
//                    gameData.m_IsCardCollectedList.Add(false);
//                    gameData.m_IsCardCollectedListDestiny.Add(false);
//                    gameData.m_IsCardCollectedListGhost.Add(false);
//                    gameData.m_IsCardCollectedListGhostBlack.Add(false);
//                    gameData.m_IsCardCollectedListMegabot.Add(false);
//                    gameData.m_IsCardCollectedListFantasyRPG.Add(false);
//                    gameData.m_IsCardCollectedListCatJob.Add(false);
//                    gameData.m_CardPriceSetList.Add(0f);
//                    gameData.m_CardPriceSetListDestiny.Add(0f);
//                    gameData.m_CardPriceSetListGhost.Add(0f);
//                    gameData.m_CardPriceSetListGhostBlack.Add(0f);
//                    gameData.m_CardPriceSetListMegabot.Add(0f);
//                    gameData.m_CardPriceSetListFantasyRPG.Add(0f);
//                    gameData.m_CardPriceSetListCatJob.Add(0f);
//                    MarketPrice marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceList.Add(marketPrice);
//                    marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceListDestiny.Add(marketPrice);
//                    marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceListGhost.Add(marketPrice);
//                    marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceListGhostBlack.Add(marketPrice);
//                    marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceListMegabot.Add(marketPrice);
//                    marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceListFantasyRPG.Add(marketPrice);
//                    marketPrice = new MarketPrice();
//                    marketPrice.pastPricePercentChangeList = new List<float>();
//                    gameData.m_GenCardMarketPriceListCatJob.Add(marketPrice);
//                }
//            }
//        }

//        // Token: 0x0600000B RID: 11 RVA: 0x0000258C File Offset: 0x0000078C
//        [HarmonyPrefix]
//        [HarmonyPatch(typeof(CPlayerData), "GetCardCollectionDataCount")]
//        public static bool CPlayerData_GetCardCollectionDataCount_Prefix(ref int __result)
//        {
//            int num = CardHandler.newMonstersList.Count * 12;
//            __result = 2000 + num;
//            return false;
//        }

//        // Token: 0x0600000C RID: 12 RVA: 0x000025B4 File Offset: 0x000007B4
//        [HarmonyPostfix]
//        [HarmonyPatch(typeof(CGameManager), "OnLevelFinishedLoading")]
//        public static void CGameManager_OnLevelFinishedLoading_Postfix(ref Scene scene, LoadSceneMode mode)
//        {
//            bool flag = scene.name == "Title";
//            if (flag)
//            {
//                bool flag2 = !NewDataHelper.firstLoad;
//                if (flag2)
//                {
//                    NewDataHelper.addNewMonsterDataToTempLists();
//                    NewDataHelper.firstLoad = true;
//                }
//            }
//            Resources.UnloadUnusedAssets();
//        }

//        // Token: 0x0600000D RID: 13 RVA: 0x000025F8 File Offset: 0x000007F8
//        [HarmonyPostfix]
//        [HarmonyPatch(typeof(InventoryBase), "Awake")]
//        public static void InventoryBase_Awake_Postfix()
//        {
//            bool flag = !NewDataHelper.hasAddedNewCardsData;
//            if (flag)
//            {
//                NewDataHelper.AddHiddenCards();
//                NewDataHelper.addNewMonsterData(NewDataHelper.tempDataList, NewDataHelper.tempCatJobDataList, NewDataHelper.tempFantasyRPGDataList, NewDataHelper.tempMegabotDataList, NewDataHelper.tempShownMonsterList, NewDataHelper.tempShownGhostList, NewDataHelper.tempShownCatJobList, NewDataHelper.tempShownFantasyRPGList, NewDataHelper.tempShownMegabotList);
//                NewDataHelper.hasAddedNewCardsData = true;
//            }
//        }

//        // Token: 0x0600000E RID: 14 RVA: 0x00002654 File Offset: 0x00000854
//        public static void AddHiddenCards()
//        {
//            List<EMonsterType> shownMonsterList = InventoryBase.GetShownMonsterList(ECardExpansionType.Tetramon);
//            bool flag = shownMonsterList != null;
//            if (flag)
//            {
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SlimeA);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SlimeB);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SlimeC);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SlimeD);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SeahorseA);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SeahorseB);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SeahorseC);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.SeahorseD);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.FireChickenA);
//                NewDataHelper.AddMonsterIfNotExists(shownMonsterList, EMonsterType.FireChickenB);
//            }
//        }

//        // Token: 0x0600000F RID: 15 RVA: 0x000026D0 File Offset: 0x000008D0
//        private static void AddMonsterIfNotExists(List<EMonsterType> monsterList, EMonsterType monsterType)
//        {
//            bool flag = !monsterList.Contains(monsterType);
//            if (flag)
//            {
//                monsterList.Add(monsterType);
//            }
//        }

//        public static MonsterData CreateNewMonsterData(CustomCard newMonsterData)
//        {
//            return new MonsterData
//            {
//                ArtistName = newMonsterData.ArtistName,
//                BaseStats = newMonsterData.BaseStats,
//                Description = newMonsterData.Description,
//                EffectAmount = newMonsterData.EffectAmount,
//                ElementIndex = NewDataHelper.TryParseEnum<EElementIndex>(newMonsterData.ElementIndex, EElementIndex.None),
//                GhostIcon = newMonsterData.GhostIcon,
//                Icon = newMonsterData.Icon,
//                MonsterType = NewDataHelper.TryParseEnum<EMonsterType>(newMonsterData.MonsterType, EMonsterType.None),
//                Name = newMonsterData.Name,
//                PreviousEvolution = NewDataHelper.TryParseEnum<EMonsterType>(newMonsterData.PreviousEvolution, EMonsterType.None),
//                Rarity = NewDataHelper.TryParseEnum<ERarity>(newMonsterData.Rarity, ERarity.None),
//                Roles = NewDataHelper.ParseRoles(newMonsterData.Roles),
//                SkillList = NewDataHelper.ParseSkills(newMonsterData.Skills)
//            };
//        }

//        // Token: 0x06000011 RID: 17 RVA: 0x0000273C File Offset: 0x0000093C
//        public static void addNewMonsterDataToTempLists()
//        {
//            NewDataHelper.Log("Adding new monster data to temporary lists");
//            string path = NewDataHelper.patcherPath;
//            bool flag = !Directory.Exists(path);
//            if (flag)
//            {
//                NewDataHelper.Log("DIRECTORY DIDN'T EXIST");
//            }
//            else
//            {
//                List<CustomCard> newMonstersList = CardHandler.newMonstersList;
//                bool flag2 = newMonstersList == null;
//                if (!flag2)
//                {
//                    EMonsterType emonsterType = NewDataHelper.TryParseEnum<EMonsterType>("FireChickenB", EMonsterType.None);
//                    EMonsterType emonsterType2 = NewDataHelper.TryParseEnum<EMonsterType>("MAX", EMonsterType.None);
//                    EMonsterType emonsterType3 = NewDataHelper.TryParseEnum<EMonsterType>("WingBooster", EMonsterType.None);
//                    EMonsterType emonsterType4 = NewDataHelper.TryParseEnum<EMonsterType>("MAX_MEGABOT", EMonsterType.None);
//                    EMonsterType emonsterType5 = NewDataHelper.TryParseEnum<EMonsterType>("WolfFantasy", EMonsterType.None);
//                    EMonsterType emonsterType6 = NewDataHelper.TryParseEnum<EMonsterType>("MAX_FANTASYRPG", EMonsterType.None);
//                    EMonsterType emonsterType7 = NewDataHelper.TryParseEnum<EMonsterType>("EX0Pirate", EMonsterType.None);
//                    EMonsterType emonsterType8 = NewDataHelper.TryParseEnum<EMonsterType>("MAX_CATJOB", EMonsterType.None);
//                    foreach (CustomCard customCard in newMonstersList)
//                    {
//                        EMonsterType emonsterType9;
//                        bool flag3 = Enum.TryParse<EMonsterType>(customCard.MonsterType, out emonsterType9);
//                        if (flag3)
//                        {
//                            MonsterData monsterData = NewDataHelper.CreateNewMonsterData(customCard);
//                            bool flag4 = monsterData == null;
//                            if (!flag4)
//                            {
//                                bool flag5 = emonsterType9 > emonsterType && emonsterType9 < emonsterType2;
//                                if (flag5)
//                                {
//                                    NewDataHelper.tempDataList.Add(monsterData);
//                                    NewDataHelper.tempShownMonsterList.Add(emonsterType9);
//                                    bool flag6 = monsterData.GhostIcon != null;
//                                    if (flag6)
//                                    {
//                                        NewDataHelper.tempShownGhostList.Add(emonsterType9);
//                                    }
//                                    NewDataHelper.Log(string.Format("Added {0} to temp base data and shown lists", emonsterType9));
//                                }
//                                else
//                                {
//                                    bool flag7 = emonsterType9 > emonsterType3 && emonsterType9 < emonsterType4;
//                                    if (flag7)
//                                    {
//                                        NewDataHelper.tempMegabotDataList.Add(monsterData);
//                                        NewDataHelper.tempShownMegabotList.Add(emonsterType9);
//                                        NewDataHelper.Log(string.Format("Added {0} to temp megabot data and shown lists", emonsterType9));
//                                    }
//                                    else
//                                    {
//                                        bool flag8 = emonsterType9 > emonsterType5 && emonsterType9 < emonsterType6;
//                                        if (flag8)
//                                        {
//                                            NewDataHelper.tempFantasyRPGDataList.Add(monsterData);
//                                            NewDataHelper.tempShownFantasyRPGList.Add(emonsterType9);
//                                            NewDataHelper.Log(string.Format("Added {0} to temp fantasy RPG data and shown lists", emonsterType9));
//                                        }
//                                        else
//                                        {
//                                            bool flag9 = emonsterType9 > emonsterType7 && emonsterType9 < emonsterType8;
//                                            if (flag9)
//                                            {
//                                                NewDataHelper.tempCatJobDataList.Add(monsterData);
//                                                NewDataHelper.tempShownCatJobList.Add(emonsterType9);
//                                                NewDataHelper.Log(string.Format("Added {0} to temp cat job data and shown lists", emonsterType9));
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        // Token: 0x06000012 RID: 18 RVA: 0x000029C8 File Offset: 0x00000BC8
//        public static void addNewMonsterData(List<MonsterData> dataList, List<MonsterData> catJobDataList, List<MonsterData> fantasyRPGDataList, List<MonsterData> megabotDataList, List<EMonsterType> shownMonsterList, List<EMonsterType> shownGhostList, List<EMonsterType> shownCatJobList, List<EMonsterType> shownFantasyRPGList, List<EMonsterType> shownMegabotList)
//        {
//            MonsterData_ScriptableObject monsterData_SO = CSingleton<InventoryBase>.Instance.m_MonsterData_SO;
//            monsterData_SO.m_DataList.AddRange(dataList);
//            for (int i = 0; i < dataList.Count; i++)
//            {
//                dataList[i] = null;
//            }
//            dataList.Clear();
//            monsterData_SO.m_CatJobDataList.AddRange(catJobDataList);
//            for (int j = 0; j < dataList.Count; j++)
//            {
//                dataList[j] = null;
//            }
//            catJobDataList.Clear();
//            monsterData_SO.m_FantasyRPGDataList.AddRange(fantasyRPGDataList);
//            for (int k = 0; k < dataList.Count; k++)
//            {
//                dataList[k] = null;
//            }
//            fantasyRPGDataList.Clear();
//            monsterData_SO.m_MegabotDataList.AddRange(megabotDataList);
//            for (int l = 0; l < dataList.Count; l++)
//            {
//                dataList[l] = null;
//            }
//            megabotDataList.Clear();
//            monsterData_SO.m_ShownMonsterList.AddRange(shownMonsterList);
//            for (int m = 0; m < shownMonsterList.Count; m++)
//            {
//                shownMonsterList[m] = EMonsterType.None;
//            }
//            shownMonsterList.Clear();
//            monsterData_SO.m_ShownGhostMonsterList.AddRange(shownGhostList);
//            for (int n = 0; n < shownGhostList.Count; n++)
//            {
//                shownGhostList[n] = EMonsterType.None;
//            }
//            shownGhostList.Clear();
//            monsterData_SO.m_ShownCatJobList.AddRange(shownCatJobList);
//            for (int num = 0; num < shownCatJobList.Count; num++)
//            {
//                shownCatJobList[num] = EMonsterType.None;
//            }
//            shownCatJobList.Clear();
//            monsterData_SO.m_ShownFantasyRPGList.AddRange(shownFantasyRPGList);
//            for (int num2 = 0; num2 < shownFantasyRPGList.Count; num2++)
//            {
//                shownFantasyRPGList[num2] = EMonsterType.None;
//            }
//            shownFantasyRPGList.Clear();
//            monsterData_SO.m_ShownMegabotList.AddRange(shownMegabotList);
//            for (int num3 = 0; num3 < shownMegabotList.Count; num3++)
//            {
//                shownMegabotList[num3] = EMonsterType.None;
//            }
//            shownMegabotList.Clear();
//            NewDataHelper.Log("Added all temporary monster data to the main lists.");
//        }

//        // Token: 0x06000013 RID: 19 RVA: 0x00002C08 File Offset: 0x00000E08
//        public static TEnum TryParseEnum<TEnum>(string value, TEnum defaultValue) where TEnum : struct
//        {
//            TEnum tenum;
//            bool flag = Enum.TryParse<TEnum>(value, true, out tenum);
//            TEnum result;
//            if (flag)
//            {
//                result = tenum;
//            }
//            else
//            {
//                result = defaultValue;
//            }
//            return result;
//        }

//        // Token: 0x06000014 RID: 20 RVA: 0x00002C30 File Offset: 0x00000E30
//        public static List<EMonsterRole> ParseRoles(List<string> roles)
//        {
//            List<EMonsterRole> list = new List<EMonsterRole>();
//            foreach (string value in roles)
//            {
//                EMonsterRole item;
//                bool flag = Enum.TryParse<EMonsterRole>(value, true, out item);
//                if (flag)
//                {
//                    list.Add(item);
//                }
//            }
//            return list;
//        }

//        // Token: 0x06000015 RID: 21 RVA: 0x00002CA4 File Offset: 0x00000EA4
//        public static List<ESkill> ParseSkills(List<string> skills)
//        {
//            List<ESkill> list = new List<ESkill>();
//            foreach (string value in skills)
//            {
//                ESkill item;
//                bool flag = Enum.TryParse<ESkill>(value, true, out item);
//                if (flag)
//                {
//                    list.Add(item);
//                }
//            }
//            return list;
//        }

//        // Token: 0x0600001B RID: 27 RVA: 0x000030C1 File Offset: 0x000012C1
//        public static void Log(string log)
//        {
//            Plugin.Log.LogInfo(log);
//        }

//        // Token: 0x0600001C RID: 28 RVA: 0x000030D0 File Offset: 0x000012D0
//        public static void LogError(string log)
//        {
//            Plugin.Log.LogError(log);
//        }

//        // Token: 0x0600001D RID: 29 RVA: 0x000030DF File Offset: 0x000012DF
//        public static void LogWarn(string log)
//        {
//            Plugin.Log.LogWarning(log);
//        }

//        // Token: 0x0400000A RID: 10
//        public static bool hasAddedNewCardsData = false;

//        // Token: 0x0400000B RID: 11
//        public static bool firstLoad = false;

//        // Token: 0x0400000C RID: 12
//        public static List<MonsterData> tempDataList = new List<MonsterData>();

//        // Token: 0x0400000D RID: 13
//        public static List<MonsterData> tempCatJobDataList = new List<MonsterData>();

//        // Token: 0x0400000E RID: 14
//        public static List<MonsterData> tempFantasyRPGDataList = new List<MonsterData>();

//        // Token: 0x0400000F RID: 15
//        public static List<MonsterData> tempMegabotDataList = new List<MonsterData>();

//        // Token: 0x04000010 RID: 16
//        public static List<EMonsterType> tempShownMonsterList = new List<EMonsterType>();

//        // Token: 0x04000011 RID: 17
//        public static List<EMonsterType> tempShownGhostList = new List<EMonsterType>();

//        // Token: 0x04000012 RID: 18
//        public static List<EMonsterType> tempShownCatJobList = new List<EMonsterType>();

//        // Token: 0x04000013 RID: 19
//        public static List<EMonsterType> tempShownFantasyRPGList = new List<EMonsterType>();

//        // Token: 0x04000014 RID: 20
//        public static List<EMonsterType> tempShownMegabotList = new List<EMonsterType>();

//        // Token: 0x04000015 RID: 21
//        public static string gameInstallPath = Path.GetDirectoryName(Application.dataPath);

//        // Token: 0x04000016 RID: 22
//        public static string patcherPath = NewDataHelper.gameInstallPath + "/BepInEx/patchers/TCGShopNewCardsModPreloader/";

//        // Token: 0x04000017 RID: 23
//        public static string monsterImagesPath = NewDataHelper.patcherPath + "MonsterImages/";
//    }
//}

