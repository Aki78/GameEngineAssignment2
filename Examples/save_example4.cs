using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SaveGameObjects(List<GameObjectData> gameObjectsData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameObjectsData);
        stream.Close();
    }

    public static List<GameObjectData> LoadGameObjects()
    {
        string path = Application.persistentDataPath + "/game.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<GameObjectData> gameObjectsData = formatter.Deserialize(stream) as List<GameObjectData>;
            stream.Close();

            return gameObjectsData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

