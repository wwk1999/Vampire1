using System;
using System.Collections;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    public ParticleSystem trail;
    [NonSerialized] public int Explosion = 0;
    [NonSerialized] public int Penetrate = 0;
    
    private IEnumerator ExEnd(float seconds,GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
        FightBGController.S.PrimaryNormalAttackExQueue.Enqueue(obj);
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Monster")||other.gameObject.CompareTag("Boss"))
        {
            trail.gameObject.SetActive(false);
            other.transform.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
            ParticleSystem ps = GetComponent<ParticleSystem>();
            //获得粒子碰撞位置
            var collisionEvents = new System.Collections.Generic.List<ParticleCollisionEvent>();
            int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);
            var explosion = FightBGController.S.PrimaryNormalAttackExQueue.Dequeue();
            explosion.transform.Find("PrimaryExParticles").GetComponent<ParticleSystem>().Play();

            StartCoroutine(ExEnd(0.6f,explosion));
            for (int i = 0; i < numCollisionEvents; i++)
            {
                Vector3 collisionPos = collisionEvents[i].intersection;
                switch (Explosion)
                {
                    case 1:
                        if (FightBGController.S.PrimaryNormalAttackExQueue.Count > 0)
                        { 
                            explosion.SetActive(true);
                            explosion.transform.position = collisionPos;
                        }
                        break;
                    case 2:
                        if (FightBGController.S.PrimaryNormalAttackExQueue.Count > 0)
                        {
                            explosion.SetActive(true);
                            explosion.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                            explosion.transform.position = collisionPos;
                        }
                        break;
                    case 3:
                        if (FightBGController.S.PrimaryNormalAttackExQueue.Count > 0)
                        {
                            explosion.SetActive(true);
                            explosion.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                            explosion.transform.position = collisionPos;
                        }
                        break;
                }
            }
        }
    }
}
