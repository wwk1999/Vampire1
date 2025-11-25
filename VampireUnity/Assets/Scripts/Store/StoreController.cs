using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : XSingleton<StoreController>
{
    public StoreDefine.StoreData StoreData;
    public void SaveStoreData(StoreDefine.StoreData data)
    {
        Debug.Log("保存数据");
        
    }
    
    public void LoadStoreData()
    {
        Debug.Log("加载数据");
        
    }
}
