using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerErrorWindow : MonoBehaviour
{
   public Button tryConnectBtn;
   public Button exitBtn;

   
   private void Start()
   {
      tryConnectBtn.onClick.AddListener(() =>
      {
        
      });
      exitBtn.onClick.AddListener(() =>
      {
         Application.Quit();
      });
   }
}
