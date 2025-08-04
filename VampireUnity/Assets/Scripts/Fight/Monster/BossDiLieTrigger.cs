using UnityEngine;

public class BossDiLieTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            GameController.S.gamePlayer.PlayerHurt(FightBGController.S.TreeManBoss.Attack);
        }
    }
}
