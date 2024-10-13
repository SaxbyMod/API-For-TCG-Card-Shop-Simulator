using HarmonyLib;
using System.Reflection;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
    [HarmonyPatch(typeof )]
    internal class AddCard
    {
        // the return type of factory methods can be either MethodInfo or DynamicMethod
        [HarmonyPrefix]
        static MethodInfo PrefixFactory(MethodBase originalMethod)
        {
            // return an instance of MethodInfo or an instance of DynamicMethod
        }

        [HarmonyPostfix]
        static MethodInfo PostfixFactory(MethodBase originalMethod)
        {
            // return an instance of MethodInfo or an instance of DynamicMethod
        }
    }
}
}
