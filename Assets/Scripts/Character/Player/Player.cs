using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using R3;
using R3.Triggers;

public class Player : Character
{
    private PlayerFSM _FSM;

    public override void Initialize()
    {
        _model = new PlayerModel();

        _model.Name = "MegaWarrior";
        _model.MaxHealth = new ReactiveProperty<int>(100);
        _model.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);
        _model.AttackDamage = new ReactiveProperty<int>(20);
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

        _FSM.SwitchState<PlayerFSMState_CheckRoad>();

        this.UpdateAsObservable().Subscribe(_ => _FSM.Update()).AddTo(this);
        this.OnDisableAsObservable().Subscribe(_ => _FSM.CurrentState.Exit()).AddTo(this);
    }
}
