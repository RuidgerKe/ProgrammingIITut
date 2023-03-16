using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
   
{
    public static DataPersistanceManager manager;

    private GameData gameData;
    private Filehandler datahandler;
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Debug.Log("Found more than one Data Persistance Manager in the scene. :X");
        }
    }
    private void Start()
    {
        this.datahandler = new Filehandler(Application.persistentDataPath, fileName);
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = datahandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No Data Was Found. Starting New Game.");
            NewGame();
        }
        else
        {

        }
        Debug.Log("Loaded Sscore = " + gameData.score);
    }

   public void SaveGame()
    {
        datahandler.Save(gameData);
        Debug.Log("Saved score = " + gameData.score);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
