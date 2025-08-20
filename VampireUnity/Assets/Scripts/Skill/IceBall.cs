using System;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyBall",5f);    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            MonsterBase monster = other.transform.parent.GetComponent<MonsterBase>();
            if (monster != null && !monster.IsDead)
            {
                monster.Hurt(GlobalPlayerAttribute.TotalDamage);
            }
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }
    
}
