using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Just going to be honest, this is probably the worst code I have ever seen or written myself, please dont kill me gods of C#
public class Logic : MonoBehaviour 
{
    public static bool UpdateTextures = false; 
    
    public static string cityName;
    public static int population;
    public static int residentialCount;
    public static int commercialCount;
    public static int industrialCount;
    public static int waterCount;
    public static int powerCount;
    public static int time;
    public static int Cash = 10000;
    
    public static int rangeX = 64;
    public static int rangeY = 64;
    public static int MapDimensionX = 2 * rangeX;
    public static int MapDimensionY = 2 * rangeY;
    public static int[,] Grid = new int[Logic.MapDimensionX,Logic.MapDimensionY];

    public static bool isTerraform = false;
    public static bool isBuildRoad = false;
    public static bool isDestroy = false;
    public static bool isOnGUI = false;
    public static bool isBuildResidential = false;
    public static bool isBuildCommercial = false;
    public static bool isBuildIndustrial = false;
    public static bool isBuildPump = false;
    public static bool isBuildTurbine = false;
    public static bool isBuildTower = false;
    public static bool isBuildPlant = false;
    public static int  gameExit = 0;

    public static bool doSave = false;
    public static bool doLoad = false;
    public static bool doGenerate = true;

    public GameObject FlattenTo; //Specific types of GameObjects needed
    public GameObject MapGenerator;

    public GameObject Ocean; //GameTiles are put here
    public GameObject Mountain;
    public GameObject Land;
    public GameObject Road;
    public GameObject Residential;
    public GameObject Commercial;
    public GameObject Industrial;
    public GameObject Pump;
    public GameObject Tower;
    public GameObject Plant;
    public GameObject Turbine;

    public GameObject SelectSound; //Sounds are put here
    public GameObject DigSound;
    public GameObject PlaceSound;
    public GameObject SaveSound;
    public GameObject LoadSound;

