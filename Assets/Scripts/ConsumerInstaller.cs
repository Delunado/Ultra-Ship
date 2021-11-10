using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerInstaller : MonoBehaviour
{
    private void Awake()
    {
        var consumer = new Consumer(GetDataStore());
        consumer.Save();
        consumer.Load();
    }

    private IDataStore GetDataStore()
    {
        return new FileDataStoreAdapter();
    }
}
