using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGameObjects(List<GameObjectData> gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static List<GameObjectData> LoadGameObjects()
    {
        string path = Application.persistentDataPath + "/game.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

//            List<GameObjectData> gameData = formatter.Deserialize(stream) as GameObjectData;
            List<GameObjectData> gameData = formatter.Deserialize(stream) as List<GameObjectData>;

//            List <GameObjectData> gameData = null;
            stream.Close();

            return gameData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

//EXAMPLES:


//[System.Serializable]
//public class GameData
//{
//    public int score;
//    public int level;
//}
