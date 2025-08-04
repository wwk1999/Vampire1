using System;
using System.Collections;
using UnityEngine;

public class TreeManFire : MonoBehaviour
{
    public float delayTime = 8f; // 火焰持续时间
    private void OnEnable()
    {
        // var equipRb=GetComponent<Rigidbody2D>();
        // equipRb.linearVelocity = new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(10f, 15f));
        //
        // StartCoroutine(StopVelocityAfterDelay(equipRb, 1f));
        StartCoroutine(StopVelocityAfterDelay(delayTime));
    }
    private IEnumerator StopVelocityAfterDelay( float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        FightBGController.S.TreeManFireQueue.Enqueue(this);
    }
}
