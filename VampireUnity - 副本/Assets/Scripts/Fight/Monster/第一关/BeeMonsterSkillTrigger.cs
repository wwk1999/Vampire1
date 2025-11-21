using System;
using UnityEngine;

public class BeeMonsterSkillTrigger : MonoBehaviour
{
    [NonSerialized]public EliteBeeMonster BeeMonster;

    private void Update()
    {
        if(BeeMonster&&gameObject.activeSelf)
            transform.position= BeeMonster.transform.position;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BeeMonster.IsTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BeeMonster.IsTrigger = false;
        }
    }
}
