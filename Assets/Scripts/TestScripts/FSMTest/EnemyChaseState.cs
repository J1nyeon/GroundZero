using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : BaseState
{
    public EnemyChaseState(EnemyFSM fsm) : base(fsm) { }

    public override void Enter() 
    {
        fsm.agent.isStopped = false;
    }

    public override void Do()
    {
        // 추격하다가
        if (fsm.targetPlayer != null)
        {
            fsm.Chase();
        }
        // 공격 범위 내에 들어오면 Attack 상태로 전환
        float dis = Vector3.Distance(fsm.transform.position, fsm.targetPlayer.position);
        if (dis < fsm.attackDistance)
        {
            fsm.ChangeState(fsm.attackState);
        }
        // 일정 거리내에서 벗어나면 patrol 상태로 // 일단 idle상태로
        if (dis > fsm.chaseDistance)
        {
            fsm.ChangeState(fsm.idleState);
        }
    }
    public override void Exit()
    {
        
    }
}
