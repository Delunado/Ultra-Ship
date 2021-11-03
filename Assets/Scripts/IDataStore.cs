using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Data
{
    public string Data1;
    public int Data2;

    public Data(string data1, int data2)
    {
        Data1 = data1;
        Data2 = data2;
    }
}

public interface IDataStore
{
    public void SetData<T>(T data, string name);
    public T GetData<T>(string name);
}

public class FileDataStoreAdapter : IDataStore
{
    public void SetData<T>(T data, string name)
    {
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.dataPath, name);
        File.WriteAllText(path, json);
    }

    public T GetData<T>(string name)
    {
        string path = Path.Combine(Application.dataPath, name);
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(json);
    }
}