using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public LevelSelectorEnum difficultySelector;
    Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate {LoadDifficultyScene(difficultySelector);});
    }

    public enum LevelSelectorEnum
    {
        Easy = 1,
        Normal = 2,
        Hard = 3
            //int starts from 0 to 2
    }

    public void LoadDifficultyScene(LevelSelectorEnum difficulty)
    {
        SceneManager.LoadScene((int)difficulty);
    }

}
