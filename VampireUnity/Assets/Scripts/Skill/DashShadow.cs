using System;
using UnityEngine;

public class DashShadow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [NonSerialized]public int StartA ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameController.S.gamePlayer.playerSkeleton.Skeleton.FlipX)
        {
            spriteRenderer.flipX = true;
            transform.localPosition=new Vector3(transform.localPosition.x+0.3f,transform.localPosition.y-0.05f,transform.localPosition.z);
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        // 创建一个临时变量保存当前的颜色
        Color newColor = spriteRenderer.color;

        // 修改Alpha值
        newColor.a = StartA / 255f; // Alpha值应在0到1之间，所以需要除以255

        // 将修改后的颜色重新赋值给SpriteRenderer组件
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = spriteRenderer.color;
        StartA-=5;
        newColor.a=StartA/255f;
        spriteRenderer.color = newColor;
        if (spriteRenderer.color.a==0)
        {
            Destroy(gameObject);
        }
    }
}