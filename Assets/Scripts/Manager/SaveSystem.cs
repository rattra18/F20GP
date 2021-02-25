using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveGame(GameManager gameManager)
    {
        //when called to save, all the variables are serialized and written using a binary formatter and filestream to the /game.save filepath
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        GameData data = new GameData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        //looks for any exisiting game.save file path, and extracts the information doing the reverse of save
        string path = Application.persistentDataPath + "/game.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
