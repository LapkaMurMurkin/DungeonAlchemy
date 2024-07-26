using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public abstract class PlayerFSMState : FSMState
{
    protected new PlayerFSM _FSM
    {
        get => (PlayerFSM)base._FSM;
        set => base._FSM = value;
    }

    public PlayerFSMState(PlayerFSM FSM) : base(FSM) { }
}