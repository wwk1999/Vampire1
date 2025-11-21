using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendListItem : MonoBehaviour
{
   public Button delFriendButton;
   [NonSerialized]public int FriendUserId; // 好友的UserId

   private void Start()
   {
      delFriendButton.onClick.AddListener(() =>
      {
         var delwindow=Instantiate(Resources.Load<GameObject>("Prefabs/UI/SureDelFriend"));
         delwindow.GetComponent<SureDelFriend>().FriendUserId = FriendUserId;
         delwindow.GetComponent<SureDelFriend>().FriendListItem = gameObject;
      });
   }
}
