using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_DefaultAttack : PlayerFSMState
{
    public PlayerFSMState_DefaultAttack(PlayerFSM FSM) : base(FSM) { }

    private float _timer;

    public override void Enter()
    {
        _FSM.Animator.SetTrigger("Attack");
        _timer = _FSM.AttackTime;
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
