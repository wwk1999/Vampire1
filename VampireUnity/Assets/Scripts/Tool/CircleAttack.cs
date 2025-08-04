using System;
using UnityEngine;

public enum CircleAttackState
{
    None,
    TreeManSkill1,
    TreeManSkill2,
}
public class CircleAttack : MonoBehaviour
{
    public CircleAttackState circleAttackState= CircleAttackState.None;
    private void OnEnable()
    {
        FightBGController.S.HaveCircleAttack = true;
        GetComponent<Animator>().Play("CircleAttack");
    }

    private void OnDisable()
    {
        FightBGController.S.HaveCircleAttack = false;
        
    }

    public void OnCircleAttackEnd()
    {
        if (circleAttackState==CircleAttackState.TreeManSkill1)
        {
            // FightBGController.S.TreeManBoss.Skill1End(transform.position);
             FightBGController.S.HaveCircleAttack = false;
             gameObject.SetActive(false);
             circleAttackState = CircleAttackState.None;
             FightBGController.S.TreeManBoss.CircleAttackEnd = true;
        }
        if (circleAttackState==CircleAttackState.TreeManSkill2)
        {
            gameObject.SetActive(false);
            circleAttackState = CircleAttackState.None;
            FightBGController.S.CircleAttackQueue.Enqueue(this);
            //生成火焰
            TreeManFire fire= FightBGController.S.TreeManFireQueue.Dequeue();
            Debug.Log(FightBGController.S.TreeManFireQueue.Count);
            fire.transform.position = transform.position;
            fire.gameObject.SetActive(true);
        }

        // if (FightBGController.S.TreeManBoss && FightBGController.S.TreeManBoss.MonsterState == State.Skill2)
        // {
        //     if (FightBGController.S.FireCount < 5)
        //     {
        //         FightBGController.S.HaveCircleAttack = false;
        //         gameObject.SetActive(false);
        //         FightBGController.S.FireCount++;
        //         ObserverModuleManager.S.SendEvent(ConstKeys.TreeManFireSkill1);
        //     }
        //     else
        //     {
        //         FightBGController.S.FireCount=0;
        //         FightBGController.S.HaveCircleAttack = false;
        //         gameObject.SetActive(false);
        //     }
        // }

       
        //FightBGController.S.TreeManBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //FightBGController.S.TreeManBoss.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
    }
}
