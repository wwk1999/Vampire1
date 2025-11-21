using System;
using System.Collections.Generic;
using Gloabl;
using Mysql;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;


public class WeaponWindow : MonoBehaviour
{
   [NonSerialized]GameObject CurrentClickKong; //当前点击的源石孔
   [NonSerialized]public WeaponSource CurrentWeaponSourceStoneList=new WeaponSource();//当前武器可以镶嵌的源石类型
   public GameObject SourceStonePanel; // 源石面板
   public Image weaponPanelImage;//武器界面image
   public Button primaryInstallButton; // 初始武器安装按钮
   public Button twoInstallButton; // 第二个武器安装按钮
   public Button threeInstallButton; // 第三个武器安装按钮
   public Button fourInstallButton; // 第三个武器安装按钮
   public Button exitButton; // 退出按钮
   public Button sourceStone1Button; // 源石孔1按钮
   public Button sourceStone2Button; // 源石孔2按钮
   public Button sourceStone3Button; // 源石孔3按钮
   public Button sureButton; // 确认按钮
   public Button cancelButton; // 取消按钮
   public Button PenetrateButton; 
   public Button DivisionButton; 
   public Button ExtremeSpeedButton; 
   public Button ExplosionButton; 
   public Text sourceStoneText; // 源石文本
   public GameObject sourceStonePanel; // 源石面板
   public GameObject mask;
   [NonSerialized]public int CurrentKong;
   [NonSerialized] public int CurrentSourceStoneId = 0;
   [NonSerialized]public SourceStoneTable SourceStoneTable1=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable2=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable3=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable4=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable5=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable6=new SourceStoneTable(); // 当前源石属性
   
   public Button oneWeaponbutton; // 第一个武器按钮
   public Button twoWeaponbutton; // 第二个武器按钮
   public Button threeWeaponbutton; // 第三个武器按钮
   public Button fourWeaponbutton; // 第四个武器按钮
   
   public Image oneSourceStoneKongPanel; // 第一个源石孔面板
   public Button one1; // 第一个源石孔面板第一个按钮
   public Image twoSourceStoneKongPanel; // 第二个源石孔面板
   public Button two1; // 第二个源石孔面板第一个按钮
   public Button two2; // 第二个源石孔面板第二个按钮
   public Image threeSourceStoneKongPanel; // 第三个源石孔面板
   public Button three1; // 第三个源石孔面板第一个按钮
   public Button three2; // 第三个源石孔面板第二个按钮
   public Button three3; // 第三个源石孔面板第三个按钮
   public Image fourSourceStoneKongPanel; // 第四个源石孔面板
   public Button four1; // 第四个源石孔面板第一个按钮
   public Button four2; // 第四个源石孔面板第二个按钮
   public Button four3; // 第四个源石孔面板第三个按钮
   public Button four4; // 第四个源石孔面板第四个按钮
   
   public GameObject one1Prefab; // 第一个武器第一个源石孔
   public GameObject two1Prefab; // 第二个武器第一个源石孔
   public GameObject two2Prefab; // 第二个武器第二个源石孔
   public GameObject three1Prefab; // 第三个武器第一个源石孔
   public GameObject three2Prefab; // 第三个武器第二个源石孔
   public GameObject three3Prefab; // 第三个武器第三个源石孔
   public GameObject four1Prefab; // 第四个武器第一个源石孔
   public GameObject four2Prefab; // 第四个武器第二个源石孔
   public GameObject four3Prefab; // 第四个武器第三个源石孔
   public GameObject four4Prefab; // 第四个武器第四个源石孔


