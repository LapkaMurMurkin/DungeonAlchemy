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

    public void Initialize()
    {
        _enemyModel = new EnemyModel();

        _enemyModel.Name = "RandomEnemy";
        _enemyModel.MaxHealth = new ReactiveProperty<int>(100);
        _enemyModel.CurrentHealth = new ReactiveProperty<int>(MaxHealth.CurrentValue);;

        _enemyView = GetComponent<EnemyView>();
        _enemyView.Initialize(this);
    }

    public void ReceiveDamage(int damage)
    {
        _enemyModel.CurrentHealth.Value -= damage;
    }
}
