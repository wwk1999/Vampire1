using System;
using UnityEngine;

public class MonsterFlyObjectBase : MonoBehaviour
{
    //不能序列化speed和damage
    [NonSerialized]
    private float _speed;
    [NonSerialized]
    private int _damage;
    public MonsterFlyObjectBase(float speed, int damage)
    {
        _speed = speed;
        _damage = damage;
    }
    private void Awake()
    {
        SetFlyObjectRotate();
    }

    private void Update()
    {
        FlyObjectMove();
    }

    public void SetFlyObjectRotate()
    {
        //飞行物方向
        Vector3 direction = (GameController.S.gamePlayer.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void FlyObjectMove()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.S.gamePlayer.PlayerHurt(_damage);
        }
    }
}
