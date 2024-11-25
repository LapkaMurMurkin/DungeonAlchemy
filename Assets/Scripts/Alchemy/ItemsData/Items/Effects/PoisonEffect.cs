using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/PoisonEffect", fileName = "PoisonEffect")]
public class PoisonEffect : PotionEffect
{
    public int value;

    public override void ApplyEffect(ReactiveProperty<int> stat)
    {
        stat.Value -= value;
    }
}
