﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public static int rangeX = 32;
    public static int rangeY = 32;
    public static int MapDimensionX = 2 * rangeX;
    public static int MapDimensionY = 2 * rangeY;
    public static int[,] Grid = new int[Logic.MapDimensionX,Logic.MapDimensionY];
    public GameObject FlattenTo;
    public GameObject MapGenerator;
    public GameObject Ocean;
    public GameObject Mountain;
    public GameObject Land;

    void Start() {
        Object.Instantiate(MapGenerator, new Vector3(0,0,0), Quaternion.identity);
        RefreshGrid();
    }
    void Update() {

        LeftClick();
    }

    void LeftClick() {
    if (Input.GetMouseButtonDown(0)) { // this is the if statement where left clicks are detected.
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.gameObject.name == "Mountain(Clone)") {
                    Grid[(int)hit.collider.gameObject.transform.position.x + rangeX, (int)hit.collider.gameObject.transform.position.y + rangeX] = 3;
                    RefreshGrid();
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

                default:
                Debug.Log("default");
                break;
                } 
            }
        }
    }
}
