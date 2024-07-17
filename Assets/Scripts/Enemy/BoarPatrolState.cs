using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarPatrolState : BaseState
{

    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.normalSpeed;
        currentEnemy.anim.SetBool("walk", true);
        currentEnemy.anim.SetBool("run", false);
    }

    public override void LogicUpdate()
    {

        if (currentEnemy.FoundPlayer())
        {
            currentEnemy.SwitchState(NPCState.Chase);
        }

        if ((currentEnemy.physikCheck.touchLeftWall && currentEnemy.faceDir.x < 0) || (currentEnemy.physikCheck.touchRightWall && currentEnemy.faceDir.x > 0))
        {
            currentEnemy.transform.localScale = new Vector3(currentEnemy.faceDir.x, 1.5f, 1.5f);
            currentEnemy.anim.SetBool("walk", false);
        }
        else
        {
            currentEnemy.anim.SetBool("walk", true);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }


    public override void OnExit()
    {
        currentEnemy.anim.SetBool("walk", false);
        // Debug.Log("Exit");
    }
}
