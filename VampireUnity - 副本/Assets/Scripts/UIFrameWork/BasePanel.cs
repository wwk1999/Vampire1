using UnityEngine;

public abstract class BasePanel 
{
       public UIType uiType { get;private set; }
       public BasePanel(UIType uiType)
       {
              this.uiType = uiType;
       }
       public virtual void OnEnter() { }
       public virtual void OnPause() { }
       public virtual void OnResume() { }
       public virtual void OnExit() { }

}
