using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Cards.Patches
{
    [HarmonyPatch]
    internal class MonsterDataPatch
    {
        public static CustomCard GetCustomCardMatch(Dictionary<int, CustomCard> listMonsterData, CustomCard monsterType)
        {
            if (monsterType == null)
            {
                API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogError("monsterType is null in GetMonsterDataMatchWithTypeModified.");
                return null;
            }
            if (listMonsterData == null)
            {
                API_For_TCG_Card_Shop_Simulator.Plugin.Log.LogError("listMonsterData is null in GetMonsterDataMatchWithTypeModified.");
                return null;
            }

            for (int i = 0; i < listMonsterData.Count; i++)
            {
                if (listMonsterData[i] == monsterType)
                {
                    CustomCard customCard = listMonsterData[i];
                    return customCard;
                }
            }

            return null;
        }

        public static CustomCard GetCustomCard(int monsterType)
        {
            if (monsterType == 0 || (monsterType >= (int)EnumListScript.MonsterMax["Tetramon"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["CatJob"]))
            {
                return null;
            }
            if (monsterType < (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatch(CardHandlingNew.ModdedMonsterData["Tetramon"], CardHandlingNew.ModdedMonsterData["Tetramon"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatch(CardHandlingNew.ModdedMonsterData["Megabot"], CardHandlingNew.ModdedMonsterData["Megabot"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatch(CardHandlingNew.ModdedMonsterData["FantasyRPG"], CardHandlingNew.ModdedMonsterData["FantasyRPG"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["CatJob"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatch(CardHandlingNew.ModdedMonsterData["Catjob"], CardHandlingNew.ModdedMonsterData["Catjob"][monsterType]);
            }

            return null;
        }

        public static Dictionary<int, CustomCard> GetShownCardList(ECardExpansionType expansionType)
        {
            if (expansionType == ECardExpansionType.Tetramon || expansionType == ECardExpansionType.Destiny)
            {
                return CardHandlingNew.ModdedMonsterData["Tetramon"];
            }
            if (expansionType == ECardExpansionType.Ghost)
            {
                return CardHandlingNew.ModdedMonsterData["Tetramon"];
            }
            if (expansionType == ECardExpansionType.Megabot)
            {
                return CardHandlingNew.ModdedMonsterData["Megabot"];
            }
            if (expansionType == ECardExpansionType.FantasyRPG)
            {
                return CardHandlingNew.ModdedMonsterData["FantasyRPG"];
            }
            if (expansionType == ECardExpansionType.CatJob)
            {
                return CardHandlingNew.ModdedMonsterData["Catjob"];
            }
            return CardHandlingNew.ModdedMonsterData["Tetramon"];
        }

        // PATCGES [CardData]

        [HarmonyPatch(nameof(CardData), typeof(CardData))]
        public class CardData
        {
            public ECardBorderType GetCardBorderType()
            {
                return CPlayerData.GetCardBorderType((int)this.borderType, this.expansionType);
            }
            public ECardExpansionType expansionType;
            public int monsterType;
            public ECardBorderType borderType;
            public bool isFoil;
            public bool isDestiny;
            public bool isChampionCard;
            public bool isNew;
        }

        // PATCHES [CardOpeningSequence.GetPackContent]

        public static List<CardData> m_RolledCardDataList = new List<CardData>();
        public static List<CardData> m_SecondaryRolledCardDataList = new List<CardData>();
        public static List<CardData> m_CardDataPool = new List<CardData>();
        public static List<CardData> m_CardDataPool2 = new List<CardData>();
        public static bool m_HasFoilCard;
        public static ECollectionPackType m_CollectionPackType = ECollectionPackType.None;
        public static List<float> m_CardValueList = new List<float>();

        [HarmonyPrefix, HarmonyPatch(nameof(CardOpeningSequence), typeof(CardOpeningSequence.GetPackContent))]
        public static bool GetPackContent(ref bool clearList, ref bool isPremiumPack, bool isSecondaryRolledData = false, ECollectionPackType overrideCollectionPackType = ECollectionPackType.None)
        {
            if (clearList)
            {
                if (isSecondaryRolledData)
                {
                    m_SecondaryRolledCardDataList.Clear();
                }
                else
                {
                    m_RolledCardDataList.Clear();
                    m_CardValueList.Clear();
                }
            }
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            List<int> list4 = new List<int>();
            List<int> list5 = new List<int>();
            ECardExpansionType cardExpansionType = InventoryBase.GetCardExpansionType(m_CollectionPackType);
            if (isSecondaryRolledData)
            {
                cardExpansionType = InventoryBase.GetCardExpansionType(overrideCollectionPackType);
            }
            bool openPackCanUseRarity = InventoryBase.GetCardUISetting(cardExpansionType).openPackCanUseRarity;
            bool openPackCanHaveDuplicate = InventoryBase.GetCardUISetting(cardExpansionType).openPackCanHaveDuplicate;
            for (int i = 0; i < GetShownCardList(cardExpansionType).Count; i++)
            {
                int monsterType = GetCustomCard(i).ID;
                ERarity rarity = GetCustomCard(i).Rarity;
                list.Add(monsterType);
                if (rarity == ERarity.Legendary)
                {
                    list5.Add(monsterType);
                }
                else if (rarity == ERarity.Epic)
                {
                    list4.Add(monsterType);
                }
                else if (rarity == ERarity.Rare)
                {
                    list3.Add(monsterType);
                }
                else
                {
                    list2.Add(monsterType);
                }
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 1;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            float num9 = 10f;
            float num10 = 2f;
            float num11 = 0.1f;
            float num12 = 5f;
            ECardBorderType borderType = ECardBorderType.Base;
            float num13 = 20f;
            float num14 = 8f;
            float num15 = 4f;
            float num16 = 1f;
            float num17 = 0.25f;
            ERarity erarity = ERarity.Common;
            int num18 = 7;
            if (m_CollectionPackType == ECollectionPackType.RareCardPack || m_CollectionPackType == ECollectionPackType.DestinyRareCardPack)
            {
                num5 = 0;
                num6 = 7;
                num9 += 45f;
                num10 += 2f;
                num11 += 1f;
            }
            else if (m_CollectionPackType == ECollectionPackType.EpicCardPack || m_CollectionPackType == ECollectionPackType.DestinyEpicCardPack)
            {
                num5 = 0;
                num6 = 1;
                num7 = 7;
                num8 = 0;
                num9 += 65f;
                num10 += 45f;
                num11 += 3f;
            }
            else if (m_CollectionPackType == ECollectionPackType.LegendaryCardPack || m_CollectionPackType == ECollectionPackType.DestinyLegendaryCardPack)
            {
                num5 = 0;
                num6 = 0;
                num7 = 1;
                num8 = 7;
                num9 += 65f;
                num10 += 55f;
                num11 += 35f;
            }
            else if (m_CollectionPackType == ECollectionPackType.BasicCardPack || m_CollectionPackType == ECollectionPackType.DestinyBasicCardPack)
            {
                num5 = 7;
            }
            int num19 = 0;
            while (num19 < num18 && list.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                if (num8 - num4 > 0 && list5.Count > 0)
                {
                    erarity = ERarity.Legendary;
                    num4++;
                }
                else if (num7 - num3 > 0 && list4.Count > 0)
                {
                    erarity = ERarity.Epic;
                    num3++;
                }
                else if (num6 - num2 > 0 && list3.Count > 0)
                {
                    erarity = ERarity.Rare;
                    num2++;
                }
                else if (num5 - num > 0 && list2.Count > 0)
                {
                    erarity = ERarity.Common;
                    num++;
                }
                else
                {
                    int num20 = UnityEngine.Random.Range(0, 10000);
                    int num21 = 4 - num2;
                    int num22 = 4 - num3;
                    int num23 = 4 - num4;
                    bool flag = false;
                    if (!flag && num11 > 0f && list5.Count > 0 && num23 > 0)
                    {
                        int num24 = Mathf.RoundToInt(num11 * 100f);
                        if (num20 < num24)
                        {
                            flag = true;
                            erarity = ERarity.Legendary;
                            num4++;
                        }
                    }
                    if (!flag && num10 > 0f && list4.Count > 0 && num22 > 0)
                    {
                        int num24 = Mathf.RoundToInt(num10 * 100f);
                        if (num20 < num24)
                        {
                            flag = true;
                            erarity = ERarity.Epic;
                            num3++;
                        }
                    }
                    if (!flag && num9 > 0f && list3.Count > 0 && num21 > 0)
                    {
                        int num24 = Mathf.RoundToInt(num9 * 100f);
                        if (num20 < num24)
                        {
                            flag = true;
                            erarity = ERarity.Rare;
                            num2++;
                        }
                    }
                    if (!flag)
                    {
                        erarity = ERarity.Common;
                        num++;
                    }
                }
                int monsterType2;
                if (openPackCanUseRarity)
                {
                    if (erarity == ERarity.Legendary)
                    {
                        index = UnityEngine.Random.Range(0, list5.Count);
                        monsterType2 = (int)list5[index];
                        if (!openPackCanHaveDuplicate)
                        {
                            list5.RemoveAt(index);
                        }
                    }
                    else if (erarity == ERarity.Epic)
                    {
                        index = UnityEngine.Random.Range(0, list4.Count);
                        monsterType2 = (int)list4[index];
                        if (!openPackCanHaveDuplicate)
                        {
                            list4.RemoveAt(index);
                        }
                    }
                    else if (erarity == ERarity.Rare)
                    {
                        index = UnityEngine.Random.Range(0, list3.Count);
                        monsterType2 = (int)list3[index];
                        if (!openPackCanHaveDuplicate)
                        {
                            list3.RemoveAt(index);
                        }
                    }
                    else
                    {
                        index = UnityEngine.Random.Range(0, list2.Count);
                        monsterType2 = (int)list2[index];
                        if (!openPackCanHaveDuplicate)
                        {
                            list2.RemoveAt(index);
                        }
                    }
                }
                else
                {
                    index = UnityEngine.Random.Range(0, list.Count);
                    monsterType2 = (int)list[index];
                    if (!openPackCanHaveDuplicate)
                    {
                        list.RemoveAt(index);
                    }
                }
                CardData cardData = m_CardDataPool[num19];
                if (isSecondaryRolledData)
                {
                    cardData = m_CardDataPool2[num19];
                }
                cardData.monsterType = monsterType2;
                if (UnityEngine.Random.Range(0, 10000) < Mathf.RoundToInt(num12 * 100f))
                {
                    cardData.isFoil = true;
                    m_HasFoilCard = true;
                }
                else
                {
                    cardData.isFoil = false;
                }
                if (CPlayerData.m_TutorialIndex < 10 && CPlayerData.m_GameReportDataCollectPermanent.cardPackOpened == 0 && !m_HasFoilCard && num19 == num18 - 1)
                {
                    cardData.isFoil = true;
                    m_HasFoilCard = true;
                }
                bool flag2 = false;
                if (UnityEngine.Random.Range(0, 10000) < Mathf.RoundToInt(num17 * 100f))
                {
                    borderType = ECardBorderType.FullArt;
                    flag2 = true;
                }
                if (!flag2 && UnityEngine.Random.Range(0, 10000) < Mathf.RoundToInt(num16 * 100f))
                {
                    borderType = ECardBorderType.EX;
                    flag2 = true;
                }
                if (!flag2 && UnityEngine.Random.Range(0, 10000) < Mathf.RoundToInt(num15 * 100f))
                {
                    borderType = ECardBorderType.Gold;
                    flag2 = true;
                }
                if (!flag2 && UnityEngine.Random.Range(0, 10000) < Mathf.RoundToInt(num14 * 100f))
                {
                    borderType = ECardBorderType.Silver;
                    flag2 = true;
                }
                if (!flag2 && UnityEngine.Random.Range(0, 10000) < Mathf.RoundToInt(num13 * 100f))
                {
                    borderType = ECardBorderType.FirstEdition;
                    flag2 = true;
                }
                if (!flag2 || cardExpansionType == ECardExpansionType.Ghost)
                {
                    borderType = ECardBorderType.Base;
                }
                cardData.borderType = borderType;
                cardData.expansionType = cardExpansionType;
                if (cardData.expansionType == ECardExpansionType.Tetramon)
                {
                    cardData.isDestiny = false;
                }
                else if (cardData.expansionType == ECardExpansionType.Destiny)
                {
                    cardData.isDestiny = true;
                }
                else if (cardData.expansionType == ECardExpansionType.Ghost)
                {
                    int num25 = UnityEngine.Random.Range(0, 100);
                    cardData.isDestiny = (num25 < 50);
                }
                else
                {
                    cardData.isDestiny = false;
                }
                if (isSecondaryRolledData)
                {
                    m_SecondaryRolledCardDataList.Add(cardData);
                }
                else
                {
                    m_RolledCardDataList.Add(cardData);
                    m_CardValueList.Add(GetCardMarketPrice(cardData));
                }
                num19++;
            }
            list.Clear();
            list2.Clear();
            list3.Clear();
            list4.Clear();
            list5.Clear();
            if (CPlayerData.m_GameReportDataCollectPermanent.cardPackOpened % 10 == 9)
            {
                GC.Collect();
            }
        }
        // Get Card Market Price
        public static float GetCardMarketPrice(CardData cardData)
        {
            int cardSaveIndex = GetCardSaveIndex(cardData);
            if (cardData.expansionType == ECardExpansionType.Tetramon)
            {
                return CPlayerData.m_GenCardMarketPriceList[cardSaveIndex].GetMarketPrice();
            }
            if (cardData.expansionType == ECardExpansionType.Destiny)
            {
                return CPlayerData.m_GenCardMarketPriceListDestiny[cardSaveIndex].GetMarketPrice();
            }
            if (cardData.expansionType == ECardExpansionType.Ghost)
            {
                if (cardData.isDestiny)
                {
                    return CPlayerData.m_GenCardMarketPriceListGhost[cardSaveIndex].GetMarketPrice();
                }
                return CPlayerData.m_GenCardMarketPriceListGhostBlack[cardSaveIndex].GetMarketPrice();
            }
            else
            {
                if (cardData.expansionType == ECardExpansionType.Megabot)
                {
                    return CPlayerData.m_GenCardMarketPriceListMegabot[cardSaveIndex].GetMarketPrice();
                }
                if (cardData.expansionType == ECardExpansionType.FantasyRPG)
                {
                    return CPlayerData.m_GenCardMarketPriceListFantasyRPG[cardSaveIndex].GetMarketPrice();
                }
                if (cardData.expansionType == ECardExpansionType.CatJob)
                {
                    return CPlayerData.m_GenCardMarketPriceListCatJob[cardSaveIndex].GetMarketPrice();
                }
                return 0f;
            }
        }
        // Get Card Save Index
        public static int GetCardSaveIndex(CardData cardData)
        {
            int num = 0;
            for (int i = 0; i < GetShownCardList(cardData.expansionType).Count; i++)
            {
                if (GetShownCardList(cardData.expansionType)[i].ID == cardData.monsterType)
                {
                    num = (int)(i * CPlayerData.GetCardAmountPerMonsterType(cardData.expansionType) + cardData.borderType);
                    break;
                }
            }
            if (cardData.isFoil)
            {
                num += CPlayerData.GetCardAmountPerMonsterType(cardData.expansionType, includeFoilCount: false);
            }
            return num;
        }
    }
}
