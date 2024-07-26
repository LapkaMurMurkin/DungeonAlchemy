using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class EnemyModel
{
    public string Name;
    public ReactiveProperty<int> MaxHealth;
    public ReactiveProperty<int> CurrentHealth;
}
