using API_For_TCG_Card_Shop_Simulator.Cards;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetShownCardList
    {

        public static Dictionary<int, MonsterDataModded> GetShownCardListFunc(ECardExpansionType expansionType)
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
    }
}
