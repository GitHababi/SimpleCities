using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTurbineScript : MonoBehaviour
{
    int howMuchLand = 0 ;
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
    if (howMuchLand == 8) {
            Logic.powerCount += -10;
        } 
    }
    void CheckNeighbors() {
        if (howMuchLand == 8) {
            Logic.powerCount += -10;
        } 
        howMuchLand = 0;
        if ((int)transform.position.x + Logic.rangeX + 1 < Logic.MapDimensionX && (int)transform.position.y + Logic.rangeY + 1 < Logic.MapDimensionY && -1 < (int)transform.position.x + Logic.rangeX - 1 && -1 < (int)transform.position.y + Logic.rangeY - 1) {
            int Right = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY];
            int Left = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY];
            int Up = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY + 1];
            int Down = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY - 1];
            int RightUp = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY + 1];
            int RightDown = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY - 1];
            int LeftUp = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY + 1];
            int LeftDown = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY - 1];
            if (Right == 3) {howMuchLand++;}
            if (Left == 3) {howMuchLand++;}
            if (Up == 3) {howMuchLand++;}
            if (Down == 3) {howMuchLand++;}
            if (RightUp == 3) {howMuchLand++;}
            if (RightDown == 3) {howMuchLand++;}
            if (LeftUp == 3) {howMuchLand++;}
            if (LeftDown == 3) {howMuchLand++;}
        }
        if (howMuchLand == 8) {
            Logic.powerCount += 10;
        } 
    }
}
