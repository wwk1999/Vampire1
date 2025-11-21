using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HuoShanSkill2 : MonoBehaviour
{
    private void Start()
    {
        //通过transform向下移动
        StartCoroutine(MoveDown());
    }
    private IEnumerator MoveDown()
    {
        float x = UnityEngine.Random.Range(-3f, 3f);
        float speed = 5f; // 设置下落速度
        float distance = 10f; // 设置下落距离
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.down * distance+ Vector3.right * x; // 向下移动10个单位，并在x轴上随机偏移

        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            yield return null; // 等待下一帧
        }

        Destroy(gameObject); // 下落结束后销毁对象
    }

    private void Update()
    {
        var pos=new Vector2(transform.position.x,transform.position.y-0.3f);
        float distance = Vector2.Distance(pos, GameController.S.gamePlayer.transform.position);
        if (distance < 0.4f)
        {
            GameController.S.gamePlayer.PlayerHurt(10);
        }
    }
}