    void Start() {
        Select();
        if (doGenerate) {
        Object.Instantiate(MapGenerator, new Vector3(0,0,0), Quaternion.identity);
        doGenerate = false;
        Playerdata.instance.doGenerate = doGenerate;
        Playerdata.instance.SavedGrid = Grid;
        Playerdata.instance.Cash = Cash;
        } else {
           LoadLogic();
        }
        RebuildGrid();
        InvokeRepeating("GameTick", 0f, 3f);
    }
    void GameTick() {
        time++;
        if (waterCount - residentialCount >= 0 && powerCount - residentialCount >= 0) {
            if (residentialCount >= industrialCount + commercialCount) {
            Cash += residentialCount * 100;
            } else {
                Cash += residentialCount * 50;  
            }
        }
        if (waterCount - residentialCount - industrialCount >= 0 && powerCount - residentialCount - industrialCount >= 0 && residentialCount >= industrialCount + commercialCount) {
        Cash += industrialCount * 100;
        }
        if (waterCount - residentialCount - industrialCount - commercialCount >= 0 && powerCount - residentialCount - industrialCount - commercialCount >= 0 && residentialCount >= industrialCount + commercialCount) {
        Cash += commercialCount * 100;
        }
        Cash -= 25 * waterCount;
        Cash -= 25 * powerCount;
        int expenses = 25 * powerCount + 25 * waterCount;
        Debug.Log("Daily Expenses: " + expenses);
    }
    void Update() {
        if (Input.GetKey(KeyCode.L)) {
            Cash += 2000;
        }
        if (Input.GetKey(KeyCode.K)) {
            Cash += -2000;
        }
        if (Cash <= -50000) {
            StatusScript.playerMessage = "Uh oh!\nIt appears you are in too much debt\nThe banks have come to collect their money\nand they will take your city with them!";
            Invoke("ClearMessage", 5f);
        }
        if (doSave) {
            doSave = false;
            Invoke("SaveLogic", 1.0f);
            StatusScript.playerMessage = "";
        }
        if (doLoad) {
            doLoad = false;
            Invoke("LoadLogic", 1.0f);
            StatusScript.playerMessage = "";
        }
        if (gameExit == 1) {
            Invoke("ResetExit", 7f);
            Invoke("ClearMessage", 7f);
        }
        StatusScript.residentialCount = "residential:" + residentialCount;
        StatusScript.commercialCount = "commercial:" + commercialCount;
        StatusScript.industrialCount = "industrial:" + industrialCount;
        StatusScript.timeMessage = "Day Number: " + time;
        StatusScript.moneyMessage = "$ " + Cash;
        UpdateTextures = false;
        LeftClick();
    }
    void ResetExit() {
        gameExit = 0;
    }
    void LeftClick() {
    if (Input.GetMouseButtonDown(0) && !isOnGUI) { // this is the if statement where left clicks are detected.

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && isTerraform) {  
                switch (hit.collider.gameObject.name) 
                {
                    case "Mountain(Clone)":
                    Dig();
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 500;
                    break;

                    case "Ocean(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 2;
                    Dig();
                    Object.Instantiate(Mountain, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 500;
                    break;

                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 1;
                    Dig();
                    Object.Instantiate(Ocean, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 500;
                    break;

                    default:
                    break;
                }
            }
            if (hit.collider != null && isBuildTower) {
               switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 8;
                    Place();
                    Object.Instantiate(Tower, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 1500;
                    break;

                    default:
                    break;
                } 
            }
            if (hit.collider != null && isBuildPump) {
               switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 9;
                    Place();
                    Object.Instantiate(Pump, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 4800;
                    break;

                    default:
                    break;
                } 
            }
            if (hit.collider != null && isBuildTurbine) {
               switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 10;
                    Place();
                    Object.Instantiate(Turbine, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 1500;
                    break;

                    default:
                    break;
                } 
            }
            if (hit.collider != null && isBuildPlant) {
               switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 11;
                    Place();
                    Object.Instantiate(Plant, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 4800;
                    break;

                    default:
                    break;
                } 
            }
            if (hit.collider != null && isBuildResidential) {
               switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 5;
                    Place();
                    Object.Instantiate(Residential, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    break;

                    default:
                    break;
                } 
            }
            if (hit.collider != null && isBuildRoad) {
                switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 4;
                    Place();
                    Object.Instantiate(Road, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    Cash -= 500;
                    break;

                    default:
                    break;
                }
            }
            if (hit.collider != null && isBuildCommercial) {
                switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 6;
                    Place();
                    Object.Instantiate(Commercial, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    break;

                    default:
                    break;
                }
            }
            if (hit.collider != null && isDestroy) {
                switch (hit.collider.gameObject.name)
                {
                    case "Road(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Cash += 250;
                    Dig();
                    break;

                    case "Residential(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Dig();
                    break;

                    case "Commercial(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Dig();
                    break;

                    case "Industrial(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Dig();
                    break;

                    case "PowerPlant(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Cash += 2400;
                    Dig();
                    break;

                    case "PowerTurbine(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Cash += 750;
                    Dig();
                    break;

                    case "WaterTower(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Cash += 750;
                    Dig();
                    break;

                    case "WaterPump(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    Object.Instantiate(Land, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    UpdateTextures = true;
                    Cash += 2400;
                    Dig();
                    break;

                    default:
                    break;
                }
            }
            if (hit.collider != null && isBuildIndustrial) {
                switch (hit.collider.gameObject.name)
                {
                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 7;
                    Place();
                    Object.Instantiate(Industrial, new Vector3(hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y, 0), Quaternion.identity);
                    UpdateTextures = true;
                    Destroy(hit.collider.gameObject);
                    break;

                    default:
                    break;
                }
            }
        }

    }
    public void RebuildGrid() {
       /*  residentialCount = 0;
        industrialCount = 0;
        commercialCount = 0; */
        GameObject[] GameTiles = GameObject.FindGameObjectsWithTag("GameTile"); 
        foreach(GameObject GameTile in GameTiles)  
        {
        GameObject.Destroy(GameTile);
        }
        for (int x = 0; x < Logic.MapDimensionX; x++) {
            for (int y = 0; y < Logic.MapDimensionY; y++) {
                    switch (Grid[x,y])
                    {
                        case 1:
                        Object.Instantiate(Ocean, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;
                        
                        case 2:
                        Object.Instantiate(Mountain, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 3:
                        Object.Instantiate(Land, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 4:
                        Object.Instantiate(Road, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 5:
                        Object.Instantiate(Residential, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 6:
                        Object.Instantiate(Commercial, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 7:
                        Object.Instantiate(Industrial, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 8:
                        Object.Instantiate(Tower, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 9:
                        Object.Instantiate(Pump, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 10:
                        Object.Instantiate(Turbine, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        case 11:
                        Object.Instantiate(Plant, new Vector3(x -rangeX, y -rangeY, 0), Quaternion.identity);
                        break;

                        default:
                        Debug.Log("default");
                        break;
                    } 
            }
        }
        UpdateTextures = true;
    }
    void SaveLogic() {
        SaveS();
        Playerdata.instance.SavedGrid = Grid;
        Playerdata.instance.doGenerate = doGenerate;
        Playerdata.instance.time = time;
        Playerdata.instance.Cash = Cash;
        Playerdata.instance.Save();
        Invoke("ClearMessage", 1f);
    }
    void LoadLogic() {
        LoadS();
        try {Playerdata.instance.Load();}
        catch {Object.Instantiate(MapGenerator, new Vector3(0,0,0), Quaternion.identity);}
        Grid = Playerdata.instance.SavedGrid;
        doGenerate = Playerdata.instance.doGenerate;
        time = Playerdata.instance.time;
        Cash = Playerdata.instance.Cash;
        RebuildGrid();
        Invoke("ClearMessage", 1f);
    }
    public void Dig() {
        Object.Instantiate(DigSound, new Vector3(0,0,0), Quaternion.identity);
    }
    public void Select() {
        Object.Instantiate(SelectSound, new Vector3(0,0,0), Quaternion.identity); 
    }
    public void Place() {
        Object.Instantiate(PlaceSound, new Vector3(0,0,0), Quaternion.identity); 
    }
    public void LoadS() {
        Object.Instantiate(LoadSound, new Vector3(0,0,0), Quaternion.identity); 
    }
    public void SaveS() {
        Object.Instantiate(SaveSound, new Vector3(0,0,0), Quaternion.identity); 
    }
    void ClearMessage() {
        StatusScript.playerMessage = "";
    }
}
