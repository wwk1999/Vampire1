using System;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    public GameObject beeBulletHit;

    public void DestroyInvoke()
    {
        Destroy(gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            ParticleSystem beebullethit=Instantiate(beeBulletHit.gameObject, GameController.S.gamePlayer.transform.position, Quaternion.identity).transform.Find("Hit 1").GetComponent<ParticleSystem>();
            beebullethit.Play();
            GameController.S.gamePlayer.PlayerHurt(0);
        }

        if (other.CompareTag("BG"))
        {
            ParticleSystem beebullethit=Instantiate(beeBulletHit.gameObject, GameController.S.gamePlayer.transform.position, Quaternion.identity).transform.Find("Hit 1").GetComponent<ParticleSystem>();
            beebullethit.Play();
            Invoke("DestroyInvoke",1f);
        }
    }
}
