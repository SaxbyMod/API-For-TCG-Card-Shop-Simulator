using API_For_TCG_Card_Shop_Simulator.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetSpecialCardImage
    {
        public static Sprite GetSpecialCardImageFunc(int monsterType)
        {
            return CardHandlingNew.CustomCards[monsterType].GhostIcon;
        }
    }
}
