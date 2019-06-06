using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem 
{
    public static void Save(object obj)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.dat";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, obj);

        stream.Close();
    }

    public static object Load()
    {
        string path = Application.persistentDataPath + "/score.dat";

        if (!File.Exists(path)) return null;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        object result = formatter.Deserialize(stream);
        stream.Close();

        return result;
    }
}
