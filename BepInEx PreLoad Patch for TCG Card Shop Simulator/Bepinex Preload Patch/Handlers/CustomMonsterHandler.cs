using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TCGShopNewCardsModPreloader.Handlers
{
    public class CustomMonsterHandler
    {

        public static int tetramonMax;
        public static int megabotMax;
        public static int fantasyRPGMax;
        public static int catJobMax;

        public static void ChangeMaxValues(TypeDefinition enumType, int MaxTetramon, int MaxMegabot, int MaxFantasyRPG, int MaxCatJob)
        {
            int maxTetramon = MaxTetramon;
            int maxMegabot = MaxMegabot;
            int maxFantasyRPG = MaxFantasyRPG;
            int maxCatJob = MaxCatJob;
            tetramonMax = maxTetramon;
            megabotMax = maxMegabot;
            fantasyRPGMax = maxFantasyRPG;
            catJobMax = maxCatJob;
            ModifyEnumValue(enumType, "MAX", maxTetramon);
            ModifyEnumValue(enumType, "MAX_MEGABOT", maxMegabot);
            ModifyEnumValue(enumType, "MAX_FANTASYRPG", maxFantasyRPG);
            ModifyEnumValue(enumType, "MAX_CATJOB", maxCatJob);
        }

        public static void ModifyEnumValue(TypeDefinition enumType, string fieldName, int newValue)
        {
            var enumField = enumType.Fields.FirstOrDefault(f => f.Name == fieldName);
            if (enumField != null)
            {
                enumField.Constant = newValue; // Set the new constant value
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Changed {fieldName} value to {newValue}.");
                Console.ResetColor();
            }
        }

        public static void CloneAndAddEnumValue(TypeDefinition enumType, string existingFieldName, string newFieldName, int newValue)
        {
            // Find the existing enum field
            var existingField = enumType.Fields.FirstOrDefault(f => f.Name == existingFieldName);
            if (existingField == null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("--- ERROR --- " + $"Existing field '{existingFieldName}' not found in enum '{enumType.Name}'.");
                Console.ResetColor();
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
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully added new enum value: '{newFieldName}' = {newValue}.");
            Console.ResetColor();
        }

        public static void AddNewMonstersToEnum(TypeDefinition enumType, Dictionary<string, (string MonsterType, int MonsterTypeID)> monsters)
        {
            foreach (var monster in monsters)
            {
                CloneAndAddEnumValue(enumType, "FireChickenB", monster.Value.MonsterType, monster.Value.MonsterTypeID);
            }
        }
    }
}
