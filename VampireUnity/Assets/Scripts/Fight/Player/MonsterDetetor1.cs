using System;
using UnityEngine;

public class MonsterDetetor1 : MonoBehaviour
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
            GameController.S.monsterDetetor1.Add(monster);
            //如果_monsterDetetor2中存在monster，则移除
            if (GameController.S.monsterDetetor2.Contains(monster))
            {
                GameController.S.monsterDetetor2.Remove(monster);
            }
            //Debug.Log(GameController.Instance._monsterDetetor1.Count);
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
            GameController.S.monsterDetetor1.Remove(monster);
            //如果_monsterDetetor2中不存在monster，则添加
            if (!GameController.S.monsterDetetor2.Contains(monster))
            {
                GameController.S.monsterDetetor2.Add(monster);
            }
            //Debug.Log(GameController.Instance._monsterDetetor1.Count);
        }
    }
}
