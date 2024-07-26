using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class PlayerView : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private TextMeshProUGUI _name;

    [SerializeField]
    private Slider _healthBar;

    public void Initialize(Player player)
    {
        _player = player;

        _name.text = _player.Name;

        _healthBar.minValue = 0;
        _player.MaxHealth.Subscribe(value => _healthBar.maxValue = value).AddTo(this);
        _player.CurrentHealth.Subscribe(value => _healthBar.value = value).AddTo(this);
    }
}
