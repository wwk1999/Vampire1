using UnityEngine;

public class UITool:XSingleton<UITool>
{
   /// <summary>
   /// 当前的活动面板
   /// </summary>
   public GameObject activePanel { get; set; }
   public GameObject lastPanel { get; set; }
   
   public UITool(GameObject activeePanel)
   {
      this.activePanel = activeePanel;
      this.lastPanel = activeePanel;
   }

   public GameObject GetChildGameObject(string uiName)
   {
      GameObject uiRoot = GameObject.Find("UIRoot");
      if (uiRoot == null)
      {
         Debug.LogError("没有UIRoot！");
         return null;
      }
   
      GameObject child = FindChildRecursive(uiRoot.transform, uiName);
      if (child == null)
      {
         Debug.LogError("未找到子对象：" + uiName);
      }
      return child;
   }

   private GameObject FindChildRecursive(Transform parent, string childName)
   {
      foreach (Transform child in parent)
      {
         if (child.name == childName)
         {
            return child.gameObject;
         }
         GameObject found = FindChildRecursive(child, childName);
         if (found != null)
         {
            return found;
         }
      }
      return null;
   }

   public GameObject GetComponentInChild<T>(string uiName) where T : Component
   {
      GameObject uiRoot = GameObject.Find("UIRoot");
      if (uiRoot == null)
      {
         Debug.LogError("没有UIRoot！");
         return null;
      }
      GameObject child = uiRoot.transform.Find(uiName).gameObject;
      if (child == null)
      {
         Debug.LogError($"没有找到{uiName}的子对象");
         return null;
      }
      T component = child.GetComponent<T>();
      if (component == null)
      {
         Debug.LogError($"没有找到{uiName}的子对象的组件");
         return null;
      }
      return child;
   }
   
   public T ActivePanelGetOrAddComponent<T>() where T : Component
   {
      T component =activePanel.GetComponent<T>();
      if (component == null)
      {
         component = activePanel.AddComponent<T>();
      }
      return component;
   }
   public T LastPanelGetOrAddComponent<T>() where T : Component
   {
      T component =lastPanel.GetComponent<T>();
      if (component == null)
      {
         component = lastPanel.AddComponent<T>();
      }
      return component;
   }
   /// <summary>
   /// 查找子对象
   /// </summary>
   /// <param name="子对象名称"></param>
   /// <returns></returns>
   public GameObject ActivePanelFindChildGameObject(string name)
   {
      Transform[] trans = activePanel.GetComponentsInChildren<Transform>();
      foreach (var item in trans)
      {
         if (item.name == name)
         {
            return item.gameObject;
         }
      }
      Debug.LogError($"{activePanel.name}里找不到{name}的子对象");
      return null;
   }
   public GameObject LastPanelFindChildGameObject(string name)
   {
      Transform[] trans = lastPanel.GetComponentsInChildren<Transform>();
      foreach (var item in trans)
      {
         if (item.name == name)
         {
            return item.gameObject;
         }
      }
      Debug.LogError($"{lastPanel.name}里找不到{name}的子对象");
      return null;
   }
   /// <summary>
   /// 查找或者获取子对象的组件
   /// </summary>
   /// <param name="name"></param>
   /// <typeparam name="T"></typeparam>
   /// <returns></returns>
   public T ActivePanelGetOrAddComponentInChild<T>(string name) where T : Component
   {
      GameObject child = ActivePanelFindChildGameObject(name);
      if (child == null)
      {
         return null;
      }
      T component = child.GetComponent<T>();
      if (component == null)
      {
         component = child.AddComponent<T>();
      }
      return component;
   }
   public T LastPanelGetOrAddComponentInChild<T>(string name) where T : Component
   {
      GameObject child = LastPanelFindChildGameObject(name);
      if (child == null)
      {
         return null;
      }
      T component = child.GetComponent<T>();
      if (component == null)
      {
         component = child.AddComponent<T>();
      }
      return component;
   }
}
