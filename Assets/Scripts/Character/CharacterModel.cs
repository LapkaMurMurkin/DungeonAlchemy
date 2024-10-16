using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public abstract class CharacterModel
{
    public string Name;
    public ReactiveProperty<int> MaxHealth;
    public ReactiveProperty<int> CurrentHealth;
    public ReactiveProperty<int> AttackDamage;
    public ReactiveProperty<float> AttackSpeed;

    public Tile PositionOnRoad;
    public Character TargetCharacter;
}
