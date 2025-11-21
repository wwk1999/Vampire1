using System;
using UnityEngine;
using UnityEngine.UI;

public class BagExitButton : MonoBehaviour
{
    public Button bagExitButton;

    private void Awake()
    {
        bagExitButton.onClick.AddListener(() =>
        {
            BagController.S.HideBag();
        });
    }
}
