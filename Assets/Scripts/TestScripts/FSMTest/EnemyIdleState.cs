using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : BaseState
{
    public EnemyIdleState(EnemyFSM fsm) : base(fsm) { }

    public override void Enter() 
    {
        //애니메이션 재생

        fsm.agent.isStopped = true;
        fsm.agent.ResetPath();
    }

    public override void Do()
    {
        // 1. 일정 범위에 들어오면 chase상태로 전환
        //float dis = Vector3.Distance(fsm.transform.position, fsm.targetPlayer.position);

        //if (fsm.targetDistance < fsm.detectRange)
        //{
        //    fsm.Detect(); // 거리내에 들어오면 감지하여 플레이어를 바라봄
        //}
        if (fsm.targetDistance < fsm.chaseRange)
        {
            fsm.ChangeState(fsm.chaseState);
        }
    }
    
}
