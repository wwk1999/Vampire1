using System;
using UnityEngine;

public class TreeManJumpTrigger : MonoBehaviour
{
    public bool isTrigger = false; //是否触发跳跃
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
