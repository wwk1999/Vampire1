using UnityEngine;
using Random = System.Random;
using Mysql;
public class TreeManHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

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
        EquipAttributes.suitid = 1;
        EquipAttributes.suitname = "树人套装";
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.equip_type_name = "头盔";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.Defense=random.Next(4,7);
        EquipAttributes.HP=random.Next(12,20);
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            if (isSend) return;
            Debug.Log("名字："+EquipAttributes.EquipName);
            //将这件装备的属性添加到数据库
            EquipIDData.S.SavaEquip(EquipAttributes);
            StoreController.S.SaveStoreData();            isSend = true;
          
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,EquipAttributes);


            //如果被拾取，销毁装备
            gameObject.SetActive(false);
            GameController.S.TreeManHelmetQueue.Enqueue(gameObject);        }
    }
}
