using API_For_TCG_Card_Shop_Simulator.Cards;
using System.Collections.Generic;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetCustomCardMatchWithType {
        public static MonsterDataModded GetCustomCardMatchWithTypeFunc(Dictionary<int, CustomCard> listMonsterData, CustomCard monsterType)
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
    }
}
