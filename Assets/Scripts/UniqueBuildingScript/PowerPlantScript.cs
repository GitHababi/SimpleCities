using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantScript : MonoBehaviour
{
    bool isNextToRoad = false;
    int howMuchMountain = 0;
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
        Logic.powerCount += -(howMuchMountain * 4);
    }
    void CheckNeighbors() {
        Logic.powerCount += -(howMuchMountain * 4);
        howMuchMountain = 0;
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
            if (Right == 2 && isNextToRoad) {howMuchMountain++;}
            if (Left == 2 && isNextToRoad) {howMuchMountain++;}
            if (Up == 2 && isNextToRoad) {howMuchMountain++;}
            if (Down == 2 && isNextToRoad) {howMuchMountain++;}
            if (RightUp == 2 && isNextToRoad) {howMuchMountain++;}
            if (RightDown == 2 && isNextToRoad) {howMuchMountain++;}
            if (LeftUp == 2 && isNextToRoad) {howMuchMountain++;}
            if (LeftDown == 2 && isNextToRoad) {howMuchMountain++;}
        }
        Logic.powerCount += howMuchMountain * 4;
    }
}
