    using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    public List<ItemStack<AbstractItem>> Stacks;

    public void Add()
    {
        var inventory = GetComponent<Inventory>();
        foreach (var stack in Stacks)
        {
            inventory.Storage.AddItemQuantity(stack.Item, stack.Quantity);
        }
    }
}
