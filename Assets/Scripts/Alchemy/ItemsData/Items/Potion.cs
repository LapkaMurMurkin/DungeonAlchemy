using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Potion", fileName = "Potion")]
public class Potion : AbstractItem
{
    [field: SerializeField]
    public List<PotionEffect> PotionEffects { get; private set; }

    public void Apply(PotionActor caster, PotionActor target)
    {
        PotionCastData data = new PotionCastData
        {
            Target = target, 
            Caster = caster
        };

        foreach (var potionEffect in PotionEffects)
        {
            potionEffect.Behaviour.Trigger(data);
        }
    }
    
    public class PotionCastData
    {
        public PotionActor Caster;
        public PotionActor Target;
    }
}