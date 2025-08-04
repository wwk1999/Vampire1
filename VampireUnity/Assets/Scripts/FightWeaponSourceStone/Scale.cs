using Mysql;
using UnityEngine;

public class Scale : FightWeaponSourceStoneBase
{
    public Scale() : base(new SourceStoneTable()){}
    private void Awake()
    {
        SourceStoneTable.EquipName ="初级大小源石";
        SourceStoneTable.Count = 1;
        SourceStoneTable.Userid = GlobalUserInfo.Userid;
        SourceStoneTable.Quality= (int)WeaponSourceStoneQuality.White;
        SourceStoneTable.SourceStoneType = (int)WeaponSourceStoneType.Scale;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            foreach (var sourceStoneTable in BagController.S.SourceStoneTable)
            {
                if(sourceStoneTable.Value.SourceStoneType==(int)WeaponSourceStoneType.Scale&&
                   sourceStoneTable.Value.Userid==GlobalUserInfo.Userid&&sourceStoneTable.Value.Quality==(int)WeaponSourceStoneQuality.White)
                {
                    sourceStoneTable.Value.Count++;
                    //如果被拾取，销毁装备
                    Destroy(gameObject);
                    return;
                }
            }
            //将这件装备的属性添加到数据库
            SourceStoneTable.Equipid= BagController.S.MaxEquipid["WhiteProp"]+1;
            BagController.S.MaxEquipid["WhiteProp"]= SourceStoneTable.Equipid;

            //EquipAttributes.Equipid= EquipController.S.MaxCloakID(EquipAttributes.Quality) + 1;
            //EquipController.S.InsertEquip(EquipAttributes);
            //将这件装备的属性添加到BagController上
            BagController.S.SourceStoneTable.Add(SourceStoneTable.Equipid,SourceStoneTable);
            BagController.S.WhiteWeaponSourceStoneTable.Add(SourceStoneTable.Equipid,SourceStoneTable);
            BagController.S.EquipIdList.Add(SourceStoneTable);

            //如果被拾取，销毁装备
            Destroy(gameObject);
        }
    }

}
