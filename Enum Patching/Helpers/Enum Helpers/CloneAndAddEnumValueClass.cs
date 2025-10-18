using Mono.Cecil;
using System;
using System.Linq;

namespace Enum_Patching.Helpers.Enum_Helpers
{
	public class CloneAndAddEnumValueClass
	{
		/// <summary>
		/// This will clone an existing value to the enum and than add it tp the enum.
		/// </summary>
		/// <param name="enumType">The enum in which things are being modified.</param>
		/// <param name="existingFieldName">The name of the key being cloned.</param>
		/// <param name="newFieldName">The name of the new key in which the clone will be called.</param>
		/// <param name="newValue">The value in which the new key will be set to.</param>
		/// <returns>A selection of nodes from the tree following the path.</returns>
		/// This code is provided by the amazing dark dragoon on nexus mods and discord.
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

			Console.WriteLine($"Successfully cloned and added new enum value: '{newFieldName}' = {newValue} to Enum: {enumType}.");
		}
	}
}