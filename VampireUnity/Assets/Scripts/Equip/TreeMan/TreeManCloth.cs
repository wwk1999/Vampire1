using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloth : EquipBase
{
    public TreeManCloth() : base( "TreeManClothFight", SuitType.TreeMan,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManClothSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        System.Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManCloth";
        //暂时写死
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.Denfense=random.Next(5,8);
        EquipAttributes.HP=random.Next(25,40);
            
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            //将这件装备的属性添加到数据库
            EquipAttributes.Equipid= BagController.S.MaxEquipid["GreenCloth"]+1;
            BagController.S.MaxEquipid["GreenCloth"]= EquipAttributes.Equipid;
            // EquipAttributes.Equipid= EquipController.S.MaxClothID(EquipAttributes.Quality) + 1;
            // EquipController.S.InsertEquip(EquipAttributes);
            //将这件装备的属性添加到BagController上
            BagController.S.EquipidSprite.Add(EquipAttributes.Equipid,SpriteRenderer.sprite);
            BagController.S.EquipidTable.Add(EquipAttributes.Equipid,EquipAttributes);
            BagController.S.GreenEquipidTable.Add(EquipAttributes.Equipid,EquipAttributes);
            BagController.S.EquipIdList.Add(EquipAttributes);


            //如果被拾取，销毁装备
            Destroy(gameObject);
        }
    }
}
