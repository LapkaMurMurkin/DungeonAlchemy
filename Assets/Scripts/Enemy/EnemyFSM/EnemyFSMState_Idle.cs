using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class EnemyFSMState_Idle : EnemyFSMState
{
    public EnemyFSMState_Idle(EnemyFSM FSM) : base(FSM) { }


    public override void Enter()
    {
        _FSM.Animator.Play("Idle");
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (_FSM.Road[_FSM.PositionOnRoad - 1].Player is not null)
        {
            _FSM.EnemyModel.TargetPlayer = _FSM.Road[_FSM.PositionOnRoad - 1].Player;
            _FSM.SwitchState<EnemyFSMState_Fight>();
        }
    }
}
