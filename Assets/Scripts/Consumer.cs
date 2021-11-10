using System;
using System.Xml.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Consumer
{
    private IDataStore _dataStore;

    public Consumer(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public void Save()
    {
        Data data = new Data("Hola", 4545);
        _dataStore.SetData(data, "data2");
    }

    public void Load()
    {
        Data data = _dataStore.GetData<Data>("data2");
        Debug.Log(data.Data1);
        Debug.Log(data.Data2);
    }
}