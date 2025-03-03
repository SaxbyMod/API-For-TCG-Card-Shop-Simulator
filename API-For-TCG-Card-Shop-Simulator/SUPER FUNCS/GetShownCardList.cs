using API_For_TCG_Card_Shop_Simulator.Cards;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetShownCardList
    {

        public static Dictionary<int, MonsterDataModded> GetShownCardListFunc(ECardExpansionType expansionType)
        {
            if (expansionType == ECardExpansionType.None || expansionType == ECardExpansionType.MAX)
            {
                throw new ArgumentException("Invalid expansion type.");
            }

            if (expansionType == ECardExpansionType.Destiny || expansionType == ECardExpansionType.Ghost)
            {
                return CardHandlingNew.ModdedMonsterData["Tetramon"];
            }

            string expansionName = expansionType.ToString();

            if (CardHandlingNew.ModdedMonsterData.ContainsKey(expansionName))
            {
                return CardHandlingNew.ModdedMonsterData[expansionName];
            }

            return CardHandlingNew.ModdedMonsterData["Tetramon"];
        }
    }
}