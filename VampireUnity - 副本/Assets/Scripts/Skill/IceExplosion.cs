using UnityEngine;

public class IceExplosion : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.transform.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
        }
    }
}
