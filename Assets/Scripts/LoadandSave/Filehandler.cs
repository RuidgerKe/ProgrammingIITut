using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Filehandler 

{
    private string dataDirPath = " ";

    private string dataFileName = " ";

    public Filehandler(string dataDirPath, string dataFileName) 
    { 
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
   
    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = " ";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data to file: " + fullPath + "\n" + e);
            }
           
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        //string fullPath = dataDirPath + "/" + dataFileName;
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        
        try
        {
            //create a directory that the file will be written to if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            //serialize the c# game data object into JSON

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                   
                }

            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

}
