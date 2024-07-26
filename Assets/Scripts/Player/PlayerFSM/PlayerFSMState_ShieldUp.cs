using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_ShieldUp : PlayerFSMState
{
    public PlayerFSMState_ShieldUp(PlayerFSM FSM) : base(FSM) { }

    private float _timer;

    public override void Enter()
    {
        _timer = 0.5f;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _FSM.Animator.Play("ShieldDown");
            _FSM.SwitchState<PlayerFSMState_ShieldDown>();
        }
    }
}
