using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect/IncreaseMaxHealthEffect", fileName = "IncreaseMaxHealthEffect")]
public class IncreaseMaxHealthEffect : PotionEffect
{
    public int value;

    public override void Trigger(Potion.PotionCastData data)
    {
        data.Target.GetComponent<Character>().IncreaseMaxHealthEffect(value);
    }
}
