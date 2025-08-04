using System;
using Gloabl;
using Mysql;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;


public class WeaponWindow : MonoBehaviour
{
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
   public GameObject towsourceStonePanel; // 第二武器源石面板
   public GameObject mask;
   [NonSerialized]public int CurrentKong;
   [NonSerialized]public WeaponSourceStoneType CurrentSourceStoneType=WeaponSourceStoneType.Penetrate;
   [NonSerialized]public SourceStoneTable SourceStoneTable1=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable2=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable3=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable4=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable5=new SourceStoneTable(); // 当前源石属性
   [NonSerialized]public SourceStoneTable SourceStoneTable6=new SourceStoneTable(); // 当前源石属性

   private void Awake()
   {
      SourceStoneTable1.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable2.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable3.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable4.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable5.SourceStoneType= (int)WeaponSourceStoneType.None;
      SourceStoneTable6.SourceStoneType= (int)WeaponSourceStoneType.None;
      sureButton.onClick.AddListener(() =>
      {
         switch (CurrentKong)
         {
            case 1:
               SourceStoneTable1.SourceStoneType= (int)CurrentSourceStoneType;
               SourceStoneTable1.Quality = 1;
               sourceStone1Button.image.sprite = BagController.S.SourceStoneSpriteConfig[(int)CurrentSourceStoneType];
               break;
            case 2:
               SourceStoneTable2.SourceStoneType= (int)CurrentSourceStoneType;
               SourceStoneTable2.Quality = 1;
               sourceStone2Button.image.sprite = BagController.S.SourceStoneSpriteConfig[(int)CurrentSourceStoneType];

               break;
            case 3:
               SourceStoneTable3.SourceStoneType= (int)CurrentSourceStoneType;
               SourceStoneTable3.Quality = 1;
               sourceStone3Button.image.sprite = BagController.S.SourceStoneSpriteConfig[(int)CurrentSourceStoneType];
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
      PenetrateButton.onClick.AddListener(() =>
      {
         sourceStoneText.text = SourceStoneText.WhitePenetrate;
         CurrentSourceStoneType = WeaponSourceStoneType.Penetrate;
      });
      DivisionButton.onClick.AddListener(() =>
      {
         sourceStoneText.text = SourceStoneText.WhiteDivision;
         CurrentSourceStoneType = WeaponSourceStoneType.Division;
      });
      ExtremeSpeedButton.onClick.AddListener(() =>
      {
         sourceStoneText.text = SourceStoneText.WhiteExtremeSpeed;
         CurrentSourceStoneType = WeaponSourceStoneType.ExtremeSpeed;
      });
      ExplosionButton.onClick.AddListener(() =>
      {
         sourceStoneText.text = SourceStoneText.WhiteExplosion;
         CurrentSourceStoneType = WeaponSourceStoneType.Explosion;
      });
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
         sourceStonePanel.gameObject.SetActive(false);
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
