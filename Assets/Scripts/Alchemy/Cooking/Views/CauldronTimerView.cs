using R3;
using TMPro;
using UnityEngine;

public class CauldronTimerView : MonoBehaviour
{
    public Cauldron Cauldron;
    public TMP_Text TimerTMP;
    
    private void Start()
    {
        Cauldron.TimeLeft.Subscribe(timerValue => RefreshUI(timerValue));
        RefreshUI(Cauldron.TimeLeft.CurrentValue);
    }

    private void RefreshUI(float timerValue)
    {
        TimerTMP.text = $"{Mathf.RoundToInt(timerValue)}";
    }
}
