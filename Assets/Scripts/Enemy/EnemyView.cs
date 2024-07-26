using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;

using UnityEngine.UIElements.Experimental;
using TMPro;

public class EnemyView : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private Slider _healthBar;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;

        _name.text = _enemy.Name;

        _healthBar.minValue = 0;
        _enemy.MaxHealth.Subscribe(value => _healthBar.maxValue = value).AddTo(this);
        _enemy.CurrentHealth.Subscribe(value => _healthBar.value = value).AddTo(this);
    }
}
