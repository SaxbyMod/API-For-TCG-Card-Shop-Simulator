using API_For_TCG_Card_Shop_Simulator.Cards;
using API_For_TCG_Card_Shop_Simulator.Helpers;
using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetCustomCard
    {
        public static MonsterDataModded GetCustomCardFunc(int monsterType)
        {
            if (monsterType == 0 || (monsterType >= (int)EnumListScript.MonsterMax["Tetramon"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["CatJob"]))
            {
                return null;
            }
            if (monsterType < (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatchWithType.GetCustomCardMatchWithTypeFunc(CardHandlingNew.ModdedMonsterData["Tetramon"], CardHandlingNew.ModdedMonsterData["Tetramon"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatchWithType.GetCustomCardMatchWithTypeFunc(CardHandlingNew.ModdedMonsterData["Megabot"], CardHandlingNew.ModdedMonsterData["Megabot"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatchWithType.GetCustomCardMatchWithTypeFunc(CardHandlingNew.ModdedMonsterData["FantasyRPG"], CardHandlingNew.ModdedMonsterData["FantasyRPG"][monsterType]);
            }
            if (monsterType > (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"] && monsterType < (int)EnumListScript.MonsterMax["CatJob"] + (int)EnumListScript.MonsterMax["FantasyRPG"] + (int)EnumListScript.MonsterMax["Megabot"] + (int)EnumListScript.MonsterMax["Tetramon"])
            {
                return GetCustomCardMatchWithType.GetCustomCardMatchWithTypeFunc(CardHandlingNew.ModdedMonsterData["Catjob"], CardHandlingNew.ModdedMonsterData["Catjob"][monsterType]);
            }

            return null;
        }
    }
}
