using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect", fileName = "PotionEffect")]
public abstract class PotionEffect : AbstractItem
{
     public abstract void Trigger(Potion.PotionCastData data);
}
