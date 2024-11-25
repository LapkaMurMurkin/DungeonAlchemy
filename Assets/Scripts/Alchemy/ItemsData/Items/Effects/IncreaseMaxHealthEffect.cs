using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/IncreaseMaxHealthEffect", fileName = "IncreaseMaxHealthEffect")]
public class IncreaseMaxHealthEffect : PotionEffect
{
    public int value;

    public override void ApplyEffect(ReactiveProperty<int> stat)
    {
        stat.Value += value;
    }
}
