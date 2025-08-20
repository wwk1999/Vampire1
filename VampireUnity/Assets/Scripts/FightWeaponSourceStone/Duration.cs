using Mysql;
using UnityEngine;

public class Duration : FightWeaponSourceStoneBase
{
    public Duration() : base(new SourceStoneTable()){}
    
    private void Awake()
    {
        SourceStoneTable.SourceStoneName ="初级延时源石";
        SourceStoneTable.Count = 1;
        SourceStoneTable.Userid = GlobalUserInfo.Userid;
        SourceStoneTable.Quality= (int)WeaponSourceStoneQuality.White;
        SourceStoneTable.SourceStoneType = (int)WeaponSourceStoneType.Duration;
        SourceStoneTable.SourceStoneId = 31; // 假设延时源石的ID为31
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
                if(sourceStoneTable.SourceStoneType==(int)WeaponSourceStoneType.Duration&&
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
