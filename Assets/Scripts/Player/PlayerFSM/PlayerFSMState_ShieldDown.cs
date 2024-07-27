using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_ShieldDown : PlayerFSMState
{
    public PlayerFSMState_ShieldDown(PlayerFSM FSM) : base(FSM) { }

    private float _timer;

    public override void Enter()
    {
        _FSM.Animator.Play("ShieldDown");
        _timer = _FSM.ShieldDownTime;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _FSM.SwitchState<PlayerFSMState_Idle>();
        }
    }
}
