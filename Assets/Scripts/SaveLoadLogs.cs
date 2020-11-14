using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadLogs 
{
    static string path = Application.persistentDataPath + "/Logs.fun";
    public static void SaveLogs(SuperLogger logsData)
    {
        Debug.LogError("HOLA ESTOY GUARDANDO");
        Debug.Log(path);
        BinaryFormatter formatter = new BinaryFormatter();
        
        FileStream stream = new FileStream(path, FileMode.Create);

        LogsData data = new LogsData(logsData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LogsData LoadLogs()
    {
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            LogsData data = formatter.Deserialize(stream) as LogsData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
