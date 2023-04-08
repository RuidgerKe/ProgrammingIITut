using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string itemName;
    
    public int itemWorth;
    protected int ownedQuantity;

    public int GetOwnedQuantity()
    {
        return ownedQuantity; 
    }

    public void PurchaseItem()
    {
        Debug.Log($"Item {itemName} is purchased with {itemWorth} price");
        ownedQuantity++;
    }

    public virtual void Use()
    {

    }

}
