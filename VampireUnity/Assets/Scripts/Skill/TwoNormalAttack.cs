using System;
using UnityEngine;

public class TwoNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    public ParticleSystem ps;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    
    [NonSerialized] public float HitTime = 0.5f;
    [NonSerialized] public float CurrentTime = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
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
                other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
            }
        }
        
    }

    private void Update()
    {
        rg.velocity = MoveDirection * MoveSpeed;
    }

   
}
