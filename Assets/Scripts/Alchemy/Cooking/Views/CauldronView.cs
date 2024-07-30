using System;
using R3;
using TMPro;
using UnityEngine;

public class CauldronView : MonoBehaviour
{
    public Cauldron Cauldron;
    public TMP_Text TimerTMP;
    public Animator Animator;
    
    private const string Idle = "Boil";
    private const string Boiling = "Idle";
    
    private void Start()
    {
        Cauldron.TimeLeft.Subscribe(timerValue => RefreshUI(timerValue));
        RefreshUI(Cauldron.TimeLeft.CurrentValue);
    }

    private void RefreshUI(float timerValue)
    {
        TimerTMP.text = $"{Mathf.RoundToInt(timerValue)}";
    }

    private void Update()
    {
        if (Cauldron.IsCooking)
        {
            Animator.Play(Boiling);
        }
        else
        {
            Animator.Play(Idle);
        }
    }
}
