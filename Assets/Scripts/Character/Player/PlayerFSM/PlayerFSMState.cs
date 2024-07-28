using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class PlayerFSMState : FSMState
{
    protected PlayerFSM _FSM;

    public PlayerFSMState(PlayerFSM FSM) : base()
    {
        _FSM = FSM;
    }
}