using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Ujson<T>
{
    public static void Write(string path, T objectData)
    {
        path = Application.dataPath + "/" + path;
        JsonData jsonData = JsonMapper.ToJson(objectData);
        File.WriteAllText(path, jsonData.ToString());
    }
    public static T Read(string path)
    {
        T objectData;
        string jsonData = File.ReadAllText(path);
        objectData = LitJson.JsonMapper.ToObject<T>(jsonData);
        return objectData;
    }

}
