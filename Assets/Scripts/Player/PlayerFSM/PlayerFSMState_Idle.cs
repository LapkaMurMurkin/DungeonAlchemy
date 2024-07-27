using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Idle : PlayerFSMState
{
    public PlayerFSMState_Idle(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.Animator.Play("Idle");
        _FSM.Attack.performed += MakeDefaultAttack;
        _FSM.Defence.performed += ShieldUp;
    }

    public override void Exit()
    {
        _FSM.Attack.performed -= MakeDefaultAttack;
        _FSM.Defence.performed -= ShieldUp;
    }

    private void MakeDefaultAttack(InputAction.CallbackContext context)
    {
        _FSM.SwitchState<PlayerFSMState_DefaultAttack>();
    }

    private void ShieldUp(InputAction.CallbackContext context)
    {
        _FSM.SwitchState<PlayerFSMState_ShieldUp>();
    }

    public override void Update()
    {
        if (_FSM.Player._enemy == null)
            _FSM.SwitchState<PlayerFSMState_Move>();
    }
}
