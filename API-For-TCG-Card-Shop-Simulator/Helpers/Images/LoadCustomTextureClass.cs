using UnityEngine;
using System.IO;

namespace API.Helpers.Images
{
	public class LoadCustomTextureClass
	{
		/// <summary>
		/// This is a simple function that converts a file into a Texture2D
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <param name="imagePath">The path to the file.</param>
		/// <returns>A Texture2D of the inputted Image</returns>
		/// This code is provided by the amazing dark dragoon on nexus mods and discord.
		public static Texture2D LoadCustomTexture(string fileName, string imagePath)
		{
			string imageToLoad = Path.Combine(imagePath, fileName + ".png");
			if (File.Exists(imageToLoad))
			{
				byte[] data = File.ReadAllBytes(imageToLoad);
				Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, false); // Use RGBA32 format for better color representation
				texture2D.LoadImage(data);
				return texture2D;
			}
			Debug.LogWarning($"Texture not found at path: {imageToLoad}");
			return null;
		}
	}
}