using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class GameSavingSystem 
{
   public static void SaveGame(SaveController save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        gameData data = new gameData(save);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static gameData LoadGame()
    {
        string path = Application.persistentDataPath + "player.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            gameData data = formatter.Deserialize(stream) as gameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save file not found in" + path);
            return null;
        }
    }
}
