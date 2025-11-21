using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureDelFriend : MonoBehaviour
{
   public Button sureButton; // 确认删除按钮
   public Button cancelButton; // 取消按钮
   [NonSerialized]public int FriendUserId; // 好友的UserId
   [NonSerialized]public GameObject FriendListItem; // 好友列表item

   private void Start()
   {
      sureButton.onClick.AddListener(() =>
      {
         Debug.Log("删除好友: " + FriendUserId);
         ServerConnect.S.SendRemoveFriendRequest(FriendUserId);
         Destroy(FriendListItem);
         Destroy(gameObject);
      });
      
      cancelButton.onClick.AddListener(() =>
      {
         Destroy(gameObject);
      });
   }
}
