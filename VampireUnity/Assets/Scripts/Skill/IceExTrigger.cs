using System;
using UnityEngine;

public class IceExTrigger : MonoBehaviour
{
   private void OnEnable()
   {
      GetComponent<Animator>().Play("IceExTrigger1");
   }
   
   //动画事件
   public void OnAnimationEnd()
   {
     gameObject.SetActive(false);
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if ((other.CompareTag("Monster")||other.CompareTag("Boss"))&&other.GetComponent<MonsterBase>())
      {
         other.GetComponent<MonsterBase>().Hurt(100);
      }
   }
}
