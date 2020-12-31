using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Playerdata : MonoBehaviour
{
    //Save data goes here!
    public int[,] SavedGrid;
    public bool doGenerate;
    public string cityName;
    public int population;
    public int time;
    public static Playerdata instance {get; private set;}
    private void Awake() {
     if (instance != null && instance != this) {
         Destroy(gameObject);
     }
     else
         instance = this;
    DontDestroyOnLoad(gameObject);
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.dat")) 
        {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Open(Application.persistentDataPath + "/gamesave.dat", FileMode.OpenOrCreate)) {
        Playerdata_Storage data = (Playerdata_Storage)bf.Deserialize(file);

        time = data.time;
        SavedGrid = data.SavedGrid;
        doGenerate = data.doGenerate;
        StatusScript.playerMessage = "Loaded!";
        cityName = data.cityName;
        population = data.population;
        }
       
        }
    }
    public void Save() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.dat");
        
        Playerdata_Storage data = new Playerdata_Storage();
        
        data.SavedGrid = SavedGrid;
        data.doGenerate = doGenerate;
        data.cityName = cityName;
        data.population = population;
        data.time = time;

        bf.Serialize(file, data);
        file.Close();
        StatusScript.playerMessage = "Saved!";
    }
}
[Serializable]
class Playerdata_Storage 
{
    public bool doGenerate;
    public int[,] SavedGrid;
    public string cityName;
    public int population;
    public int time;
}
