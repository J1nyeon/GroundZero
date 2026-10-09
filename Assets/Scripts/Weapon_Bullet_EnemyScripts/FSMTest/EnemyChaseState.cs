using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyChaseState : BaseState
{
    public EnemyChaseState(EnemyFSM fsm) : base(fsm) { }
   

    public override void Enter()
    {
        
        fsm.StateAnimation(false, true, false, false);
        
        fsm.agent.isStopped = false;
    }

    public override void Do()
    {

        fsm.EnemyDead(fsm.deadState);
        fsm.TargetRaycast();
        // 추격하다가
        if (fsm.targetPlayer != null)
        {
            fsm.Chase();
        }
        // 공격 범위 내에 들어오고 플레이어 이외의 물체에 막혀있지 않다면 Attack 상태로 전환
        // 체이스상태 
        ////Debug.Log("거리: " + fsm.targetDistance +
        //          " / 공격거리: " + fsm.attackRange +
        //          " / isBlocked: " + fsm.isBlocked);

        if (fsm.targetDistance < fsm.attackRange && fsm.isBlocked == false)
        {
            //Debug.Log("공격 상태 전환 조건 통과");
            fsm.ChangeState(fsm.attackState);
            //Debug.Log("현재 상태 :" + fsm.currentState);
        }
        // TODO
        // 일정 거리내에서 벗어나면 patrol 상태로 
        // 일단 idle상태로 해놓고 추후 수정
        if (fsm.targetDistance > fsm.longRange)
        {
            fsm.ChangeState(fsm.patrolState);
            fsm.longRange = fsm.currentLongRange;
            fsm.chaseRange = fsm.currentChaseRange;
            fsm.attackRange = fsm.currentAttackRange;
        }
        
    }
    public override void Exit()
    {
        
    }
}
    // 문제 
    // 코너를 돌았을때 체이스상태인데도 추적하지않는 경우가 있음
    // ㄴ 거리 수치입력을 다시 해야하는 부분인거같아보임
    // 코너 이동시 한번씩 플레이어에게 달라붙을때까지 다가옴
    // ㄴ NavMeshAgent때문인가 ?
    // 가끔 벽뒤에서 fsm.canAttack이 true가 될때가 있음 
    // ㄴ 벽에 딱 달라붙어 이동할 경우 그런것같아 보임


