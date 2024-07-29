using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Ingredient", fileName = "Ingredient")]
public class Ingredient : AbstractItem
{
    [field: SerializeField]
    public float AdditionalCookingTime { get; private set; }
    [field: SerializeField] 
    public List<ItemStack<Element>> Elements { get; private set; }
}
