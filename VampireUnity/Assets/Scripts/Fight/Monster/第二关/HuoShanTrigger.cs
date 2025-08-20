using UnityEngine;

public class HuoShanTrigger : MonoBehaviour
{
    public bool isTrigger = false; //是否触发
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger= true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger= false; 
        }
    }
}
