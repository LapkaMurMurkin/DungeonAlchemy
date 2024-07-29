using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;
using System.Threading;
using UnityEngine.SceneManagement;

public class PlayerView : CharacterView
{
    [SerializeField]
    private TextMeshProUGUI _PlayerName;
    [SerializeField]
    private Slider _PlayerHealthBar;

    [SerializeField]
    private TextMeshProUGUI _TargetName;
    [SerializeField]
    private Slider _TargetHealthBar;

    [SerializeField]
    private GameObject DeathScreen;
    [SerializeField]
    private Button DeathRestartButton;

    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private Button WinRestartButton;

    public override void Initialize(Character player)
    {
        _character = player;

        _PlayerName.text = _character.Name;
        _PlayerHealthBar.minValue = 0;
        player.MaxHealth.Subscribe(value => _PlayerHealthBar.maxValue = value).AddTo(this);
        player.CurrentHealth.Subscribe(value => _PlayerHealthBar.value = value).AddTo(this);

        Observable.EveryValueChanged(player, player => player.TargetCharacter).Subscribe(target =>
        {
            if (target != null)
            {
                SubscribeToTarget(target);
                ShowTargetStats();
                player.TargetCharacter.OnDeath += HideTargetStats;
            }
        }).AddTo(this);

        DeathRestartButton.onClick.AddListener(() => SceneManager.LoadScene(Scenes.GAMEPLAY));
        player.OnDeath += ShowDeathScreen;

        WinRestartButton.onClick.AddListener(() => SceneManager.LoadScene(Scenes.GAMEPLAY));
        (_character as Player).OnWin += ShowWinScreen;
    }

    private void SubscribeToTarget(Character target)
    {
        _TargetName.text = target.Name;
        _TargetHealthBar.minValue = 0;
        target.MaxHealth.Subscribe(value => _TargetHealthBar.maxValue = value).AddTo(target);
        target.CurrentHealth.Subscribe(value => _TargetHealthBar.value = value).AddTo(target);
    }

    private void ShowTargetStats()
    {
        _TargetName.gameObject.SetActive(true);
        _TargetHealthBar.gameObject.SetActive(true);
        _TargetName.transform.parent.gameObject.SetActive(true);
    }

    private void HideTargetStats()
    {
        _character.TargetCharacter.OnDeath -= HideTargetStats;
        _TargetName.gameObject.SetActive(false);
        _TargetHealthBar.gameObject.SetActive(false);
        _TargetName.transform.parent.gameObject.SetActive(false);
    }

    private void ShowDeathScreen()
    {
        _character.OnDeath -= ShowDeathScreen;
        DeathScreen.SetActive(true);
    }

    private void ShowWinScreen()
    {
        (_character as Player).OnWin -= ShowWinScreen;
        WinScreen.SetActive(true);
    }
}
