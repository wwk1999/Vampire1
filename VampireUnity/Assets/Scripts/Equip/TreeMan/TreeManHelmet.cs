using UnityEngine;
using Random = System.Random;
using Mysql;
public class TreeManHelmet : EquipBase
{
    public TreeManHelmet() : base( "TreeManHelmetFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManHelmetSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManHelmet";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.Denfense=random.Next(4,7);
        EquipAttributes.HP=random.Next(12,20);
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            //将这件装备的属性添加到数据库
            EquipAttributes.Equipid= BagController.S.MaxEquipid["GreenHelmet"]+1;
            BagController.S.MaxEquipid["GreenHelmet"]= EquipAttributes.Equipid;
            // EquipAttributes.Equipid= EquipController.S.MaxHelmetID(EquipAttributes.Quality) + 1;
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
