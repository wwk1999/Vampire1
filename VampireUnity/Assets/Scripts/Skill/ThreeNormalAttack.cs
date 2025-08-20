using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;


    private void OnEnable()
    {
        transform.Find("Square").GetComponent<Animator>().Play("3NormalAttack");
    }

    private void Update()
    {
        rg.velocity = MoveDirection * MoveSpeed;
        //粒子朝向MoveDirection
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        transform.Find("Square").transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.ThreeNormalAttackHitQueue.Dequeue();
            hit.SetActive(true);
            hit.transform.position = other.transform.position;
            hit.GetComponent<ParticleSystem>().Play();
            other.transform.parent.GetComponent<MonsterBase>().Hurt(20);
            GameController.S.StartCoroutine(WaitAndDestroy(hit)); // 在GameController上启动
            gameObject.SetActive(false);
        }
    }
    //协程
    private IEnumerator WaitAndDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.SetActive(false);
        GameController.S.ThreeNormalAttackHitQueue.Enqueue(obj);
    }
}
