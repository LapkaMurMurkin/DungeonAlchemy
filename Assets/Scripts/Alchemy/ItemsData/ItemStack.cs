using System;

[Serializable]
public class ItemStack<T> where T : AbstractItem
{
    public T Item;
    public int Quantity;
}
