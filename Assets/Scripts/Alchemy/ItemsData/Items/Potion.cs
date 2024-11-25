using System.Collections.Generic;
using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Potion", fileName = "Potion")]
public class Potion : AbstractItem
{
    public StatID StatID;
    [field: SerializeField]
    public List<PotionEffect> PotionEffects { get; private set; }

    public void Use(ReactiveProperty<int> stat)
    {
        foreach (var potionEffect in PotionEffects)
        {
            potionEffect.ApplyEffect(stat);
        }
    }
}