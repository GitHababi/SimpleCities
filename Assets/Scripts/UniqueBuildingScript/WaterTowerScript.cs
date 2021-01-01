using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTowerScript : MonoBehaviour
{
    bool isNextToRoad = false;
    void Start()
    {
        CheckNeighbors();
    }

    void Update()
    {
        if (Logic.UpdateTextures) {
            CheckNeighbors();
        }
    }
    void OnDestroy() {
    if (isNextToRoad) {
    Logic.waterCount += -(10);
    }
    }
    void CheckNeighbors() {
        if (isNextToRoad) {
        Logic.waterCount += -(10);
        }
        if ((int)transform.position.x + Logic.rangeX + 1 < Logic.MapDimensionX && (int)transform.position.y + Logic.rangeY + 1 < Logic.MapDimensionY && -1 < (int)transform.position.x + Logic.rangeX - 1 && -1 < (int)transform.position.y + Logic.rangeY - 1) {
            int Right = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY];
            int Left = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY];
            int Up = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY + 1];
            int Down = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY - 1];
            int RightUp = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY + 1];
            int RightDown = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY - 1];
            int LeftUp = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY + 1];
            int LeftDown = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY - 1];
            if (Right == 4 || Left == 4 || Up == 4 || Down == 4 || RightUp == 4 || RightDown == 4 || LeftUp == 4 || LeftDown == 4) {isNextToRoad = true;} else {isNextToRoad = false;}
        }
        if (isNextToRoad) {
        Logic.waterCount += (10);
        }
    }
}
