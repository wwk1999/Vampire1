using System;
using UnityEngine;

public class TwoNormalAttackTrigger : MonoBehaviour
{
    [NonSerialized] public float HitTime = 0.5f;
    [NonSerialized] public float CurrentTime = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            other.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= HitTime)
            {
                CurrentTime = 0;
                other.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
            }
        }
        
    }
}
