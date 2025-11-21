using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class SourceStoneWindow : MonoBehaviour
{
   public GameObject content; // 源石列表的滚动视图的content
   [NonSerialized]public WeaponSource CurrentWeaponSourceStoneList=new WeaponSource();//当前武器可以镶嵌的源石类型


   private void Awake()
   {
      CurrentWeaponSourceStoneList.weaponSourceStoneTypes = new List<WeaponSourceStoneType>();
   }

   private void OnEnable()
   {
      // 清空之前的源石项
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }

      foreach (var item in CurrentWeaponSourceStoneList.weaponSourceStoneTypes)
      {
         foreach (var t in  BagController.S.SourceStoneTable)
         {
            if (t.Quality == 1 && t.SourceStoneType == (int)item)
            {
               GameObject SourceStoneKongItem=Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/SourceStoneKongItem"),content.transform);
               SourceStoneKongItem.GetComponent<SourceStoneItem>().quality = 1;
               SourceStoneKongItem.GetComponent<SourceStoneItem>().type = item;
               SourceStoneKongItem.transform.Find("button1").GetComponent<Image>().sprite=WeaponSourceConfig.GetWeaponSourceStoneSprite(1, item);
               SourceStoneKongItem.transform.Find("Text1").GetComponent<Text>().text = t.Count.ToString();
            }
         }
      }
   }
}
