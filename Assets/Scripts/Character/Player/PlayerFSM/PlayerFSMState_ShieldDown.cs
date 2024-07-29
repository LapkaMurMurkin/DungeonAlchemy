using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_ShieldDown : PlayerFSMState
{
    public PlayerFSMState_ShieldDown(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.AnimatorEvents.OnAnimationEnd += EndDefense;
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnAnimationEnd -= EndDefense;
    }

    private void EndDefense()
    {
        _FSM.SwitchState<PlayerFSMState_Fight>();
    }
}
