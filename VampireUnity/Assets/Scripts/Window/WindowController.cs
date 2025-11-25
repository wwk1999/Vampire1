using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : XSingleton<WindowController>
{
   [NonSerialized]public GameObject GameLevelWindow;
   [NonSerialized]public GameObject SceneLoadingWindow;
   [NonSerialized]public GameObject LoginWindow;
   [NonSerialized]public GameObject MainWindow;
   [NonSerialized]public GameObject RoleWindow;
   [NonSerialized]public GameObject Setting;
   [NonSerialized]public GameObject ShopWindow;
   [NonSerialized]public GameObject SkillWindow;
   [NonSerialized]public GameObject TaskWindow;
   [NonSerialized]public GameObject WeaponWindow;
   [NonSerialized]public GameObject MonsterBookWindow;
   [NonSerialized] public GameObject Message;
   [NonSerialized] public GameObject BagWindow;
   [NonSerialized] public GameObject FriendList;
   [NonSerialized] public GameObject AddFriendWindow;
   [NonSerialized] public GameObject RankWindow;
   
   public void InitPanel()
   {
      //BagWindow=Instantiate(Resources.Load("Prefabs/Window/Bag") as GameObject);
      GameLevelWindow=Instantiate(Resources.Load("Prefabs/Window/GameLevel") as GameObject);
      SceneLoadingWindow=Instantiate(Resources.Load("Prefabs/Window/SceneLoading") as GameObject);
      LoginWindow=Instantiate(Resources.Load("Prefabs/Window/LoginWindow") as GameObject);
      MainWindow=Instantiate(Resources.Load("Prefabs/Window/MainWindow") as GameObject);
      RoleWindow=Instantiate(Resources.Load("Prefabs/Window/RoleWindow") as GameObject);
      Setting=Instantiate(Resources.Load("Prefabs/Window/Setting") as GameObject);
      ShopWindow=Instantiate(Resources.Load("Prefabs/Window/ShopWindow") as GameObject);
      SkillWindow=Instantiate(Resources.Load("Prefabs/Window/SkillWindow") as GameObject);
      TaskWindow=Instantiate(Resources.Load("Prefabs/Window/TaskWindow") as GameObject);
      WeaponWindow=Instantiate(Resources.Load("Prefabs/Window/WeaponWindow") as GameObject);
      Message=Instantiate(Resources.Load("Prefabs/Tool/Message") as GameObject);
      Message.GetComponent<Canvas>().renderMode= RenderMode.ScreenSpaceOverlay;
      MonsterBookWindow=Instantiate(Resources.Load("Prefabs/Window/MonsterBook") as GameObject);
      FriendList=Instantiate(Resources.Load("Prefabs/Window/FriendList") as GameObject);
      AddFriendWindow=Instantiate(Resources.Load("Prefabs/Window/AddFriendWindow") as GameObject);
      RankWindow=Instantiate(Resources.Load("Prefabs/Window/RankWindow") as GameObject);

      
      
     // BagWindow.SetActive(false);
      GameLevelWindow.gameObject.SetActive(false);
      SceneLoadingWindow.gameObject.SetActive(false);
      LoginWindow.gameObject.SetActive(false);
      MainWindow.gameObject.SetActive(false);
      RoleWindow.gameObject.SetActive(false);
      Setting.gameObject.SetActive(false);
      ShopWindow.gameObject.SetActive(false);
      SkillWindow.gameObject.SetActive(false);
      TaskWindow.gameObject.SetActive(false);
      WeaponWindow.gameObject.SetActive(false);
      MonsterBookWindow.gameObject.SetActive(false);
      Message.SetActive(false);
      FriendList.SetActive(false);
      AddFriendWindow.SetActive(false);
      RankWindow.SetActive(false);
   }
}
