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
            var rarity = assembly.MainModule.Types.First(t => t.Name == "ERarity");
            var skill = assembly.MainModule.Types.First(t => t.Name == "ESkill");
            var elementIndex = assembly.MainModule.Types.First(t => t.Name == "EElementIndex");
            var monsterRole = assembly.MainModule.Types.First(t => t.Name == "EMonsterRole");

            if (monsterType != null)
            {
                Console.WriteLine("Found monster type");
            } else if (monsterType == null)
            {
                Console.WriteLine("NULL monster type");
            }

            ModifyEnumValue(monsterType, "MAX", 124);

            // Save the changes
            Console.WriteLine("Done Patching");
        }

        public static void ModifyEnumValue(TypeDefinition enumType, string fieldName, int newValue)
        {
            var enumField = enumType.Fields.FirstOrDefault(f => f.Name == fieldName);
            if (enumField != null)
            {
                enumField.Constant = newValue; // Set the new constant value
                Console.WriteLine($"Changed {fieldName} value to {newValue}.");
            }
        }     

        public static void CloneAndAddEnumValue(TypeDefinition enumType, string existingFieldName, string newFieldName, int newValue)
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

        public static void AddEnumValueAtEnd(TypeDefinition enumType, string newFieldName)
        {
            // Find the max current enum value
            var maxEnumValue = enumType.Fields
                .Where(f => f.HasConstant)
                .Max(f => (int)f.Constant);

            // Define the new value as one greater than the max
            int newEnumValue = maxEnumValue + 1;

            // Create a new FieldDefinition for the new enum value
            var newEnumField = new FieldDefinition(
                newFieldName,
                Mono.Cecil.FieldAttributes.Public | Mono.Cecil.FieldAttributes.Static | Mono.Cecil.FieldAttributes.Literal,
                enumType.Module.ImportReference(typeof(int))
            );

            // Set the constant value of the new field
            newEnumField.Constant = newEnumValue;

            // Add the new field to the enum type
            enumType.Fields.Add(newEnumField);

            Console.WriteLine($"Successfully added new enum value: '{newFieldName}' = {newEnumValue}.");
        }
    }
}
