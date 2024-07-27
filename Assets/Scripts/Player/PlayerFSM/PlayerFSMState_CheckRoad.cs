using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_CheckRoad : PlayerFSMState
{
    public PlayerFSMState_CheckRoad(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        if (_FSM.Road[_FSM.PlayerPosition + 1].Enemy is null)
            _FSM.SwitchState<PlayerFSMState_Move>();
        else
        {
            _FSM.Player._enemy = _FSM.Road[_FSM.PlayerPosition + 1].Enemy;
            _FSM.SwitchState<PlayerFSMState_Idle>();
        }
    }

    public override void Exit() { }

    public override void Update() { }
}
