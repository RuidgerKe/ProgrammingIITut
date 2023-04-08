using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   

    //Collectible coin;
    private void Awake()
    {
        //coin = new Collectible("coin", 1, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //coin.UpdateScore();
            Inventory.inventory.nonconsumableItemsController.UseItem("Coin");
            Destroy(gameObject);

        }
    }
}
