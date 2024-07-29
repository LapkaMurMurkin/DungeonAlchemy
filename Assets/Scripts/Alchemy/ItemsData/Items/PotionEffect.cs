using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionEffect", fileName = "PotionEffect")]
public class PotionEffect : AbstractItem
{
     [field:SerializeField]
     public EffectLogic Behaviour { get; private set; }
}
