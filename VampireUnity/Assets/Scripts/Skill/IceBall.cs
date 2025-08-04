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
        if ((other.CompareTag("Monster")||other.CompareTag("Boss"))&&other.GetComponent<MonsterBase>())
        {
            other.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }
    
}
