using System;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
   
   void DestroyGameObject()
   {
      gameObject.SetActive(false);
      FightBGController.S.SpiderWebQueue.Enqueue(this);
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         GameController.S.gamePlayer.TempChangePlayerMoveSpeed(0, 1);
        Invoke("DestroyGameObject", 1f);
      }
   }
}
