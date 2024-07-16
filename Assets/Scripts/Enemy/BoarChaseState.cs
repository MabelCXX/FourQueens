using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarChaseState : BaseState
{

    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        // Debug.Log("Chase");
        currentEnemy.currentSpeed = currentEnemy.chaseSpeed;
        currentEnemy.anim.SetBool("run", true);
        currentEnemy.anim.SetBool("walk", false);
    }

    public override void LogicUpdate()
    {
        if(currentEnemy.lostTimeCounter <= 0)
        {
            currentEnemy.SwitchState(NPCState.Patrol);
        }

        if ((currentEnemy.physikCheck.touchLeftWall && currentEnemy.faceDir.x < 0) || (currentEnemy.physikCheck.touchRightWall && currentEnemy.faceDir.x > 0))
        {
            currentEnemy.transform.localScale = new Vector3(currentEnemy.faceDir.x, 1.5f, 1.5f);
            currentEnemy.anim.SetBool("run", false);
        };

    }

    public override void PhysicsUpdate()
    {
   
    }


    public override void OnExit()
    {
        // currentEnemy.lostTimeCounter = currentEnemy.lostTime;
        currentEnemy.anim.SetBool("run", false);
    }
}
