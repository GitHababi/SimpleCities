using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public static bool UpdateTextures; 
    public static int rangeX = 64;
    public static int rangeY = 64;
    public static int MapDimensionX = 2 * rangeX;
    public static int MapDimensionY = 2 * rangeY;
    public static int[,] Grid = new int[Logic.MapDimensionX,Logic.MapDimensionY];

    public static bool isTerraform = false;
    public static bool isBuildRoad = false;
    public static bool isDestroy = false;



    public GameObject FlattenTo; //Specific types of GameObjects needed
    public GameObject MapGenerator;

    public GameObject Ocean; //GameTiles are put here
    public GameObject Mountain;
    public GameObject Land;
    public GameObject Road;

    public GameObject SelectSound; //Sounds are put here
    public GameObject DigSound;
    public GameObject PlaceSound;

    void Start() {
        Select();
        Object.Instantiate(MapGenerator, new Vector3(0,0,0), Quaternion.identity);
        RefreshGrid();
        UpdateTextures = true;
    }
    void Update() {

        LeftClick();
    }

    void LeftClick() {
    if (Input.GetMouseButtonDown(0)) { // this is the if statement where left clicks are detected.
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && isTerraform) {  
                switch (hit.collider.gameObject.name) 
                {
                    case "Mountain(Clone)":
                    Dig();
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 3;
                    RefreshGrid();
                    break;

                    case "Ocean(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 2;
                    Dig();
                    RefreshGrid();
                    break;

                    case "Land(Clone)":
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeY] = 1;
                    Dig();
                    RefreshGrid();
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
                    RefreshGrid();
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
                    Dig();
                    RefreshGrid();
                    break;

                    default:
                    break;
                }
            }
        }

    }
    public void RefreshGrid() {
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
                default:
                Debug.Log("default");
                break;
                } 
            }
        }
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
}
