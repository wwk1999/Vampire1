using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using UnityEngine;

public class ClickFx : MonoBehaviour
{
    public UIParticle clickFx;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标或按钮点击时播放特效
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (clickFx != null)
            {
                //clickFx的位置为鼠标点击位置或安卓触摸位置
                Vector3 mousePosition = Input.mousePosition;
                if (Input.touchCount > 0)
                {
                    mousePosition = Input.GetTouch(0).position;
                }
                
                clickFx.transform.position = mousePosition;
                
                clickFx.Play();
            }
        }
    }
}
