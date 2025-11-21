using System;
using UnityEngine;

public class IceArrow : MonoBehaviour
{
    public ParticleSystem trail;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Monster")||other.gameObject.CompareTag("Boss"))
        {
            trail.gameObject.SetActive(false);
            other.transform.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
        }
    }
}
