using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/Heal", fileName = "HealEffect")]
public class HealEffect : PotionEffect
{
    public int value;

    public override void Trigger(Potion.PotionCastData data)
    {
        data.Target.GetComponent<Character>().Heal(value);
    }
}
