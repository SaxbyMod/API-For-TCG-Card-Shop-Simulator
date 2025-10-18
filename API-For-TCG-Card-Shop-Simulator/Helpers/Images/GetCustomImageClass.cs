using UnityEngine;

namespace API.Helpers.Images
{
	public class GetCustomImageClass
	{
		/// <summary>
		/// This gets a sprite from the passed in file, specifically a PNG.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <param name="imagePath">The path to the file.</param>
		/// <returns>A Sprite of the inputted Image</returns>
		/// This code is provided by the amazing dark dragoon on nexus mods and discord.
		public static Sprite GetCustomImage(string fileName, string imagePath)
		{
			Texture2D texture2D = LoadCustomPNGClass.LoadCustomPNG(fileName, imagePath);
			if (texture2D != null)
			{
				Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
				sprite.name = fileName; // Name the sprite for easy identification
				return sprite;
			}
			Debug.LogWarning($"Sprite creation failed for: {fileName} at path: {imagePath}");
			return null;
		}
	}
}