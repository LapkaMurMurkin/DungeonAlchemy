using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : IFSMState
{
    protected FSM _FSM;

    public FSMState(FSM FSM)
    {
        _FSM = FSM;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
