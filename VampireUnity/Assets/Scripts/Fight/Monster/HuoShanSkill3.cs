using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoShanSkill3 : MonoBehaviour
{
   private ParticleSystem particleSystem;
   
   private void OnEnable()
   {
      GetComponent<Animator>().Play("HuoShanSkill3");
      float distance = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
      if(distance<7f)
      {
         GameController.S.gamePlayer.PlayerHurt(10);
      }
      StartCoroutine(WaitAndDestroy());
   }
   
   
   private IEnumerator WaitAndDestroy()
   {
      yield return new WaitForSeconds(2f);
      gameObject.SetActive(false);
   }
}
