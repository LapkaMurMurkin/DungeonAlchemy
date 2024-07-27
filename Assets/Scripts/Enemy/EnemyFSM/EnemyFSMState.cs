using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class EnemyFSMState : FSMState
{
    protected new EnemyFSM _FSM
    {
        get => (EnemyFSM)base._FSM;
        set => base._FSM = value;
    }

    public EnemyFSMState(EnemyFSM FSM) : base(FSM) { }
}