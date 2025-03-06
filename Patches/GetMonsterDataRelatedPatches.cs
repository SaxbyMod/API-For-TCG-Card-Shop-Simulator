// using HarmonyLib;
// using UnityEngine;
// using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
//
// namespace API_For_TCG_Card_Shop_Simulator.Patches
// {
//     [HarmonyPatch]
//     public class GetMonsterDataRelatedPatches
//     {
//         public static int CardFameAmount = 0;
//         [HarmonyPrefix, HarmonyPatch(typeof(CPlayerData), nameof(CPlayerData.GetCardFameAmount))]
//         public static bool GetCardFameAmount(CardData cardData)
//         {
//             if (cardData.expansionType == ECardExpansionType.Tetramon || cardData.expansionType == ECardExpansionType.Ghost || cardData.expansionType == ECardExpansionType.Tetramon)
//             {
//                 int num = 1;
//                 ERarity rarity = InventoryBasePatches.DataHandlers.GetTetramonData(cardData.monsterType).Rarity;
//                 if (cardData.GetCardBorderType() == ECardBorderType.Base)
//                     num = 1;
//                 else if (cardData.GetCardBorderType() == ECardBorderType.FirstEdition)
//                     num = 5;
//                 else if (cardData.GetCardBorderType() == ECardBorderType.Silver)
//                     num = 10;
//                 else if (cardData.GetCardBorderType() == ECardBorderType.Gold)
//                     num = 20;
//                 else if (cardData.GetCardBorderType() == ECardBorderType.EX)
//                     num = 50;
//                 else if (cardData.GetCardBorderType() == ECardBorderType.FullArt)
//                     num = 200;
//                 switch (rarity)
//                 {
//                     case ERarity.Common:
//                         num = num;
//                         break;
//                     case ERarity.Rare:
//                         num += 5;
//                         break;
//                     case ERarity.Epic:
//                         num += 15;
//                         break;
//                     case ERarity.Legendary:
//                         num += 40;
//                         break;
//                 }
//                 if (cardData.expansionType == ECardExpansionType.Tetramon)
//                     num = num;
//                 else if (cardData.expansionType == ECardExpansionType.Destiny)
//                     num = 9 + Mathf.RoundToInt((float)num * 1.25f);
//                 else if (cardData.expansionType == ECardExpansionType.Ghost)
//                     num = 18 + Mathf.RoundToInt((float)num * 2f);
//                 else if (cardData.expansionType == ECardExpansionType.Megabot)
//                     num = 13 + Mathf.RoundToInt((float)num * 1.4f);
//                 else if (cardData.expansionType == ECardExpansionType.FantasyRPG)
//                     num = 13 + Mathf.RoundToInt((float)num * 1.1f);
//                 else if (cardData.expansionType == ECardExpansionType.CatJob)
//                     num = 1 + Mathf.RoundToInt((float)num * 1.02f);
//                 int cardFameAmount = Mathf.RoundToInt((float)num * (float)(1.0 + (double)cardData.GetCardBorderType() * 0.25));
//                 if (cardData.isFoil)
//                     cardFameAmount = Mathf.RoundToInt((float)(cardFameAmount + ((int)(cardData.GetCardBorderType() + 1) * 5 * (int)(cardData.GetCardBorderType() + 1) + cardData.GetCardBorderType())) * 2.5f);
//             }
//             CardFameAmount = cardFameAmount;
//             return false;
//         }
//         
//     }
// }