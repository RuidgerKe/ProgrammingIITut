using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playermanage;

    public GameObject player;

     
    private void Awake()
    {
        if (playermanage == null)
        {
            playermanage = this;
        }
    }
}
