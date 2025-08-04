using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class MonsterBook : MonoBehaviour
{
   public Button exitButton;//退出按钮
   public SkeletonGraphic monsterSkeleton;
   public SkeletonDataAsset snotskeleton;
   public SkeletonDataAsset spiderskeleton;
   public SkeletonDataAsset batskeleton;
   public SkeletonDataAsset eliteBeeskeleton;
   public SkeletonDataAsset bossTreeManskeleton;

   
   public Button snotButton;//粘液怪怪物列表按钮
   public Button spiderButton;//蜘蛛怪物列表按钮
   public Button batButton;//蝙蝠怪物列表按钮
   public Button eliteBeeButton;//精英蜜蜂怪物列表按钮
   public Button bossTreeManButton;//树人Boss怪物列表按钮
   
   public Text nameText;
   public Text locationText;
   public Text monsterTypeText;
   public Text introduceText;
   public GameObject diaoLuoContent;
   
   
   private int _index=1; // 当前怪物索引
   

   public void CleanContent()
   {
      foreach (Transform child in diaoLuoContent.transform)
      {
         Destroy(child.gameObject);
      }
   }

   private void Start()
   {
      monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
      monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.snotBookData._scale, MonsterBookConfig.snotBookData._scale, 1);
      exitButton.onClick.AddListener(() =>
      {
         Debug.Log("点击退出怪物图鉴界面");
         WindowController.S.MonsterBookWindow.SetActive(false);
      });
      
      snotButton.onClick.AddListener(() =>
      {
         if (_index == 1) return;
         _index = 1;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.snotBookData._scale, MonsterBookConfig.snotBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = snotskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.snotBookData._name;
         locationText.text = MonsterBookConfig.snotBookData._location;
         monsterTypeText.text = MonsterBookConfig.snotBookData._monsterType;
         introduceText.text = MonsterBookConfig.snotBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.snotBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      spiderButton.onClick.AddListener(() =>
      {
         if (_index == 2) return;
         _index = 2;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.spiderBookData._scale, MonsterBookConfig.spiderBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = spiderskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.spiderBookData._name;
         locationText.text = MonsterBookConfig.spiderBookData._location;
         monsterTypeText.text = MonsterBookConfig.spiderBookData._monsterType;
         introduceText.text = MonsterBookConfig.spiderBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.spiderBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      batButton.onClick.AddListener(() =>
      {
         if (_index == 3) return;
         _index = 3;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.batBookData._scale, MonsterBookConfig.batBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = batskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.batBookData._name;
         locationText.text = MonsterBookConfig.batBookData._location;
         monsterTypeText.text = MonsterBookConfig.batBookData._monsterType;
         introduceText.text = MonsterBookConfig.batBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.batBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      eliteBeeButton.onClick.AddListener(() =>
      {
         if (_index == 4) return;
         _index = 4;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.eliteBeeBookData._scale, MonsterBookConfig.eliteBeeBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = eliteBeeskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.eliteBeeBookData._name;
         locationText.text = MonsterBookConfig.eliteBeeBookData._location;
         monsterTypeText.text = MonsterBookConfig.eliteBeeBookData._monsterType;
         introduceText.text = MonsterBookConfig.eliteBeeBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.eliteBeeBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      bossTreeManButton.onClick.AddListener(() =>
      {
         if (_index == 5) return;
         _index = 5;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.bossTreeManBookData._scale, MonsterBookConfig.bossTreeManBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = bossTreeManskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.bossTreeManBookData._name;
         locationText.text = MonsterBookConfig.bossTreeManBookData._location;
         monsterTypeText.text = MonsterBookConfig.bossTreeManBookData._monsterType;
         introduceText.text = MonsterBookConfig.bossTreeManBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.bossTreeManBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
   }
}