   public void HideSourceStoneKongPanel()
   {
      oneSourceStoneKongPanel.gameObject.SetActive(false);
      twoSourceStoneKongPanel.gameObject.SetActive(false);
      threeSourceStoneKongPanel.gameObject.SetActive(false);
      fourSourceStoneKongPanel.gameObject.SetActive(false);
   }
   private void Awake()
   {
      CurrentWeaponSourceStoneList.weaponSourceStoneTypes= new List<WeaponSourceStoneType>();
      SourceStoneTable1.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable2.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable3.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable4.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable5.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable6.SourceStoneType= (int)WeaponSourceStoneType.None;
      oneWeaponbutton.onClick.AddListener(() =>
      {
         CurrentWeaponSourceStoneList.weaponSourceStoneTypes= WeaponSourceConfig.OneWeaponSourceConfig.weaponSourceStoneTypes;
         CurrentWeaponSourceStoneList.quality= WeaponSourceConfig.OneWeaponSourceConfig.quality;
         weaponPanelImage.GetComponent<Image>().sprite = ResourcesConfig.OneWeapon;
         SourceStonePanel.GetComponent<SourceStoneWindow>().CurrentWeaponSourceStoneList= CurrentWeaponSourceStoneList;
         HideSourceStoneKongPanel();
         oneSourceStoneKongPanel.gameObject.SetActive(true);
      });
      twoWeaponbutton.onClick.AddListener(() =>
      {
         CurrentWeaponSourceStoneList.weaponSourceStoneTypes= WeaponSourceConfig.TwoWeaponSourceConfig.weaponSourceStoneTypes;
         CurrentWeaponSourceStoneList.quality= WeaponSourceConfig.TwoWeaponSourceConfig.quality;
         weaponPanelImage.GetComponent<Image>().sprite = ResourcesConfig.TwoWeapon;
         SourceStonePanel.GetComponent<SourceStoneWindow>().CurrentWeaponSourceStoneList= CurrentWeaponSourceStoneList;
         HideSourceStoneKongPanel();
         oneSourceStoneKongPanel.gameObject.SetActive(true);
      });
      threeWeaponbutton.onClick.AddListener(() =>
      {
         CurrentWeaponSourceStoneList.weaponSourceStoneTypes= WeaponSourceConfig.ThreeWeaponSourceConfig.weaponSourceStoneTypes;
         CurrentWeaponSourceStoneList.quality= WeaponSourceConfig.ThreeWeaponSourceConfig.quality;
         weaponPanelImage.GetComponent<Image>().sprite = ResourcesConfig.ThreeWeapon;
         SourceStonePanel.GetComponent<SourceStoneWindow>().CurrentWeaponSourceStoneList= CurrentWeaponSourceStoneList;
         HideSourceStoneKongPanel();
         twoSourceStoneKongPanel.gameObject.SetActive(true);
      });
      fourWeaponbutton.onClick.AddListener(() =>
      {
         CurrentWeaponSourceStoneList.weaponSourceStoneTypes= WeaponSourceConfig.FourWeaponSourceConfig.weaponSourceStoneTypes;
         CurrentWeaponSourceStoneList.quality= WeaponSourceConfig.FourWeaponSourceConfig.quality;
         weaponPanelImage.GetComponent<Image>().sprite = ResourcesConfig.FourWeapon;
         SourceStonePanel.GetComponent<SourceStoneWindow>().CurrentWeaponSourceStoneList= CurrentWeaponSourceStoneList;
         HideSourceStoneKongPanel();
         twoSourceStoneKongPanel.gameObject.SetActive(true);
      });
      sureButton.onClick.AddListener(() =>
      {
         switch (CurrentKong)
         {
            case 1:
               SourceStoneTable1.SourceStoneType= (int)CurrentSourceStoneId;
               SourceStoneTable1.Quality = 1;
               sourceStone1Button.image.sprite =  WeaponSourceConfig.GetWeaponSourceStoneSprite(CurrentSourceStoneId);
               break;
            case 2:
               SourceStoneTable2.SourceStoneType= (int)CurrentSourceStoneId;
               SourceStoneTable2.Quality = 1;
               sourceStone2Button.image.sprite = WeaponSourceConfig.GetWeaponSourceStoneSprite(CurrentSourceStoneId);

               break;
            case 3:
               SourceStoneTable3.SourceStoneType= (int)CurrentSourceStoneId;
               SourceStoneTable3.Quality = 1;
               sourceStone3Button.image.sprite = WeaponSourceConfig.GetWeaponSourceStoneSprite(CurrentSourceStoneId);
               break;
         }
         mask.gameObject.SetActive(false);
         sourceStonePanel.gameObject.SetActive(false);
         
      });
      
      primaryInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Primary;
         //GameController.S.gamePlayer.weaponType = WeaponType.Primary;
      });
      twoInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Two;
        // GameController.S.gamePlayer.weaponType = WeaponType.Two;
      });
      threeInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Three;
         // GameController.S.gamePlayer.weaponType = WeaponType.Two;
      });
      fourInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Four;
         // GameController.S.gamePlayer.weaponType = WeaponType.Two;
      });
      // PenetrateButton.onClick.AddListener(() =>
      // {
      //    sourceStoneText.text = SourceStoneText.WhitePenetrate;
      //    CurrentSourceStoneId = 1;
      // });
      // DivisionButton.onClick.AddListener(() =>
      // {
      //    sourceStoneText.text = SourceStoneText.WhiteDivision;
      //    CurrentSourceStoneId = 7;
      // });
      // ExtremeSpeedButton.onClick.AddListener(() =>
      // {
      //    sourceStoneText.text = SourceStoneText.WhiteExtremeSpeed;
      //    CurrentSourceStoneId = 13;
      // });
      // ExplosionButton.onClick.AddListener(() =>
      // {
      //    sourceStoneText.text = SourceStoneText.WhiteExplosion;
      //    CurrentSourceStoneId = 19;
      // });
      exitButton.onClick.AddListener(() =>
      {
         WeaponSourceConfig.WeaponSourceStoneList.Clear();
         if (SourceStoneTable1.SourceStoneType != (int)WeaponSourceStoneType.None)
         {
            WeaponSourceConfig.WeaponSourceStoneList.Add(SourceStoneTable1);
         }
         if (SourceStoneTable2.SourceStoneType != (int)WeaponSourceStoneType.None)
         {
            WeaponSourceConfig.WeaponSourceStoneList.Add(SourceStoneTable2);
         }
         if (SourceStoneTable3.SourceStoneType != (int)WeaponSourceStoneType.None)
         {
            WeaponSourceConfig.WeaponSourceStoneList.Add(SourceStoneTable3);
         }
         if (SourceStoneTable4.SourceStoneType != (int)WeaponSourceStoneType.None)
         {
            WeaponSourceConfig.WeaponSourceStoneList.Add(SourceStoneTable4);
         }
         if (SourceStoneTable5.SourceStoneType != (int)WeaponSourceStoneType.None)
         {
            WeaponSourceConfig.WeaponSourceStoneList.Add(SourceStoneTable5);
         }
         if (SourceStoneTable6.SourceStoneType != (int)WeaponSourceStoneType.None)
         {
            WeaponSourceConfig.WeaponSourceStoneList.Add(SourceStoneTable6);
         }
         Time.timeScale = 1;
         gameObject.SetActive(false);
         WindowController.S.RoleWindow.SetActive(true);
        // Destroy(gameObject);
      });
      cancelButton.onClick.AddListener(() =>
      {
         mask.gameObject.SetActive(false);
         SourceStonePanel.gameObject.SetActive(false);
      });
      
      one1.onClick.AddListener(() =>
      {
         CurrentKong = 1;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= one1Prefab;
      });
      two1.onClick.AddListener(() =>
      {
         CurrentKong = 1;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= two1Prefab;
      });
      two2.onClick.AddListener(() =>
      {
         CurrentKong = 2;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= two2Prefab;
      });
      three1.onClick.AddListener(() =>
      {
         CurrentKong = 1;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= three1Prefab;
      });
      three2.onClick.AddListener(() =>
      {
         CurrentKong = 2;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= three2Prefab;
      });
      three3.onClick.AddListener(() =>
      {
         CurrentKong = 3;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= three3Prefab;
      });
      four1.onClick.AddListener(() =>
      {
         CurrentKong = 1;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= four1Prefab;
      });
      four2.onClick.AddListener(() =>
      {
         CurrentKong = 2;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= four2Prefab;
      });
      four3.onClick.AddListener(() =>
      {
         CurrentKong = 3;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= four3Prefab;
      });
      four4.onClick.AddListener(() =>
      {
         CurrentKong = 4;
         SourceStonePanel.gameObject.SetActive(true);
         CurrentClickKong= four4Prefab;
      });

      
      sourceStone1Button.onClick.AddListener(()=>
      {
         CurrentKong = 1;
         mask.gameObject.SetActive(true);
         sourceStonePanel.gameObject.SetActive(true);
      });
      sourceStone2Button.onClick.AddListener(()=>
      {
         CurrentKong = 2;
         mask.gameObject.SetActive(true);
         sourceStonePanel.gameObject.SetActive(true);
      });
      sourceStone3Button.onClick.AddListener(()=>
      {
         CurrentKong = 3;
         mask.gameObject.SetActive(true);
         sourceStonePanel.gameObject.SetActive(true);
      });
   }
}
