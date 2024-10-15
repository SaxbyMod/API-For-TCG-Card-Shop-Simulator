using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(MonsterData_ScriptableObject))]
    internal class AddCardPatch
    {
        private static CardHandler cardHandler = new CardHandler(); // Correct instantiation
        private static RarityScript rarityScript = new RarityScript(); // Correct instantiation
        [HarmonyPrefix]
        public static string GetMonsterDataPrefix(ref string monsterType)
        {
            // Loop through each card in CardsTotal
            for (int i = 0; i < cardHandler.CardsTotal.Count; i++)
            {
                // Compare the current card with the provided monsterType
                if (cardHandler.CardsTotal.ToList()[i] == monsterType)
                {
                    return cardHandler.CardsTotal.ToList()[i]; // Return the matched string
                }
            }
            // Return the first card if no match is found, or null if the list is empty
            return cardHandler.CardsTotal.ToList().Count > 0 ? cardHandler.CardsTotal.ToList()[0] : null;
        }

        [HarmonyPrefix]
        public static bool GetCardBorderSprite(ERarity rarity, ref Sprite __result, object __instance)
        {
            // Assuming m_CardBorderList is a field of the class where this method is being patched
            var m_CardBorderList = Traverse.Create(__instance).Field("m_CardBorderList").GetValue<List<Sprite>>();

            __result = m_CardBorderList[(int)rarity];
            return false; // Skip original method
        }

        [HarmonyPrefix]
        public static bool GetCardBGSprite(EElementIndex element, ref Sprite __result, object __instance)
        {
            var m_CardBGList = Traverse.Create(__instance).Field("m_CardBGList").GetValue<List<Sprite>>();

            if (element == EElementIndex.None)
            {
                __result = null;
                return false; // Skip original method
            }

            __result = m_CardBGList[(int)element];
            return false; // Skip original method
        }

        [HarmonyPrefix]
        public static bool GetCardFrontSprite(EElementIndex elementIndex, ref Sprite __result, object __instance)
        {
            // Access the m_CardFrontImageList field directly
            var m_CardFrontImageList = Traverse.Create(__instance).Field("m_CardFrontImageList").GetValue<List<Sprite>>();

            // Clear the original list directly
            m_CardFrontImageList.Clear();

            // Ensure cardHandler is properly initialized and accessible
            for (int i = 0; i < cardHandler.CardsTotal.Count; i++)
            {
                // Ensure that CardPortraits is valid and has the expected number of elements
                if (i < cardHandler.CardPortraits.Count) // No need to convert to List
                {
                    m_CardFrontImageList.Add(cardHandler.CardPortraits[i]); // Access directly
                }
            }

            // Ensure the index is within bounds before accessing the list
            if ((int)elementIndex >= 0 && (int)elementIndex < m_CardFrontImageList.Count) // No need to convert to List
            {
                __result = m_CardFrontImageList[(int)elementIndex]; // Access directly
            }
            else
            {
                __result = null; // or handle the error case as appropriate
            }

            // Skip original method
            return false;
        }

        [HarmonyPrefix]
        public static bool GetCardBackSprite(ECardExpansionType cardExpansionType, ref Sprite __result, object __instance)
        {
            var m_CardBackImageList = Traverse.Create(__instance).Field("m_CardBackImageList").GetValue<List<Sprite>>();

            __result = m_CardBackImageList[(int)cardExpansionType];
            return false; // Skip original method
        }

        [HarmonyPrefix]
        public static bool GetCardFoilMaskSprite(ECardExpansionType cardExpansionType, ref Sprite __result, object __instance)
        {
            var m_CardFoilMaskImageList = Traverse.Create(__instance).Field("m_CardFoilMaskImageList").GetValue<List<Sprite>>();

            __result = m_CardFoilMaskImageList[(int)cardExpansionType];
            return false; // Skip original method
        }


    }
    // ToDO: Add Art stuff as well as the other elements of the MonsterData classes.
}
