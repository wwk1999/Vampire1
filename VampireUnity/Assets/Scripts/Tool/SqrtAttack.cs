using System;
using UnityEngine;

public class SqrtAttack : MonoBehaviour
{
   private void OnEnable()
   {
      GetComponent<Animator>().Play("SqrtAttack");
   }
   
   //动画事件
   public void SqrtAttackEnd()
   {
      gameObject.SetActive(false);
      FightBGController.S.SqrtAttackQueue.Enqueue(this);
   }
}
