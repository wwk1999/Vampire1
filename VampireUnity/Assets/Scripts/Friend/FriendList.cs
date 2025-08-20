using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class FriendList : MonoBehaviour
{
   public Button exitButton;//退出按钮
   public Button addFriendButton;//添加好友按钮
   public Button friendApplicationButton;//好友申请按钮
   public Button refreshButton;//刷新按钮
   public ParticleSystem tishiParticleSystem;//提示粒子特效
   public Image redDotImage;//红点图标
   public GameObject content;
   public Text selfUserid;

   private void Start()
   {
      selfUserid.text = "ID："+GlobalUserInfo.Userid.ToString();
      ObserverModuleManager.S.RegisterEvent("GetFriendApplicationSuccess",OnGetFriendApplicationSuccess);
      ObserverModuleManager.S.RegisterEvent("GetFriendListSuccess",OnGetFriendListSuccess);

      exitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      
      addFriendButton.onClick.AddListener(() =>
      {
         WindowController.S.AddFriendWindow.SetActive(true);
      });
      
      friendApplicationButton.onClick.AddListener(() =>
      {
         Instantiate(Resources.Load<GameObject>("Prefabs/Window/FriendApplication"));
      });
      
      refreshButton.onClick.AddListener(() =>
      {
         ServerConnect.S.SendGetFriendApplicationRequest();
      });
      
      
      ServerConnect.S.SendGetFriendListRequest();
   }

   private void OnEnable()
   {
      //刷新好友列表和好友申请
      ServerConnect.S.SendGetFriendApplicationRequest();
      ServerConnect.S.SendGetFriendListRequest();
   }

   public void OnGetFriendApplicationSuccess(object[] args)
   {
      redDotImage.gameObject.SetActive(true);
      FriendConfig.friendApplicationList=Newtonsoft.Json.JsonConvert.DeserializeObject<List<FriendApplicationResponse>>(args[0].ToString());
   }
   
   public void OnGetFriendListSuccess(object[] args)
   {
      if (args[0] == null) return;
      List<FriendListItemResponse> friendList = new List<FriendListItemResponse>();
      friendList= Newtonsoft.Json.JsonConvert.DeserializeObject<List<FriendListItemResponse>>(args[0].ToString());
      if (friendList != FriendConfig.friendList)
      {
         FriendConfig.friendList = friendList;
         //销毁content下的所有子物体
         foreach (Transform child in content.transform)
         {
            Destroy(child.gameObject);
         }
         //重新生成好友列表
         foreach (var friendlistitem in  FriendConfig.friendList)
         {
            var listitem=Instantiate(Resources.Load<GameObject>("Prefabs/UI/FriendListItem"),content.transform);
            listitem.transform.Find("NameText").GetComponent<Text>().text= friendlistitem.friend_username;
            listitem.transform.Find("Level").GetComponent<Text>().text= "Level："+friendlistitem.friend_level;
            listitem.GetComponent<FriendListItem>().FriendUserId= friendlistitem.touserid;
         }
      }
   }
}
