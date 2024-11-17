using HarmonyLib;
using System;
using System.Collections.Generic;
using TCGShopNewCardsModPreloader.Handlers;

namespace TCGShopNewCardsMod.Patches
{
    [HarmonyPatch]
    internal class MonsterDataPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(InventoryBase), "GetMonsterData")]
        public static bool GetMonsterData(EMonsterType monsterType, ref MonsterData __result)
        {
            if (monsterType == EMonsterType.None)
            {
                __result = null;
                return false;
            };

            /* Trace table for this loop
            var1, var2
            0, tetramonMax
            tetramonMax
            tetramonMax, megabotMax
            megabotMax
            megabotMax, fantasyRPGMax
            fantasyRPGMax
            fantasyRPGMax, catJobMax
            catJobMax
            */

            // CustoemrMonsterHandler static values is now a list of Objects with name and max properties

            var var1 = new CustomMonsterAttribute() { Name = "test", MaxValue = 0 };
            for (int i = 0; i < CustomMonsterHandler.monsterMax.Count; i++)
            {

                var var2 = CustomMonsterHandler.monsterMax[i];

                if (monsterType > (EMonsterType)var1.MaxValue && monsterType < (EMonsterType)var2.MaxValue)
                {
                    // var2 has string containing relevant monster name, could use Reflection to find monster data list
                    var logicalExpansionName = var2.Name;
                    List<MonsterData> monsterList = new List<MonsterData>();
                    var propertyInfo = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetType().GetProperty("m_" + logicalExpansionName + "DataList");
                    Console.WriteLine($"getting datalist {propertyInfo.Name}");
                    if (propertyInfo != null)
                    {
                        Console.WriteLine($"datalist found");
                        monsterList = (List<MonsterData>)propertyInfo.GetValue(CSingleton<InventoryBase>.Instance.m_MonsterData_SO);
                        __result = InventoryBase.GetMonsterDataMatchWithType(monsterList, monsterType);
                    }
                    else
                    {
                        // Could not find property, return null
                        Console.WriteLine($"datalist not found");
                        __result = null;
                    }

                    return false;
                }
                var1 = var2;

            }
            __result = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_DataList[(int)monsterType];
            return false;
        }
    }
}
