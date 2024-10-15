using BepInEx.Preloader.RuntimeFixes;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Bepinex_Preload_Patch.Patches
{
    internal class PreloaderTestPatch
    {
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll" };
        
        public static void Patch(AssemblyDefinition assembly)
        {
            Console.WriteLine("Starting Patching");
            // Find the enum type
            var monsterType = assembly.MainModule.Types.First(t => t.Name == "EMonsterType");

            if (monsterType != null)
            {
                Console.WriteLine("Found monster type");
            } else if (monsterType != null)
            {
                Console.WriteLine("NULL monster type");
            }

            ModifyEnumValue(monsterType, "MAX", 124);
            CloneAndAddEnumValue(monsterType, "FireChickenB", "Lairon", 122);
            CloneAndAddEnumValue(monsterType, "FireChickenB", "Aggron", 123);

            // Save the changes
            Console.WriteLine("Done Patching");
        }

        private static void ModifyEnumValue(TypeDefinition enumType, string fieldName, int newValue)
        {
            var enumField = enumType.Fields.FirstOrDefault(f => f.Name == fieldName);
            if (enumField != null)
            {
                enumField.Constant = newValue; // Set the new constant value
                Console.WriteLine($"Changed {fieldName} value to {newValue}.");
            }
        }     

        private static void CloneAndAddEnumValue(TypeDefinition enumType, string existingFieldName, string newFieldName, int newValue)
        {
            // Find the existing enum field
            var existingField = enumType.Fields.FirstOrDefault(f => f.Name == existingFieldName);
            if (existingField == null)
            {
                Console.WriteLine($"Existing field '{existingFieldName}' not found in enum '{enumType.Name}'.");
                return;
            }

            // Create a new FieldDefinition for the new enum value
            var newEnumValue = new FieldDefinition(
                newFieldName,
                existingField.Attributes, // Copy attributes
                enumType
            );

            // Set the new constant value
            newEnumValue.Constant = newValue;

            // Add the new field to the enum type
            enumType.Fields.Add(newEnumValue);

            Console.WriteLine($"Successfully cloned and added new enum value: '{newFieldName}' = {newValue}.");
        }
    }
}
