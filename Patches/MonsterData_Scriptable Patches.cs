using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
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
                if (cardHandler.CardsTotal[i] == monsterType)
                {
                    return cardHandler.CardsTotal[i]; // Return the matched string
                }
            }
            // Return the first card if no match is found, or null if the list is empty
            return cardHandler.CardsTotal.Count > 0 ? cardHandler.CardsTotal[0] : null;
        }
        /*
        [HarmonyPrefix]
        public Sprite GetCardBorderSprite(ERarity rarity)
        {
            return this.m_CardBorderList[(int)rarity];
        }

        [HarmonyPrefix]
        public Sprite GetCardBGSprite(EElementIndex element)
        {
            if (element == EElementIndex.None)
            {
                return null;
            }
            return this.m_CardBGList[(int)element];
        }

        [HarmonyPrefix]
        public Sprite GetCardFrontSprite(EElementIndex elementIndex)
        {
            return this.m_CardFrontImageList[(int)elementIndex];
        }

        [HarmonyPrefix]
        public Sprite GetCardBackSprite(ECardExpansionType cardExpansionType)
        {
            return this.m_CardBackImageList[(int)cardExpansionType];
        }

        [HarmonyPrefix]
        public Sprite GetCardFoilMaskSprite(ECardExpansionType cardExpansionType)
        {
            return this.m_CardFoilMaskImageList[(int)cardExpansionType];
        }
        */
    }
    // ToDO: Add Art stuff as well as the other elements of the MonsterData classes.
}
