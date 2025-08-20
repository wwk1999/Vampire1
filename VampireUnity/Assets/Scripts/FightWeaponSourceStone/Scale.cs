using Mysql;
using UnityEngine;

public class Scale : FightWeaponSourceStoneBase
{
    public Scale() : base(new SourceStoneTable()){}
    private void Awake()
    {
        SourceStoneTable.SourceStoneName ="初级大小源石";
        SourceStoneTable.Count = 1;
        SourceStoneTable.Userid = GlobalUserInfo.Userid;
        SourceStoneTable.Quality= (int)WeaponSourceStoneQuality.White;
        SourceStoneTable.SourceStoneType = (int)WeaponSourceStoneType.Scale;
        SourceStoneTable.SourceStoneId = 25; // 假设大小源石的ID为25
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
                if(sourceStoneTable.SourceStoneType==(int)WeaponSourceStoneType.Scale&&
                   sourceStoneTable.Userid==GlobalUserInfo.Userid&&sourceStoneTable.Quality==(int)WeaponSourceStoneQuality.White)
                {
                    sourceStoneTable.Count++;
                    //如果被拾取，销毁装备
                    Destroy(gameObject);
                    return;
                }
            }
            SourceStoneServer.S.SendAddSourceStoneRequest(SourceStoneTable.SourceStoneId, 1);
            
            //如果被拾取，销毁装备
            Destroy(gameObject);
        }
    }

}
