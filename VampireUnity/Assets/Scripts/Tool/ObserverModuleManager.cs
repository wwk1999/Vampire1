using System;
using System.Collections.Generic;
using Com.Tal.Unity.Core;
using UnityEngine;


public class ObserverModuleManager : XSingleton<ObserverModuleManager>
{
    private readonly Dictionary<string, List<Action<object[]>>> _observerDic = new();

    public void RegisterEvent(string key, Action<object[]> action)
    {
        if (!_observerDic.ContainsKey(key))
        {
            _observerDic.Add(key, new List<Action<object[]>>());
        }

        _observerDic[key].Add(action);
    }

    public void UnRegisterEvent(string key, Action<object[]> action)
    {
        if (!_observerDic.ContainsKey(key)) return;
        _observerDic[key].Remove(action);
        if (_observerDic[key].Count == 0)
        {
            _observerDic.Remove(key);
        }
    }

    public void UnRegisterAllEvent(string key)
    {
        if (!_observerDic.ContainsKey(key)) return;
        _observerDic.Remove(key);
    }

    public void SendEvent(string key, params object[] args)
    {
        if (!_observerDic.ContainsKey(key)) return;
        //Debug.Log("SendEvent==key:"+ key);

        var arr = _observerDic[key].ToArray();
        
        foreach (var action in arr)
        {
            //Debug.Log("SendEvent==action:"+ action);

            action(args);
        }
    }

    public void ClearAllEvent()
    {
        _observerDic.Clear();
    }
}