using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
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
   
   public SkeletonDataAsset chongziskeleton;
   public SkeletonDataAsset xiaohuoskeleton;
   public SkeletonDataAsset dundiskeleton;
   public SkeletonDataAsset eliteDaZuiskeleton;
   public SkeletonDataAsset bossHuoShanskeleton;
   
   public SkeletonDataAsset wenziskeleton;
   public SkeletonDataAsset qingwaskeleton;
   public SkeletonDataAsset jiachongskeleton;
   public SkeletonDataAsset shirenhuaskeleton;
   public SkeletonDataAsset bossStoneskeleton;

   
   public Button snotButton;//粘液怪怪物列表按钮
   public Button spiderButton;//蜘蛛怪物列表按钮
   public Button batButton;//蝙蝠怪物列表按钮
   public Button eliteBeeButton;//精英蜜蜂怪物列表按钮
   public Button bossTreeManButton;//树人Boss怪物列表按钮
   
   //第二关
   public Button chongziButton;//粘液怪怪物列表按钮
   public Button xiaohuoButton;//小火怪物列表按钮
   public Button dundiButton;//遁地怪怪物列表按钮
   public Button dazuiButton;//精英大嘴怪物列表按钮
   public Button huoshanbossManButton;//火山Boss怪物列表按钮
   
   //第三关
   public Button wenziButton;//蚊子怪怪物列表按钮
   public Button qingwaButton;//青蛙怪物列表按钮
   public Button jiachongButton;//甲虫怪物列表按钮
   public Button shirenhuaButton;//精英食人花怪物列表按钮
   public Button stonebossManButton;//石头Boss怪物列表按钮
   
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
      
      chongziButton.onClick.AddListener(() =>
      {
         if (_index == 6) return;
         _index = 6;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.chongziBookData._scale, MonsterBookConfig.chongziBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = chongziskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.chongziBookData._name;
         locationText.text = MonsterBookConfig.chongziBookData._location;
         monsterTypeText.text = MonsterBookConfig.chongziBookData._monsterType;
         introduceText.text = MonsterBookConfig.chongziBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.chongziBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      xiaohuoButton.onClick.AddListener(() =>
      {
         if (_index == 7) return;
         _index = 7;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.xiaohuoBookData._scale, MonsterBookConfig.xiaohuoBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = xiaohuoskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.xiaohuoBookData._name;
         locationText.text = MonsterBookConfig.xiaohuoBookData._location;
         monsterTypeText.text = MonsterBookConfig.xiaohuoBookData._monsterType;
         introduceText.text = MonsterBookConfig.xiaohuoBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.xiaohuoBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      dundiButton.onClick.AddListener(() =>
      {
         if (_index == 8) return;
         _index = 8;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.dundiBookData._scale, MonsterBookConfig.dundiBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = dundiskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.dundiBookData._name;
         locationText.text = MonsterBookConfig.dundiBookData._location;
         monsterTypeText.text = MonsterBookConfig.dundiBookData._monsterType;
         introduceText.text = MonsterBookConfig.dundiBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.dundiBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      dazuiButton.onClick.AddListener(() =>
      {
         if (_index == 9) return;
         _index = 9;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.elitedazuiBookData._scale, MonsterBookConfig.elitedazuiBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = eliteDaZuiskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.elitedazuiBookData._name;
         locationText.text = MonsterBookConfig.elitedazuiBookData._location;
         monsterTypeText.text = MonsterBookConfig.elitedazuiBookData._monsterType;
         introduceText.text = MonsterBookConfig.elitedazuiBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.elitedazuiBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      huoshanbossManButton.onClick.AddListener(() =>
      {
         if (_index == 10) return;
         _index = 10;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.bossHuoShanBookData._scale, MonsterBookConfig.bossHuoShanBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = bossHuoShanskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.bossHuoShanBookData._name;
         locationText.text = MonsterBookConfig.bossHuoShanBookData._location;
         monsterTypeText.text = MonsterBookConfig.bossHuoShanBookData._monsterType;
         introduceText.text = MonsterBookConfig.bossHuoShanBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.bossHuoShanBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      wenziButton.onClick.AddListener(() =>
      {
         if (_index == 11) return;
         _index = 11;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.wenziBookData._scale, MonsterBookConfig.wenziBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = wenziskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.wenziBookData._name;
         locationText.text = MonsterBookConfig.wenziBookData._location;
         monsterTypeText.text = MonsterBookConfig.wenziBookData._monsterType;
         introduceText.text = MonsterBookConfig.wenziBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.wenziBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      qingwaButton.onClick.AddListener(() =>
      {
         if (_index == 12) return;
         _index = 12;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.qingwaBookData._scale, MonsterBookConfig.qingwaBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = qingwaskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.qingwaBookData._name;
         locationText.text = MonsterBookConfig.qingwaBookData._location;
         monsterTypeText.text = MonsterBookConfig.qingwaBookData._monsterType;
         introduceText.text = MonsterBookConfig.qingwaBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.qingwaBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      jiachongButton.onClick.AddListener(() =>
      {
         if (_index == 13) return;
         _index = 13;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.jiachongBookData._scale, MonsterBookConfig.jiachongBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = jiachongskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.jiachongBookData._name;
         locationText.text = MonsterBookConfig.jiachongBookData._location;
         monsterTypeText.text = MonsterBookConfig.jiachongBookData._monsterType;
         introduceText.text = MonsterBookConfig.jiachongBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.jiachongBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      shirenhuaButton.onClick.AddListener(() =>
      {
         if (_index == 14) return;
         _index = 14;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.shirenhuaBookData._scale, MonsterBookConfig.shirenhuaBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = shirenhuaskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.shirenhuaBookData._name;
         locationText.text = MonsterBookConfig.shirenhuaBookData._location;
         monsterTypeText.text = MonsterBookConfig.shirenhuaBookData._monsterType;
         introduceText.text = MonsterBookConfig.shirenhuaBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.shirenhuaBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
      
      stonebossManButton.onClick.AddListener(() =>
      {
         if (_index == 15) return;
         _index = 15;
         monsterSkeleton.transform.localScale=new Vector3(MonsterBookConfig.bossStoneBookData._scale, MonsterBookConfig.bossStoneBookData._scale, 1);
         monsterSkeleton.SkeletonDataAsset = bossStoneskeleton;
         monsterSkeleton.Initialize(true);
         monsterSkeleton.AnimationState.SetAnimation(0, "idle", true);
         nameText.text = MonsterBookConfig.bossStoneBookData._name;
         locationText.text = MonsterBookConfig.bossStoneBookData._location;
         monsterTypeText.text = MonsterBookConfig.bossStoneBookData._monsterType;
         introduceText.text = MonsterBookConfig.bossStoneBookData._introduce;
         CleanContent();
         foreach (var item in MonsterBookConfig.bossStoneBookData._diaoluoList)
         {
            var diaoluo = Instantiate(Resources.Load("Prefabs/Tool/MonsterBookItem") as GameObject, diaoLuoContent.transform);
            diaoluo.transform.Find("bg").GetComponent<Image>().sprite = item._bg;
            diaoluo.transform.Find("Button (Legacy)").GetComponent<Image>().sprite = item._buttonIcon;
         }
      });
   }
}
