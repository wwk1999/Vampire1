using System;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnEnable()
    {
        GameController.S.gamePlayer.IsWuDi = true;
        GetComponent<Animator>().Play("PlayerHit");
    }

    public void AnimationEnd()
    {
        GameController.S.gamePlayer.IsWuDi = false;
        gameObject.SetActive(false);
        FightBGController.S.PlayerHitQueue.Enqueue(this);
    }
}
