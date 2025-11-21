using System;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    //不能序列化speed和damage
    [NonSerialized]
    private float speed;
    [NonSerialized]
    public int damage;
    [NonSerialized]public Vector3 Direction;
    //构造函数
    public BulletBase(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
    public void BulletMove()
    {
        //朝当前方向移动
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void Start()
    {
        SetbulletRotate();
    }


    public void SetbulletRotate()
    {
        transform.rotation = GameController.S.gamePlayer.currentGun.transform.rotation;
        //rotation的z减去-90
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z -= 90;
         if (GameController.S.gamePlayer.currentGun.gunSpriteRender.flipY==true)
         {
             GetComponent<SpriteRenderer>().flipY = true;
         }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
        transform.rotation = Quaternion.Euler(rotation);
        
        
    }

    private void Update()
    {
        BulletMove();
    }
}
