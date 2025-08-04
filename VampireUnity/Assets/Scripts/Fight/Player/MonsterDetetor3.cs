using System;
using UnityEngine;

public class MonsterDetetor3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //判断是否是怪物
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            //获取怪物脚本
            MonsterBase monster = other.GetComponent<MonsterBase>();
            //Debug.Log(monster);
            //将怪物添加到队列中
            GameController.S.monsterDetetor3.Add(monster);
            //如果_monsterDetetor3中存在monster，则移除
            if (GameController.S.monsterDetetor4.Contains(monster))
            {
                GameController.S.monsterDetetor4.Remove(monster);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //判断是否是怪物
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            //获取怪物脚本
            MonsterBase monster = other.GetComponent<MonsterBase>();
            //Debug.Log(monster);
            //将怪物从队列中移除
            GameController.S.monsterDetetor3.Remove(monster);
            //如果_monsterDetetor3中不存在monster，则添加
            if (!GameController.S.monsterDetetor4.Contains(monster))
            {
                GameController.S.monsterDetetor4.Add(monster);
            }
            //Debug.Log(GameController.Instance._monsterDetetor2.Count);
        }
    }
}
