using System;
using UnityEngine;

public class PrimaryExTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            var monster = other.GetComponent<MonsterBase>();
            if (monster != null)
            {
                monster.Hurt(GlobalPlayerAttribute.TotalDamage);
            }
        }
    }
}
