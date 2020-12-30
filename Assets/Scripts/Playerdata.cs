using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Playerdata : MonoBehaviour
{
    //Save data goes here!
    public int[,] SavedGrid;
    public bool doGenerate;
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
        Debug.Log("Load Successful!");
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Open(Application.persistentDataPath + "/gamesave.dat", FileMode.OpenOrCreate)) {
        Playerdata_Storage data = (Playerdata_Storage)bf.Deserialize(file);

        SavedGrid = data.SavedGrid;
        doGenerate = data.doGenerate;
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
        
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Save Successful!");
    }
}
[Serializable]
class Playerdata_Storage 
{
    public bool doGenerate;
    public int[,] SavedGrid;
}
