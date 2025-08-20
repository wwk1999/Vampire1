using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoShanSkilll1 : MonoBehaviour
{
   public void ShotSkill1()
   {
      //transform.parent.Find("Skill1Bullet").gameObject.SetActive(true);
      ObserverModuleManager.S.SendEvent("HuoShanSkill1Q2", null);
   }
   
   public void AnimationEnd()
   {
      gameObject.SetActive(false);
      //transform.parent.Find("Skill1Bullet").gameObject.SetActive(false);
   }
}
