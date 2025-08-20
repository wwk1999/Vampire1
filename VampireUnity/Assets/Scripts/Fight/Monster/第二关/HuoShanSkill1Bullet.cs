using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoShanSkill1Bullet : MonoBehaviour
{
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("HuoShanSkill1Q2",HuoShanSkill1Q2);
    }

    public void HuoShanSkill1Q2(object[] args)
    {
        Debug.Log("火山boss发射剑气");
        GameObject bullet;
        Debug.Log("transform.position.x: " + transform.position.x);
        Debug.Log("GameController.S.gamePlayer.transform.position.x: " + GameController.S.gamePlayer.transform.position.x);
        if (transform.position.x > GameController.S.gamePlayer.transform.position.x)
        {
            bullet = Instantiate(Resources.Load("Prefabs/MonsterSkill/HuoShanSkillL"),transform) as GameObject;
           // bullet.transform.position = new Vector3(transform.position.x-3.5f,transform.position.y-0.25f,transform.position.z);
            //bullet.transform.Find("Skill1BulletL").GetComponent<SpriteRenderer>().flipX=!bullet.transform.Find("Skill1BulletL").GetComponent<SpriteRenderer>().flipX;
        }
        else
        {
            bullet = Instantiate(Resources.Load("Prefabs/MonsterSkill/HuoShanSkillR"),transform) as GameObject;
        }
        //朝向player
        if (GameController.S.gamePlayer != null)
        {
            Vector3 playerPosition = GameController.S.gamePlayer.transform.position;
            Vector3 direction = (playerPosition - bullet.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // if (transform.position.x > GameController.S.gamePlayer.transform.position.x)
            // {
            //     bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+30));
            // }else
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        //获取刚体组件
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            //设置速度
            rb.velocity = bullet.transform.right * 15f; // 10f 是速度值，可以根据需要调整
        }
    }
}
