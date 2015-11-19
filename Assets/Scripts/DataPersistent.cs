using UnityEngine;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public class DataPersistent : MonoBehaviour {

    public static Data data = new Data();

    public static void Save(Data data)
    {
        SetEnvironment();
        BinaryFormatter buffer = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "myfile.gd");
        DataPersistent.data = data;
        buffer.Serialize(file, DataPersistent.data);
        file.Close();
    }

    public static void Load()
    {
        SetEnvironment();
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "myfile.gd"))
        {
            BinaryFormatter buffer = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "myfile.gd", FileMode.Open);
            DataPersistent.data = (Data) buffer.Deserialize(file);
            file.Close();
        }
    }

    public static void ClearScoresActivities()
    {
        Data data = new Data();
        Save(data);
    }

    private static void SetEnvironment()
    {
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
    }
}
