using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendApplication : MonoBehaviour
{
    public Button exitButton;//退出按钮
    public GameObject content;

    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
        //销毁content下的所有子物体
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var friendApplication in FriendConfig.friendApplicationList)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/UI/FriendApplicationItem"), content.transform);
            item.transform.Find("Name").GetComponent<Text>().text= friendApplication.requester_username;
            item.transform.Find("Level").GetComponent<Text>().text= friendApplication.requester_username;
            item.GetComponent<FriendApplicationItem>().FromUserid= friendApplication.fromuserid;
        }
    }
}
