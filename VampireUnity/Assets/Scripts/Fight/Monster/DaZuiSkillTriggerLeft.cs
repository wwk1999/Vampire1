using System;
using UnityEngine;

public class DaZuiSkillTriggerLeft : MonoBehaviour
{
    [NonSerialized]public EliteDaZuiMonster DaZuiMonster;
    
    private void Update()
    {
        if(DaZuiMonster&&gameObject.activeSelf)
            transform.position= DaZuiMonster.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DaZuiMonster.IsTriggerLeft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DaZuiMonster.IsTriggerLeft = false;
        }    
    }
}
