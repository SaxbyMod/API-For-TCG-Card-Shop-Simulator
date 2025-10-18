using System.IO;
using UnityEngine;

namespace API.Helpers.Pathing
{
	public class DebugCheckForFiles
	{
		public static void CheckForFiles(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
			{
				Debug.LogWarning($"Directory does not exist: {directoryPath}");
				return;
			}

			// Get all files in the directory (you can filter for *.png if needed)
			string[] files = Directory.GetFiles(directoryPath, "*.png");

			foreach (string file in files)
			{
				Debug.Log($"Found file: {file}");
			}

			// Optionally, also list subdirectories
			string[] subDirs = Directory.GetDirectories(directoryPath);
			foreach (string dir in subDirs)
			{
				Debug.Log($"Found subdirectory: {dir}");
			}
		}
	}
}