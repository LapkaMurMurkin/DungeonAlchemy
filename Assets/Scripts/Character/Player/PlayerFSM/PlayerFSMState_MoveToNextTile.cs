using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_MoveToNextTile : PlayerFSMState
{
    public PlayerFSMState_MoveToNextTile(PlayerFSM FSM) : base(FSM) { }

    private Tile _currentTile;
    private Transform _playerTransform;
    private Transform _forwardTileTransform;

    public override void Enter()
    {
        _currentTile = _FSM.Model.PositionOnRoad;
        _playerTransform = _FSM.Player.transform;
        _forwardTileTransform = _currentTile.NextTile.transform;
    }

    public override void Update()
    {
        if (_playerTransform.position.z != _forwardTileTransform.position.z)
        {
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _forwardTileTransform.position, 2 * Time.deltaTime);
        }
        else
        {
            _currentTile.Character = null;
            _currentTile = _currentTile.NextTile;
            _currentTile.Character = _FSM.Player;
            _FSM.Model.PositionOnRoad = _currentTile;

            _FSM.SwitchState<PlayerFSMState_CheckRoad>();
        }
    }
}