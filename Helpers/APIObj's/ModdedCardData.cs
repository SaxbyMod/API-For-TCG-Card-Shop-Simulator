using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;

namespace API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s
{
      public class ModdedCardData
      {
            public class TetramonCardData : CardData
            {
                  public MonsterType.EMonsterTypeLocal monsterType;
            }

            public class MegabotCardData : CardData
            {
                  public MonsterType.EMegaBotType monsterType;
            }

            public class FantasyRPGCardData : CardData
            {
                  public MonsterType.EFantasyRPGType monsterType;
            }

            public class CatJobCardData : CardData
            {
                  public MonsterType.ECatJobType monsterType;
            }
      }
}