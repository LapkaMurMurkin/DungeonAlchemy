using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/PotionFormula", fileName = "PotionFormula")]
public class PotionFormula : AbstractItem
{
    [field: SerializeField]
    public List<ItemStack<Element>> ElementsForCooking { get; private set; }
    [field: SerializeField]
    public Potion Potion { get; private set; }
}