using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_ShieldUp : PlayerFSMState
{
    public PlayerFSMState_ShieldUp(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.AnimatorEvents.OnShieldUp += StartDefense;
        _FSM.Animator.SetTrigger("ShieldUp");
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnShieldUp -= StartDefense;
    }

    private void StartDefense()
    {
        _FSM.SwitchState<PlayerFSMState_Defense>();
    }
}
