using System;
using System.Collections;
using UnityEngine;

public class MonsterHurtText : MonoBehaviour
{
    // //动画事件，销毁text
    // public void DestroyText()
    // {
    //     Destroy(gameObject);
    // }

    private void OnEnable()
    {
        Rigidbody2D equipRb=GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-30f, 30f)));
        equipRb.velocity = new Vector2(UnityEngine.Random.Range(-1.5f, 1.5f), UnityEngine.Random.Range(2f, 4f));
        StartCoroutine(StopVelocityAfterDelay(equipRb, 0.4f));
    }
    private IEnumerator StopVelocityAfterDelay(Rigidbody2D rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(rb == null)
            Debug.Log("rb为空");
        rb.velocity = Vector2.zero;
        //设置重力为0
        rb.gravityScale = 0;
        gameObject.SetActive(false);
        GameController.S.MonsterHurtTextQueue.Enqueue(gameObject);
    }
}
