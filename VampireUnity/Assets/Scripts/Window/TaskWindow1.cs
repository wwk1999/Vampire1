using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskWindow1 : MonoBehaviour
{
    public Button exitButton; // 退出按钮

    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Debug.Log("任务界面退出");
            WindowController.S.RoleWindow.SetActive(true);
        });
    }
}
