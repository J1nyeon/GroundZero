using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttackState : BaseState
{
    public EnemyAttackState(EnemyFSM fsm) : base(fsm) { }
    
    public override void Enter() 
    {
        fsm.timer = 0f; // 들어올때마다 초기화
        //fsm.canAttack = true; // 공격 가능상태로 전환

        fsm.agent.isStopped = true;
        fsm.agent.ResetPath();
    }

    public override void Do()
    {
        // 1. 공격 
        // 정면으로 레이를 쐈을때 벽이면 추격상태로 전환
        // 캐릭터가 레이에 닿았을경우에만 공격
        if (fsm.canAttack == true)
        {
            fsm.Attack();
            fsm.Detect();
        }
       

        // 2. 공격 범위에서 벗어나면 추격 Chase상태로 전환
        //float dis = Vector3.Distance(fsm.transform.position, fsm.targetPlayer.position);
        if (fsm.targetDistance > fsm.attackRange)
        {
            fsm.ChangeState(fsm.chaseState);
            
        }
    }
    public override void Exit()
    {
        //fsm.canAttack = false; // 벗어날때 다시 공격할 수 없는 상태로 전환
    }   
}
