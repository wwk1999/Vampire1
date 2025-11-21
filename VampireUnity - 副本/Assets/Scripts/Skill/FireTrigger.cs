using System;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    private float _damegeTime=0.5f;
    private float _damegeCurrentTime=0f;

    private void Update()
    {
        _damegeCurrentTime+= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _damegeCurrentTime >= _damegeTime)
        {
            _damegeCurrentTime = 0;
            GameController.S.gamePlayer.PlayerHurt(FightBGController.S.TreeManBoss.Attack);
        }
    }
}
