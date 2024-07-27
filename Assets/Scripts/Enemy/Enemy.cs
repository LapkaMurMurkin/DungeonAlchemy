using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyModel _enemyModel;
    private EnemyView _enemyView;

    public string InitializeName;
    public string Name => _enemyModel.Name;
    public ReadOnlyReactiveProperty<int> MaxHealth => _enemyModel.MaxHealth;
    public ReadOnlyReactiveProperty<int> CurrentHealth => _enemyModel.CurrentHealth;
    public ReadOnlyReactiveProperty<int> AttackDamage => _enemyModel.AttackDamage;
    public ReadOnlyReactiveProperty<float> AttackSpeed => _enemyModel.AttackSpeed;

    private EnemyFSM _FSM;

    public void Initialize()
    {
        _enemyModel = new EnemyModel();

        _enemyModel.Name = InitializeName;
        _enemyModel.MaxHealth = new ReactiveProperty<int>(100);
        _enemyModel.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);
        _enemyModel.AttackDamage = new ReactiveProperty<int>(12);
        _enemyModel.AttackSpeed = new ReactiveProperty<float>(1f);

        _enemyView = GetComponent<EnemyView>();
        _enemyView.Initialize(this);

        _FSM = new EnemyFSM(this, _enemyModel, _enemyView);
        _FSM.InitializeState(new EnemyFSMState_Idle(_FSM));
        _FSM.InitializeState(new EnemyFSMState_Fight(_FSM));

        _FSM.SwitchState<EnemyFSMState_Idle>();

        this.UpdateAsObservable().Subscribe(_ => _FSM.Update()).AddTo(this);
        this.OnDestroyAsObservable().Subscribe(_ => _FSM.CurrentState.Exit()).AddTo(this);
    }

    private void SendDamage()
    {
        _enemyModel.TargetPlayer.TakeDamage(AttackDamage.CurrentValue);
    }

    public void TakeDamage(int damage)
    {
        _enemyModel.CurrentHealth.Value -= damage;

        if (CurrentHealth.CurrentValue <= 0)
        {
            _enemyView.Hide();
            Destroy(this.gameObject);
        }
    }
}
