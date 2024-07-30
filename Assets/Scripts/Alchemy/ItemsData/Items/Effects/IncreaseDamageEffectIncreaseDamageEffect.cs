using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/IncreaseDamageEffect", fileName = "IncreaseDamageEffect")]
public class IncreaseDamageEffect : PotionEffect
{
    public int value;

    public override void Trigger(Potion.PotionCastData data)
    {
        data.Target.GetComponent<Character>().IncreaseDamageEffect(value);
    }
}
