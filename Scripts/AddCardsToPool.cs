using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace API_For_TCG_Card_Shop_Simulator.Scripts
{
    internal class CardHandler
    {
        // Instance field for the dictionary
        public Dictionary<string, (string CardEnum, string Set)> ModdedCards =
            new Dictionary<string, (string CardEnum, string Set)>();

        // This method should not be static to access the instance variable
        public void AddCardsToPool(string ModPrefix, string CardName, string ImagePath, string CardSet)
        {
            // Combine ModPrefix and CardName to form the key
            string CardEnum = ModPrefix + "_" + CardName;
            string Set = CardSet;
            // Add to the dictionary with the key and tuple value
            ModdedCards.Add(CardEnum, (CardEnum, CardSet));
        }
    }
}
