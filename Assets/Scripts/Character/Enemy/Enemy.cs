using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public class Enemy : Character
{
    public string InitializeName;
    public int InitializeHealth;
    public int InitializeDamage;

    public AudioSource AudioSource;

    private EnemyFSM _FSM;

    public override void Initialize()
    {
        _model = new EnemyModel();

        _model.Name = InitializeName;
        _model.MaxHealth = new ReactiveProperty<int>(InitializeHealth);
        _model.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);
        _model.AttackDamage = new ReactiveProperty<int>(InitializeDamage);
        _model.AttackSpeed = new ReactiveProperty<float>(1f);

        _view = GetComponent<EnemyView>();
        _view.Initialize(this);

        _FSM = new EnemyFSM(this, _model as EnemyModel, _view as EnemyView);
        _FSM.InitializeState(new EnemyFSMState_Idle(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Fight(_FSM));

        _FSM.SwitchState<EnemyFSMState_Idle>();

        _FSM.AnimatorEvents.OnDamage += () => AudioSource.Play();

        this.UpdateAsObservable().Subscribe(_ => _FSM.Update()).AddTo(this);
        this.OnDisableAsObservable().Subscribe(_ => _FSM.CurrentState.Exit()).AddTo(this);
    }

    public override void TakeDamage(int damage)
    {
        _FSM.Model.CurrentHealth.Value -= damage;

        if (CurrentHealth.CurrentValue <= 0)
            Die();
    }

    protected override void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
