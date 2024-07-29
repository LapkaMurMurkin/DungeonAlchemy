using UnityEngine;

public abstract class EffectLogic : ScriptableObject
{
    public abstract void Trigger(Potion.PotionCastData data);
}


