using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    [HarmonyPatch(typeof(MonsterData_ScriptableObject))]
    internal class AddCardPatch
    {
        private static CardHandler cardHandler = new CardHandler(); // Correct instantiation
        private static EnumListScript enumListScript = new EnumListScript(); // Correct instantiation
        [HarmonyPrefix]
        public static string GetMonsterDataPrefix(ref string monsterType)
        {
            // Use a separate list for enumeration
            var cardsTotal = enumListScript.CardsTotal.ToList(); // Create a temporary list for safe enumeration
            for (int i = 0; i < cardsTotal.Count; i++)
            {
                if (cardsTotal[i] == monsterType)
                {
                    return cardsTotal[i]; // Return the matched string
                }
            }
            return cardsTotal.Count > 0 ? cardsTotal[0] : null; // Return the first card if no match is found
        }
        /*

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
        */
        [HarmonyPrefix]
        public static bool GetCardFrontSprite(EElementIndex elementIndex, ref Sprite __result, object __instance)
        {
            // Access the m_CardFrontImageList field directly
            var m_CardFrontImageList = Traverse.Create(__instance).Field("m_CardFrontImageList").GetValue<List<Sprite>>();

            // Clear the original list directly
            m_CardFrontImageList.Clear();

            // Populate the list with the current card portraits
            for (int i = 0; i < cardHandler.CardPortraits.Count; i++)
            {
                if (cardHandler.CardPortraits[i] != null) // Check for null values
                {
                    m_CardFrontImageList.Add(cardHandler.CardPortraits[i]);
                }
            }

            if ((int)elementIndex >= 0 && (int)elementIndex < m_CardFrontImageList.Count)
            {
                __result = m_CardFrontImageList[(int)elementIndex];
            }
            else
            {
                __result = null; // Handle out of bounds case
            }

            return false; // Skip original method
        }
        /*
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
        */
    }
    // ToDO: Add Art stuff as well as the other elements of the MonsterData classes.
}
