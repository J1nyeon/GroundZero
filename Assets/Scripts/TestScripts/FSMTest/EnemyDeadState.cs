using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : BaseState
{
    public EnemyDeadState(EnemyFSM fsm) : base(fsm) { }

    public override void Enter()
    {
        fsm.agent.isStopped = true;
        fsm.StateAnimation(false, false, false, false);
        fsm.animator.SetBool("isDead", fsm.isDead);
        fsm.StartCoroutine(fsm.CoEnemyDead());
    }
}
