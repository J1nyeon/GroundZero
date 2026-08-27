using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        float maxDis = 100f;
        if (Physics.Raycast(fsm.transform.position, fsm.targetPlayer.position, out RaycastHit hit, maxDis, fsm.layer) == true)
        {
            Debug.Log($"적 레이에 닿은 콜라이더: {hit.collider.name}");
            if (hit.collider.CompareTag("Wall"))
            {
                fsm.canAttack = false;
            }
            if (hit.collider.CompareTag("Player"))
            {
                fsm.canAttack = true;
            }
        }
        // 추격하다가
        if (fsm.targetPlayer != null && fsm.canAttack == false)
        {
            fsm.Chase();
        }
        // 공격 범위 내에 들어오면 Attack 상태로 전환
        // float dis = Vector3.Distance(fsm.transform.position, fsm.targetPlayer.position);
        // 체이스상태 
        if (fsm.targetDistance < fsm.attackRange && fsm.canAttack == true)
        {
            
            fsm.ChangeState(fsm.attackState);
        }
        // TODO
        // 일정 거리내에서 벗어나면 patrol 상태로 
        // 일단 idle상태로 해놓고 추후 수정
        if (fsm.targetDistance > fsm.chaseRange)
        {
            fsm.ChangeState(fsm.idleState);
        }
    }
   
}
