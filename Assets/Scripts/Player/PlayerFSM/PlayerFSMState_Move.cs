using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Move : PlayerFSMState
{
    public PlayerFSMState_Move(PlayerFSM FSM) : base(FSM) { }

    private List<Tile> _road;
    private Tile _playerPosition;
    private Transform _playerTransform;
    private Transform _forwardTileTransform;

    public override void Enter()
    {
        _road = ServiceLocator.Get<Road>().Tiles;
        _playerPosition = _FSM.PlayerModel.PositionOnRoad;
        _playerTransform = _FSM.Player.transform;
        _forwardTileTransform = _playerPosition.NextTile.transform;
    }

    public override void Exit() { }

    public override void Update()
    {
        if (_playerPosition.NextTile.Enemy != null)
        {
            _FSM.PlayerModel.TargetEnemy = _playerPosition.NextTile.Enemy;
            _FSM.SwitchState<PlayerFSMState_Fight>();
        }

        if (_playerTransform.position.z != _forwardTileTransform.position.z)
        {
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _forwardTileTransform.position, 2 * Time.deltaTime);
        }
        else
        {
            _playerPosition.Player = null;
            _playerPosition = _playerPosition.NextTile;
            _FSM.PlayerModel.PositionOnRoad = _playerPosition;
            _playerPosition.Player = _FSM.Player;

            _forwardTileTransform = _playerPosition.NextTile.transform;
        }

        
    }
}