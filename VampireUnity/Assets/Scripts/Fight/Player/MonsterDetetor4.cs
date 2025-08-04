using UnityEngine;

public class MonsterDetetor4 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            Debug.Log("Boss进入触发器");
        }
        Debug.Log("进入触发器4");
        //判断是否是怪物
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            if(other.transform.position.y < transform.position.y-4)
                return;
            if(other.transform.position.y > transform.position.y+4)
                return;
            //获取怪物脚本
            MonsterBase monster = other.GetComponent<MonsterBase>();
            //Debug.Log(monster);
            //将怪物添加到队列中
            GameController.S.monsterDetetor4.Add(monster);
            //Debug.Log(GameController.Instance._monsterDetetor3.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("离开触发器");
        //判断是否是怪物
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            //获取怪物脚本
            MonsterBase monster = other.GetComponent<MonsterBase>();
            //Debug.Log(monster);
            //将怪物从队列中移除
            GameController.S.monsterDetetor4.Remove(monster);
            //Debug.Log(GameController.Instance._monsterDetetor3.Count);
        }
    }
}
