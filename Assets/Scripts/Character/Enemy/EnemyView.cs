using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;

using UnityEngine.UIElements.Experimental;
using TMPro;

public class EnemyView : CharacterView
{
    /*     [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private Slider _healthBar;

        public override void Initialize(Character enemy)
        {
            _character = enemy;

            _name.text = _character.Name;

            _healthBar.minValue = 0;
            _character.MaxHealth.Subscribe(value => _healthBar.maxValue = value).AddTo(this);
            _character.CurrentHealth.Subscribe(value => _healthBar.value = value).AddTo(this);
        }

        public void Hide()
        {
            _healthBar.gameObject.SetActive(false);
            _name.gameObject.SetActive(false);
        }

        public void Show()
        {
            _healthBar.gameObject.SetActive(true);
            _name.gameObject.SetActive(true);
        } */
    public override void Initialize(Character enemy)
    {
        _character = enemy;
    }
}
