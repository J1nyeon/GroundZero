using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : BaseState
{
    public EnemyPatrolState(EnemyFSM fsm) : base(fsm) { }

    public override void Enter() 
    {
        
    }

    public override void Do()
    {
        // 정찰 모드로 전환(정찰할 구역을 지정하고 왔다 갔다.)
        fsm.Patrol();
        // 범위 내에 들어오면 다시 추격
    }
    
}
