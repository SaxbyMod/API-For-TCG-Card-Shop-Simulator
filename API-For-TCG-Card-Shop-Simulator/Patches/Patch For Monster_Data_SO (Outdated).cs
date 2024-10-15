using API_For_TCG_Card_Shop_Simulator.Scripts;
using HarmonyLib;

[HarmonyPatch(typeof(MonsterData_ScriptableObject))]
[HarmonyPatch("GetMonsterData")]
public class Patch_GetMonsterData
{
    // Prefix method that will run before GetMonsterData
    [HarmonyPrefix]
    public static bool Prefix(ref MonsterData __result, string monsterType, MonsterData_ScriptableObject __instance)
    {
        // Step 1: Search in the m_DataList
        for (int i = 0; i < __instance.m_DataList.Count; i++)
        {
            if (__instance.m_DataList[i].MonsterType.ToString() == monsterType)
            {
                __result = __instance.m_DataList[i];  // Set the result directly
                return false;  // Skip the original method
            }
        }

        // Step 2: Instantiate CardHandler since it's not part of the class
        CardHandler cardHandler = new CardHandler();

        // Step 3: Search in the _monsterDataDict of the newly instantiated cardHandler
        if (cardHandler._monsterDataDict.TryGetValue(monsterType, out MonsterData monsterData))
        {
            __result = monsterData;  // Set the result to the value from the dictionary
            return false;  // Skip the original method
        }

        // Step 4: Fallback if no match is found
        __result = __instance.m_DataList[0];  // Return the first element of m_DataList
        return false;  // Skip original method
    }
}
