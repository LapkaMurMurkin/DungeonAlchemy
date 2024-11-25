using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/Heal", fileName = "HealEffect")]
public class HealEffect : PotionEffect
{
    public int value;

    public override void ApplyEffect(ReactiveProperty<int> stat)
    {
        stat.Value += value;

        //data.Target.GetComponent<Character>().Heal(value);
    }
}
