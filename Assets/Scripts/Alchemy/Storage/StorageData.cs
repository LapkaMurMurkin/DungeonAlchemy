using System;
using UnityEngine;

[Serializable]
public class StorageData
{
    [field:SerializeField]
    public bool ItemQuantityCanBeZero { get; private set; }
    [field:SerializeField]
    public bool CreateSlotForEachItem { get; private set; }
    [field:SerializeField]
    public bool DestroySlotAfterNoItems { get; private set; }
    [field:SerializeField]
    public uint InitialSlots { get; private set; }
}
