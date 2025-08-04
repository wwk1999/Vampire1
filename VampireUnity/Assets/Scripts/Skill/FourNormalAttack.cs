using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GetComponent<Animator>().Play("4NormalAttack");
    }
    private void Update()
    {
        rg.velocity = MoveDirection * MoveSpeed;
        //粒子朝向MoveDirection
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")|| other.CompareTag("Boss"))
        {
            var hit = GameController.S.FourNormalAttackHitQueue.Dequeue();
            hit.SetActive(true);
            hit.transform.position = other.transform.position;
            hit.GetComponent<ParticleSystem>().Play();
            other.GetComponent<MonsterBase>().Hurt(20);
            GameController.S.StartCoroutine(WaitAndDestroy(hit)); // 在GameController上启动
            gameObject.SetActive(false);
        }
    }
    
    private IEnumerator WaitAndDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.SetActive(false);
        GameController.S.ThreeNormalAttackHitQueue.Enqueue(obj);
    }
}
