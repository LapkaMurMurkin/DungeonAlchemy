using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using R3;
using R3.Triggers;
using System;

public class Player : Character
{
    private PlayerFSM _FSM;
    public Action OnWin;

    public PotionZoneDropReceiver EnemyZone;
    public AudioSource AttackSound;
    public AudioSource BlockSound;

    public Inventory Inventory;

    public override void Initialize()
    {
        _model = new PlayerModel();

        _model.Name = "MegaWarrior";
        _model.MaxHealth = new ReactiveProperty<int>(100);
        _model.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);
        _model.AttackDamage = new ReactiveProperty<int>(5);
        _model.AttackSpeed = new ReactiveProperty<float>(1f);
        _model.PositionOnRoad = ServiceLocator.Get<Road>().Tiles.Find(tile => tile.Character == this);
        _model.TargetCharacter = _model.PositionOnRoad.NextTile.Character;

        _view = GetComponent<PlayerView>();
        _view.Initialize(this);

        _FSM = new PlayerFSM(this, (PlayerModel)_model);
        _FSM.InitializeState(new PlayerFSMState_CheckRoad(_FSM));
        _FSM.InitializeState(new PlayerFSMState_MoveToNextTile(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Fight(_FSM));
        _FSM.InitializeState(new PlayerFSMState_DefaultAttack(_FSM));
        _FSM.InitializeState(new PlayerFSMState_ShieldUp(_FSM));
        _FSM.InitializeState(new PlayerFSMState_Defense(_FSM));
        _FSM.InitializeState(new PlayerFSMState_ShieldDown(_FSM));

        this.OnDisableAsObservable().Subscribe(_ => Disable()).AddTo(this);

        Enable();
    }

    public override void IncreaseDamageEffect(int increaseValue)
    {
        _model.AttackDamage.Value += increaseValue;
    }

    public override void IncreaseMaxHealthEffect(int increaseValue)
    {
        _model.MaxHealth.Value += increaseValue;
    }

    public override void Heal(int heal)
    {
        _model.CurrentHealth.Value += heal;

        if (CurrentHealth.CurrentValue > MaxHealth.CurrentValue)
            _model.CurrentHealth.Value = MaxHealth.CurrentValue;
    }

    private void Enable()
    {
        _model.TargetCharacter.OnDamageDealt += TakeDamage;

        _FSM.SwitchState<PlayerFSMState_CheckRoad>();
        this.UpdateAsObservable().Subscribe(_ => _FSM.Update()).AddTo(this);
    }

    private void Disable()
    {
        _model.TargetCharacter.OnDamageDealt -= TakeDamage;

        _FSM.CurrentState.Exit();
    }

    public override void TakeDamage(int damage)
    {
        _FSM.Player.OnDamageReceive?.Invoke(damage);

        if (_FSM.CurrentState is PlayerFSMState_Defense)
            return;

        _FSM.Model.CurrentHealth.Value -= damage;

        if (CurrentHealth.CurrentValue <= 0)
            Die();
    }

    protected override void Die()
    {
        _FSM.CurrentState.Exit();
        _FSM.Player.OnDeath?.Invoke();
    }
}
