using Mysql;
using UnityEngine;

public class Explosion : FightWeaponSourceStoneBase
{
    public Explosion() : base(new SourceStoneTable()){}
    private void Awake()
    {
        SourceStoneTable.SourceStoneName ="初级爆炸源石";
        SourceStoneTable.Count = 1;
        SourceStoneTable.Userid = GlobalUserInfo.Userid;
        SourceStoneTable.Quality= (int)WeaponSourceStoneQuality.White;
        SourceStoneTable.SourceStoneType = (int)WeaponSourceStoneType.Explosion;
        SourceStoneTable.SourceStoneId = 19; // 假设爆炸源石的ID为19
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
                if(sourceStoneTable.SourceStoneType==(int)WeaponSourceStoneType.Explosion&&
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
