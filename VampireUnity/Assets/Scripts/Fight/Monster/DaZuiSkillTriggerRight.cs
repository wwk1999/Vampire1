using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaZuiSkillTriggerRight : MonoBehaviour
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
            DaZuiMonster.IsTriggerRight= true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DaZuiMonster.IsTriggerRight = false;
        }    
    }
}
