using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Ka-ching! You got a gem!");
            ScoreManager.scoremanager.UpdateScore(score);
            Destroy(gameObject);
            
        }
    }

}
