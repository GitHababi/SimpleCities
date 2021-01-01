using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPumpScript : MonoBehaviour
{
    int howMuchOcean = 0;
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
        Logic.waterCount += -(howMuchOcean * 4);
    }
    void CheckNeighbors() {
        Logic.waterCount += -(howMuchOcean * 4);
        howMuchOcean = 0;
        if ((int)transform.position.x + Logic.rangeX + 1 < Logic.MapDimensionX && (int)transform.position.y + Logic.rangeY + 1 < Logic.MapDimensionY && -1 < (int)transform.position.x + Logic.rangeX - 1 && -1 < (int)transform.position.y + Logic.rangeY - 1) {
            int Right = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY];
            int Left = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY];
            int Up = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY + 1];
            int Down = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY - 1];
            int RightUp = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY + 1];
            int RightDown = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY - 1];
            int LeftUp = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY + 1];
            int LeftDown = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY - 1];
            if (Right == 1) {howMuchOcean++;}
            if (Left == 1) {howMuchOcean++;}
            if (Up == 1) {howMuchOcean++;}
            if (Down == 1) {howMuchOcean++;}
            if (RightUp == 1) {howMuchOcean++;}
            if (RightDown == 1) {howMuchOcean++;}
            if (LeftUp == 1) {howMuchOcean++;}
            if (LeftDown == 1) {howMuchOcean++;}
        }
        Logic.waterCount += (howMuchOcean * 4);
    }
}
