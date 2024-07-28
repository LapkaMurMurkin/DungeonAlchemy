using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class EnemyFSMState : FSMState
{
    protected EnemyFSM _FSM;

    public EnemyFSMState(EnemyFSM FSM) : base() {
        _FSM = FSM;
     }
}