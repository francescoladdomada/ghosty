using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine;

public static class Persistency {

	private static string filename = "PlayerData.bat";

	public static void Save(PlayerData playerData) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/" + filename);
		bf.Serialize(file, playerData);
		file.Close();
	}

	public static PlayerData Load() {
		PlayerData playerData = new PlayerData();
		if(File.Exists(Application.persistentDataPath + "/" + filename)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/" + filename, FileMode.Open);
			playerData = (PlayerData)bf.Deserialize(file);
			file.Close();
		}
		return playerData;
	}

	public static void Delete() {
		if (File.Exists (Application.persistentDataPath + "/" + filename)) {
			File.Delete( Application.persistentDataPath + "/" + filename );
			RefreshEditorProjectWindow();
		}
	}

	public static void RefreshEditorProjectWindow() 
	{
		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
		#endif
	}
}
