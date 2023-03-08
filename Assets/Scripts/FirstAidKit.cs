using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private Collectible heart;
    private void Start()
    {
        heart = new Collectible("Heart", 0, 5);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            heart.UpdateHp();
            Destroy(gameObject);
        }
    }
}
