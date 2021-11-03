using System;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    private FileDataStoreAdapter fileDataStoreAdapter;
    
    private void Awake()
    {
        fileDataStoreAdapter = new FileDataStoreAdapter();
        Data data = new Data("Data1Prueba", 123);
        fileDataStoreAdapter.SetData(data, "Data1");
    }

    private void Start()
    {
        Data data = fileDataStoreAdapter.GetData<Data>("Data1");
        Debug.Log(data.Data1);
        Debug.Log(data.Data2);
    }
}