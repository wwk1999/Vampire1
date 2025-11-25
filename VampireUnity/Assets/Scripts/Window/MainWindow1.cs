using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow1 : MonoBehaviour
{
   public Button loginButton;
   public Button startButton;
   private bool _isgameStart = false;
   public static bool IsLogin = false;

   private void Start()
   {
       _=PlayerInfoController.S;
      loginButton.onClick.AddListener(async () =>
      {
          await ServerConnect.S.ConnectAsync();
          WindowController.S.LoginWindow.SetActive(true);
      });
      startButton.onClick.AddListener(async () =>
      {
          Debug.Log("点击进入末世");
          _isgameStart = true;
          gameObject.SetActive(false);
          WindowController.S.RoleWindow.SetActive(true);
      });
   }
}
