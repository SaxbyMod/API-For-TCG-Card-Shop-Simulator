using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.Scripts
{
    public class CustomCard
    {
        public string Set { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public Sprite Icon { get; set; }
        public Sprite GhostIcon { get; set; }
        public string NextEvolution { get; set; }
        public string PreviousEvolution { get; set; }
        public List<string> Effects { get; set; }
        public string Rarity { get; set; }
        public string Element { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Skills { get; set; }
        public List<int> Stats { get; set; }
    };

    public class CardHandlingNew
    {
        public static Dictionary<string, List<CustomCard>> ModdedMonsterData = new Dictionary<string, List<CustomCard>> { };

        public static void CreateNewData(string set, string name, string prefix, string artist, string description, List<Sprite> Icons, string NextEvolution, string PreviousEvolution, List<string> Effects, string Rarity, string Element, List<string> Roles, List<string> Skills, List<int> Stats)
        {
            // Create New ID into Set Dict's
            string ID = prefix + name;
            int Count = EnumListScript.SetDict[set].Count;
            EnumListScript.SetDict[set].Add(ID, Count + 1);
            Console.WriteLine("ID Inserted for " + EnumListScript.SetDict[set][ID]);

            //
        }
    }

    public static class ImageLoader
    {
        // Load a custom texture from the specified path
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

        // Load a custom PNG texture from the specified path
        public static Texture2D LoadCustomPNG(string fileName, string imagePath)
        {
            return LoadCustomTexture(fileName, imagePath); // Reuse LoadCustomTexture for PNG files
        }

        // Create a Sprite from a custom image file
        public static Sprite GetCustomImage(string fileName, string imagePath)
        {
            Texture2D texture2D = LoadCustomPNG(fileName, imagePath);
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
