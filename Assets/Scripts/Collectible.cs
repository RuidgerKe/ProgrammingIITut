using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string nameCollectable;

    public int score;

    public int restoreHp;

    public Collectible(string name, int scorevalue, int restoreHPvalue)
    {
        this.nameCollectable = name;
        this.score = scorevalue;
    this.restoreHp = restoreHPvalue;
    }
    public void UpdateScore()
    {
        ScoreManager.scoremanager.UpdateScore(score);
    }

    public void UpdateHp()
    {
        PlayerManager.playermanage.player.GetComponent<CharacterStats>().RestoreHealth(this.restoreHp);
    }

}
