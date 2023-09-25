using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame (Game_Manager gameManager, AudioManager audioManager)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/player.fun";

        FileStream stream = InitializeStream(path);

        PlayerData data = new(gameManager, audioManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGame(Game_Manager gameManager, AudioManager audioManager)
    {
        string path = Application.persistentDataPath + "/player.fun";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = InitializeStream(path);
            // stream.SetLength(0);
            
            if(stream.Length == 0) {
                SaveGame(gameManager, audioManager);
                stream = InitializeStream(path);
            }
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
           
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    private static FileStream InitializeStream(string path) {
        return new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite,  FileShare.ReadWrite);
    }
    
}
