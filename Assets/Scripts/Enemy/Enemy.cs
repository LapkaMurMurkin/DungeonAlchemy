using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyModel _enemyModel;
    private EnemyView _enemyView;

    public string Name => _enemyModel.Name;
    public ReadOnlyReactiveProperty<int> MaxHealth => _enemyModel.MaxHealth;
    public ReadOnlyReactiveProperty<int> CurrentHealth => _enemyModel.CurrentHealth;
    public ReadOnlyReactiveProperty<int> AttackDamage => _enemyModel.AttackDamage;
    public ReadOnlyReactiveProperty<float> AttackSpeed => _enemyModel.AttackSpeed;

    private Animator _animator;

    [SerializeField]
    private Player _player;

    private Coroutine _makeDefaultAttackRoutine;

    public void Initialize()
    {
        _enemyModel = new EnemyModel();

        _enemyModel.Name = "RandomEnemy";
        _enemyModel.MaxHealth = new ReactiveProperty<int>(100);
        _enemyModel.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);
        _enemyModel.AttackDamage = new ReactiveProperty<int>(12);
        _enemyModel.AttackSpeed = new ReactiveProperty<float>(1f);

        _enemyView = GetComponent<EnemyView>();
        _enemyView.Initialize(this);

        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play("OgreAttack");
    }

    private void SendDamage()
    {
        _player.TakeDamage(AttackDamage.CurrentValue);
    }

    public void TakeDamage(int damage)
    {
        _enemyModel.CurrentHealth.Value -= damage;
    }
}
