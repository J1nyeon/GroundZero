using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public EnemyFSM fsm;
    public BaseState(EnemyFSM fsm) { this.fsm = fsm; }

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void Exit() { }

}
