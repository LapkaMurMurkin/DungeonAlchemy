using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using R3;
using R3.Triggers;

public class Player : MonoBehaviour
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public string Name => _playerModel.Name;
    public ReadOnlyReactiveProperty<int> MaxHealth => _playerModel.MaxHealth;
    public ReadOnlyReactiveProperty<int> CurrentHealth => _playerModel.CurrentHealth;
    public ReadOnlyReactiveProperty<int> AttackDamage => _playerModel.AttackDamage;
    public ReadOnlyReactiveProperty<float> AttackSpeed => _playerModel.AttackSpeed;

    private PlayerFSM _FSM;

    public void Initialize()
    {
        _playerModel = new PlayerModel();

        _playerModel.Name = "MegaWarrior";
        _playerModel.MaxHealth = new ReactiveProperty<int>(100);
        _playerModel.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);
        _playerModel.AttackDamage = new ReactiveProperty<int>(20);
        _playerModel.AttackSpeed = new ReactiveProperty<float>(1f);
        _playerModel.PositionOnRoad = ServiceLocator.Get<Road>().Tiles.Find(tile => tile.Player == this);
        _playerModel.TargetEnemy = _playerModel.PositionOnRoad.NextTile.Enemy;

        _playerView = GetComponent<PlayerView>();
        _playerView.Initialize(this);

        _FSM = new PlayerFSM(this, _playerModel);
        _FSM.InitializeState(new PlayerFSMState_Move(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Fight(_FSM));
        _FSM.InitializeState(new PlayerFSMState_DefaultAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_ShieldUp(_FSM));
        _FSM.InitializeState(new PlayerFSMState_ShieldDown(_FSM));

        _FSM.SwitchState<PlayerFSMState_Move>();

        this.UpdateAsObservable().Subscribe(_ => _FSM.Update()).AddTo(this);
        this.OnDestroyAsObservable().Subscribe(_ => _FSM.CurrentState.Exit()).AddTo(this);
    }

    private void Update()
    {
        Debug.Log(_FSM.CurrentState);
    }

    private void SendDamage()
    {
        _playerModel.TargetEnemy.TakeDamage(AttackDamage.CurrentValue);
    }

    public void TakeDamage(int damage)
    {
        if (_FSM.CurrentState is PlayerFSMState_ShieldUp)
            return;

        _playerModel.CurrentHealth.Value -= damage;
    }
}
