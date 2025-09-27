using Mono.Cecil;
using System;
using System.Linq;

namespace Enum_Patching.Helpers.Enum_Helpers
{
	public class ModifyEnumValueClass
	{
		/// <summary>
		/// This will modify a enum's key to equal a new value.
		/// </summary>
		/// <param name="enumType">The enum in which things are being modified.</param>
		/// <param name="fieldName">The name of the key in which is being changed.</param>
		/// <param name="newValue">The value in which the key will be set to.</param>
		/// <returns>A selection of nodes from the tree following the path.</returns>
		/// This code is provided by the amazing dark dragoon on nexus mods and discord.
		public static void ModifyEnumValue(TypeDefinition enumType, string fieldName, int newValue)
		{
			var enumField = enumType.Fields.FirstOrDefault(f => f.Name == fieldName);
			if (enumField != null)
			{
				enumField.Constant = newValue; // Set the new constant value
				Console.WriteLine($"Changed {fieldName} value to {newValue}.");
			}
		}     
	}
}