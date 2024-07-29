using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/AlchemyData", fileName = "AlchemyData")]
public class AlchemyData : ScriptableObject
{
    [field:SerializeField]
    public List<Element> Elements { get; private set; }
    [field:SerializeField]
    public List<PotionFormula> PotionFormulas { get; private set; }
}
