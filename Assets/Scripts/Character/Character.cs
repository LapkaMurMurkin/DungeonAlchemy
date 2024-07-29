using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using R3;
using R3.Triggers;
using System;

[RequireComponent(typeof(AnimatorEvents))]
public abstract class Character : MonoBehaviour
{
    protected CharacterModel _model;
    protected CharacterView _view;

    public string Name => _model.Name;
    public ReadOnlyReactiveProperty<int> MaxHealth => _model.MaxHealth;
    public ReadOnlyReactiveProperty<int> CurrentHealth => _model.CurrentHealth;
    public ReadOnlyReactiveProperty<int> AttackDamage => _model.AttackDamage;
    public ReadOnlyReactiveProperty<float> AttackSpeed => _model.AttackSpeed;

    public Tile PositionOnRoad => _model.PositionOnRoad;
    public Character TargetCharacter => _model.TargetCharacter;

    public Action<int> OnDamageDealt;
    public Action<int> OnDamageReceive;
    public Action OnDeath;

    public abstract void Initialize();

    public abstract void TakeDamage(int damage);
    protected abstract void Die();

}
