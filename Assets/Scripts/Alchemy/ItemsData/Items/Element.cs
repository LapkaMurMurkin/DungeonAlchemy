using UnityEngine;

[CreateAssetMenu(menuName = "Game/Element", fileName = "Element")]
public class Element : AbstractItem
{
    [field:SerializeField]
    public Color Color { get; private set; }
}
