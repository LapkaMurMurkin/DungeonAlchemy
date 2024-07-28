using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_CheckRoad : PlayerFSMState
{
    public PlayerFSMState_CheckRoad(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        Tile playerPosition = _FSM.Model.PositionOnRoad;

        if (playerPosition.NextTile.Character is Enemy)
        {
            _FSM.Model.TargetCharacter = playerPosition.NextTile.Character;
            _FSM.SwitchState<PlayerFSMState_Fight>();
        }
        else
            _FSM.SwitchState<PlayerFSMState_MoveToNextTile>();
    }
}