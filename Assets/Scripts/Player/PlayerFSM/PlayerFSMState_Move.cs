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

    private Player _player;
    private List<Tile> _road;
    private Transform _playerTransform;

    public override void Enter()
    {
        _player = _FSM.Player;
        _road = _FSM.Road;
        _playerTransform = _player.transform;
    }

    public override void Exit() { }

    public override void Update()
    {
        if (_playerTransform.position.z != _road[_FSM.PlayerPosition + 1].transform.position.z)
        {
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _road[_FSM.PlayerPosition + 1].transform.position, 2 * Time.deltaTime);
        }
        else
        {
            _road[_FSM.PlayerPosition].Player = null;
            _FSM.PlayerPosition++;
            _road[_FSM.PlayerPosition].Player = _FSM.Player;

            if (_road[_FSM.PlayerPosition + 1].Enemy is not null)
                _FSM.Player._enemy = _road[_FSM.PlayerPosition + 1].Enemy;

            _FSM.SwitchState<PlayerFSMState_Idle>();
        }
    }
}