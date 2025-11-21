using UnityEngine;

public class BossWarning : MonoBehaviour
{
   public void SendCameraMoveToBoss()
   {
       ObserverModuleManager.S.SendEvent(ConstKeys.CameraMoveToBoss);
       Destroy(transform.parent.gameObject);
   }
}
