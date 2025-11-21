using UnityEngine;

public class UIType 
{
   public string name;
   public string path;

   public UIType(string path)
   {
      this.path = path;
      this.name = path.Substring(path.LastIndexOf("/") + 1);
   }
}
