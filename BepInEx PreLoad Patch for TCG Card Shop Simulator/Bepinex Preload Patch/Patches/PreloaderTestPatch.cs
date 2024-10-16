using TCGShopNewCardsModPreloader.Handlers;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TCGShopNewCardsModPreloader.Patches
{
    internal class NewCardsPatch
    {
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll" };

        public static void Patch(AssemblyDefinition assembly)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Starting Patching");
            Console.ResetColor();
            var monsterType = assembly.MainModule.Types.First(t => t.Name == "EMonsterType");
            if (monsterType != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Found MonsterType Enum trying to modify it");
                Console.ResetColor();
            }
            else if (monsterType == null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("--- ERROR --- MonsterType Enum is NULL");
                Console.ResetColor();
            }
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Done Patching");
            Console.ResetColor();
        }
    }
}
