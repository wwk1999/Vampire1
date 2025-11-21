using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendApplicationItem : MonoBehaviour
{
   [NonSerialized]public int FromUserid; // 申请者的UserId
   public Button agreeButton; // 同意按钮
   public Button noAgreeButton; // 不同意按钮

   private void Start()
   {
      agreeButton.onClick.AddListener(() =>
      {
         Debug.Log("同意"+FromUserid+"的好友申请");
         ServerConnect.S.SenResponseFriendApplicationRequest(FromUserid, true);
         //等待1s
         WindowController.S.StartCoroutine(WaitAndRefreshFriendList());
         Destroy(gameObject); // 同意后销毁该申请项
      });
      
      noAgreeButton.onClick.AddListener(() =>
      {
         Debug.Log("不同意"+FromUserid+"的好友申请");
         ServerConnect.S.SenResponseFriendApplicationRequest(FromUserid, false);
         Destroy(gameObject); // 不同意后销毁该申请项
      });
   }
   
   private IEnumerator WaitAndRefreshFriendList()
   {
      yield return new WaitForSeconds(1f); // 等待1秒
      ServerConnect.S.SendGetFriendListRequest(); // 刷新好友列表
   }
}
