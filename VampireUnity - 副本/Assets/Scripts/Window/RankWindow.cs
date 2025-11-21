using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class RankWindow : MonoBehaviour
{
   public SkeletonGraphic onespine;
   public SkeletonGraphic twospine;
   public SkeletonGraphic threespine;
   public Text oneName;
   public Text twoName;
   public Text threeName;
   public Text oneLevel;
   public Text twoLevel;
   public Text threeLevel;
   public GameObject content;
   public Text selfname;
   public Text selflevel;
   public Text selfrank;
   public Button exitButton;
   
   public Text selfleveltext;

   public Button levelbutton;
   public Button monstercountbutton;
   
   





   private void Start()
   {
      exitButton.onClick.AddListener(() =>
      {
         WindowController.S.RankWindow.SetActive(false);
      });
      
      
      levelbutton.onClick.AddListener(() =>
      {
         UpdateLevelRank();
      });

      monstercountbutton.onClick.AddListener(() =>
      {
         UpdateMonsterCountRank();
      });
      
      onespine.AnimationState.SetAnimation(0, "idle", true);
      twospine.AnimationState.SetAnimation(0, "idle", true);
      threespine.AnimationState.SetAnimation(0, "idle", true);


      UpdateLevelRank();
   }


   public void UpdateLevelRank()
   {
     
      oneLevel.text="等级："+ RankConfig.LevelRankData.rankings[0].value.ToString();
      twoLevel.text="等级："+ RankConfig.LevelRankData.rankings[1].value.ToString();
      threeLevel.text="等级："+ RankConfig.LevelRankData.rankings[2].value.ToString();
      
      selfname.text=RankConfig.UserLevelRankData.username;
      
      selfleveltext.text="等级："+ RankConfig.UserLevelRankData.value;
      selfrank.text=RankConfig.UserLevelRankData.position.ToString();
      selflevel.text=RankConfig.UserLevelRankData.value.ToString();
      oneName.text = RankConfig.LevelRankData.rankings[0].username;
      twoName.text = RankConfig.LevelRankData.rankings[1].username;
      threeName.text = RankConfig.LevelRankData.rankings[2].username;
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }
      int count = 0;
      foreach (var item in RankConfig.LevelRankData.rankings)
      {
         count++;
        if(count<4)continue;
        GameObject listitem=Instantiate(Resources.Load<GameObject>("Prefabs/UI/ListItem"), content.transform);
        listitem.transform.Find("RankText").GetComponent<Text>().text = item.position.ToString();
        listitem.transform.Find("Name").GetComponent<Text>().text = item.username;
        listitem.transform.Find("Level").GetComponent<Text>().text = item.value.ToString();
        listitem.transform.Find("LevelText").GetComponent<Text>().text = "等级：";
      }
      LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());

   }
   
   public void UpdateMonsterCountRank()
   {
      oneLevel.text="杀怪数量："+ RankConfig.MonsterCountRankData[0].count;
      twoLevel.text="杀怪数量："+ RankConfig.MonsterCountRankData[1].count;
      threeLevel.text="杀怪数量："+ RankConfig.MonsterCountRankData[2].count;
      
      selfname.text=RankConfig.UserLevelRankData.username;

      
      selfleveltext.text="杀怪数量："+ RankConfig.UserMonsterCountRankData.count;
      selfrank.text = RankConfig.UserMonsterCountRankData.rank.ToString();
      selflevel.text = RankConfig.UserMonsterCountRankData.count.ToString();
      oneName.text = RankConfig.MonsterCountRankData[0].username;
      twoName.text = RankConfig.MonsterCountRankData[1].username;
      threeName.text = RankConfig.MonsterCountRankData[2].username;
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }
      int count = 0;
      foreach (var item in RankConfig.MonsterCountRankData)
      {
         count++;
         if(count<4)continue;
         GameObject listitem=Instantiate(Resources.Load<GameObject>("Prefabs/UI/ListItem"), content.transform);
         listitem.transform.Find("RankText").GetComponent<Text>().text = item.rank.ToString();
         listitem.transform.Find("Name").GetComponent<Text>().text = item.username;
         listitem.transform.Find("Level").GetComponent<Text>().text = item.level.ToString();
         listitem.transform.Find("LevelText").GetComponent<Text>().text = "杀怪数量：";
      }
      LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
   }
   
   public void InitRankWindow()
   {
      selfname.text=RankConfig.UserLevelRankData.username;
      selflevel.text=RankConfig.UserLevelRankData.value.ToString();
      selfrank.text = RankConfig.UserLevelRankData.position.ToString();
      
      if (RankConfig.LevelRankData.rankings.Count > 0)
      {
         oneName.text = RankConfig.LevelRankData.rankings[0].username;
         twoName.text = RankConfig.LevelRankData.rankings[1].username;
         threeName.text = RankConfig.LevelRankData.rankings[2].username;
         oneLevel.text = RankConfig.LevelRankData.rankings[0].value.ToString();
         twoLevel.text = RankConfig.LevelRankData.rankings[1].value.ToString();
         threeLevel.text = RankConfig.LevelRankData.rankings[2].value.ToString();
         int count = 0;
         //销毁content下的所有子物体
         for (int i = content.transform.childCount - 1; i >= 0; i--)
         {
            Destroy(content.transform.GetChild(i).gameObject);
         }
         foreach (var item in RankConfig.LevelRankData.rankings)
         {
            count++;
            if(count<=3) continue;
            GameObject listitem=Instantiate(Resources.Load<GameObject>("Prefabs/UI/ListItem"), content.transform);
            listitem.transform.Find("RankText").GetComponent<Text>().text = item.position.ToString();
            listitem.transform.Find("Name").GetComponent<Text>().text = item.username;
            listitem.transform.Find("Level").GetComponent<Text>().text = item.value.ToString();
         }
      }
      else
      {
         Debug.LogError("等级排行榜数据为空！");
      }
   }
}
