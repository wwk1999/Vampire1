using Mysql;
using UnityEngine;

public class Division : FightWeaponSourceStoneBase
{
    public Division() : base(new SourceStoneTable()){}

    private void Awake()
    {
        SourceStoneTable.SourceStoneName ="初级分裂源石";
        SourceStoneTable.Count = 1;
        SourceStoneTable.Userid = GlobalUserInfo.Userid;
        SourceStoneTable.Quality= (int)WeaponSourceStoneQuality.White;
        SourceStoneTable.SourceStoneType = (int)WeaponSourceStoneType.Division;
        SourceStoneTable.SourceStoneId = 7; // 假设分裂源石的ID为7
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
                if(sourceStoneTable.SourceStoneType==(int)WeaponSourceStoneType.Division&&
                   sourceStoneTable.Userid==GlobalUserInfo.Userid&&sourceStoneTable.Quality==(int)WeaponSourceStoneQuality.White)
                {
                    sourceStoneTable.Count++;
                    //如果被拾取，销毁装备
                    Destroy(gameObject);
                    return;
                }
            }

            SourceStoneServer.S.SendAddSourceStoneRequest(SourceStoneTable.SourceStoneId, 1);
            
            //BagController.S.EquipIdList.Add(SourceStoneTable);

            //如果被拾取，销毁装备
            Destroy(gameObject);
        }
    }
}
