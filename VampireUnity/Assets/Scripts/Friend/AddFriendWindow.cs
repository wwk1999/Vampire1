using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuiJianFrienfItem
{
   public int userid;
   public string name;
   public int level;
}
public class AddFriendWindow : MonoBehaviour
{
   public Button exitButton;
   public Button addFriendButton;//添加好友按钮
   public InputField friendUseridInputField;//好友Userid输入框
   public GameObject content;

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("GetTuiJianFriendSuccess",GetTuiJianFriendSuccess);
      exitButton.onClick.AddListener(() =>
      {
        WindowController.S.AddFriendWindow.SetActive(false);
      });
      
      addFriendButton.onClick.AddListener(() =>
      {
         int friendUserId =  int.Parse(friendUseridInputField.text);
         if (string.IsNullOrEmpty(friendUseridInputField.text))
         {
            Debug.LogError("请输入好友的UserId");
            return;
         }
         ServerConnect.S.SendAddFriendRequest(friendUserId, "加好友");
      });
      
   }

   private void OnEnable()
   {
      ServerConnect.S.SendTuiJianFriendRequest();
   }

   public void GetTuiJianFriendSuccess(object[] args)
   {
      if (args[0] == null) return;
      //销毁content所有的子物体
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }
      List<TuiJianFrienfItem> tuiJianFriendList =Newtonsoft.Json.JsonConvert.DeserializeObject<List<TuiJianFrienfItem>>(args[0].ToString());
      foreach (var item in tuiJianFriendList)
      {
         GameObject obj=Instantiate(Resources.Load<GameObject>("Prefabs/UI/TuiJianFriendItem"), content.transform);
         obj.transform.Find("NameText").GetComponent<Text>().text = item.name;
         obj.transform.Find("Level").GetComponent<Text>().text =  item.level.ToString();
      }
   }
}
