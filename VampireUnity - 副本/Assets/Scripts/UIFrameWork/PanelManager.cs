using UnityEngine;
using System.Collections.Generic;


public class PanelManager :XSingleton<PanelManager>
{
   public UIManager uiManager;
   public Stack<BasePanel> uiStack;
   public PanelManager()
   {
       uiStack = new Stack<BasePanel>();
       uiManager = new UIManager();
   }
    public void PushPanel(BasePanel panel)
    {
         if (uiStack.Count > 0)
         {
              uiStack.Peek().OnPause();
         }
         uiStack.Push(panel);
         //创建ui，并将ui放到uidic中
         GameObject ui = uiManager.GetUIWindow(panel.uiType);
         UITool.S.activePanel = ui;
         panel.OnEnter();
    }
    public void PopPanel()
    {
         if (uiStack.Count > 0)
         {
              BasePanel panel = uiStack.Pop();
              panel.OnExit();
              if (uiStack.Count > 0)
              {
                   uiStack.Peek().OnResume();
              }
         }
         UITool.S.activePanel=uiManager.GetUIWindow(uiStack.Peek().uiType);
    }
}
