using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item", fileName = "Item")]
public class AbstractItem : ScriptableObject
{
    [field:SerializeField]
    public Sprite Sprite { get; private set; }
    [field:SerializeField]
    public string Name { get; private set; }
    [field:SerializeField, TextArea]
    public string Description { get; private set; }
    [field:SerializeField]
    public bool IsStackable { get; private set; }
}
