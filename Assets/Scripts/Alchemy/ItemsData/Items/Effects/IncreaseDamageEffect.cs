using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/IncreaseDamageEffect", fileName = "IncreaseDamageEffect")]
public class IncreaseDamageEffect : PotionEffect
{
    public int value;

    public override void ApplyEffect(ReactiveProperty<int> stat)
    {
        stat.Value += value;
    }
}
