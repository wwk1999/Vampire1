using System;
using System.Collections;
using Mysql;
using UnityEngine;

public enum WeaponSourceStoneQuality
{
    None,
    White,
    Green,
    Blue,
    Purple,
    Orange,
    Red
}

public enum WeaponSourceStoneType
{
    None,
    Penetrate,
    Division,
    ExtremeSpeed,
    Explosion,
    Scale,
    Duration
}
public class FightWeaponSourceStoneBase : BagObjectBase
{
   [NonSerialized]public SourceStoneTable SourceStoneTable; // 源石属性
   [NonSerialized]public Rigidbody2D equipRb;
   [NonSerialized]public float speed = 5f; // 装备跟随的速度
   [NonSerialized]public bool isPickUp = false; // 是否被拾取

   public FightWeaponSourceStoneBase(SourceStoneTable SourceStoneTable)
   {
       this.SourceStoneTable = SourceStoneTable;
   }
   
   private void Start()
   {
       bagObjectType = BagObjectType.WeaponSourceStone;
       equipRb=GetComponent<Rigidbody2D>();
       equipRb.velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));

       StartCoroutine(StopVelocityAfterDelay(equipRb, 0.75f));
   }
   private void Update()
   {
       if(isPickUp)
           transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position, Time.deltaTime * speed);
   }
   
   private IEnumerator StopVelocityAfterDelay(Rigidbody2D rb, float delay)
   {
       yield return new WaitForSeconds(delay);
       if(rb == null)
           Debug.Log("rb为空");
       rb.velocity = Vector2.zero;
       //设置重力为0
       rb.gravityScale = 0;
   }
}
