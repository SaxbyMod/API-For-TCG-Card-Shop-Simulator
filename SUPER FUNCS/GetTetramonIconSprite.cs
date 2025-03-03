using API_For_TCG_Card_Shop_Simulator.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetTetramonIconSprite
    {
        public static Sprite GetTetramonIconSpriteFunc(int monsterType)
        {
            return CardHandlingNew.CustomCards[monsterType].Icon;
        }
    }
}
