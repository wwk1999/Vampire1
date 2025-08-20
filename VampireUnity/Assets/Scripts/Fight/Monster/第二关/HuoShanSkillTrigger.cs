using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoShanSkillTrigger : MonoBehaviour
{
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (distance < 1f)
        {
            GameController.S.gamePlayer.PlayerHurt(10);
            Destroy(gameObject);
        }
    }
}
