using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveVolumeSystem
{
    public static void SaveVolume(float volume)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/volume.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, volume);
        stream.Close();
    }

    public static float LoadVolume()
    {
        string path = Application.persistentDataPath + "/volume.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            float volume = (float) formatter.Deserialize(stream);

            stream.Close();

            return volume;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return 0f;
        }
    }
}