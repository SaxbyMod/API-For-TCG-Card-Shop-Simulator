using UnityEngine;

namespace API.Helpers.Images
{
	public class LoadCustomPNGClass
	{
		/// <summary>
		/// This essentially is LoadCustomTexture but from a PNG File.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <param name="imagePath">The path to the file.</param>
		/// <returns>A Texture2D of the inputted Image</returns>
		/// This code is provided by the amazing dark dragoon on nexus mods and discord.
		public static Texture2D LoadCustomPNG(string fileName, string imagePath)
		{
			return LoadCustomTextureClass.LoadCustomTexture(fileName, imagePath); // Reuse LoadCustomTexture for PNG files
		}
	}
}