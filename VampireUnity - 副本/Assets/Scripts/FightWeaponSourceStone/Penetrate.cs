using Mysql;
using UnityEngine;

public class Penetrate : FightWeaponSourceStoneBase
{
    public Penetrate() : base(new SourceStoneTable()){}
    
    private void Awake()
    {
        SourceStoneTable.Count = 1;
        SourceStoneTable.SourceStoneName ="初级穿透源石";
        SourceStoneTable.Userid = GlobalUserInfo.Userid;
        SourceStoneTable.Quality= (int)WeaponSourceStoneQuality.White;
        SourceStoneTable.SourceStoneType = (int)WeaponSourceStoneType.Penetrate;
        SourceStoneTable.SourceStoneId = 1; // 假设穿透源石的ID为1
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
                if(sourceStoneTable.SourceStoneType==(int)WeaponSourceStoneType.Penetrate&&
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
