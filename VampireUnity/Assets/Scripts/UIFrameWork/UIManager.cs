using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager:XSingleton<UIManager>
{
    private Dictionary<string, GameObject> uiDic;
    public UIManager()
    {
        uiDic = new Dictionary<string, GameObject>();
    }

    public GameObject GetUIWindow(UIType uiType)
    {
        GameObject UIRoot= GameObject.Find("UIRoot");
        if (UIRoot == null)
        {
            Debug.LogError("UIRoot为空!");
            return null;
        }
        if (uiDic.ContainsKey(uiType.name))
        {
            GameObject ui = uiDic[uiType.name];
            ui.SetActive(true);
            return ui;
        }
        //创建UI实例，并且设置UIRoot为父类
        GameObject uiPrefab = GameObject.Instantiate(Resources.Load<GameObject>(uiType.path),UIRoot.transform);
        if (uiPrefab == null)
        {
            Debug.LogError($"没有找到UI:{uiType.name}");
            return null;
        }
        uiPrefab.name = uiType.name;
        uiDic.Add(uiType.name,uiPrefab);
        return uiPrefab;
    }

    public void DestroyUIWindow(UIType uiType)
    {
        if (uiDic.ContainsKey(uiType.name))
        {
            Destroy(uiDic[uiType.name]);
            uiDic.Remove(uiType.name);
        }
    }
    
}