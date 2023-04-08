using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public ItemController<ConsumableItem> consumableItemsController;
    public ItemController<NonConsumableItem> nonconsumableItemsController;
    private void Awake()
    {
        if (inventory == null)
        {
            inventory = this;
        }
        CreateInventory();
    }

    public void CreateInventory()
    {
        consumableItemsController = new ItemController<ConsumableItem>();
        nonconsumableItemsController = new ItemController<NonConsumableItem>();

        //consumable items
        consumableItemsController.AddItem(new ConsumableItem("Heart", 10, 1));

        //nonconsumable items
        nonconsumableItemsController.AddItem(new NonConsumableItem("Coin", 1));
        nonconsumableItemsController.AddItem(new NonConsumableItem("Gem", 100));
    }

}
