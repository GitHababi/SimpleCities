using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residential : MonoBehaviour
{
       bool L = false;
        bool R = false;
        bool U = false;
        bool D = false;
        bool nextToRoad = false;
        bool roadBefore = false;
        int personalCount = 0;
        public SpriteRenderer spriteRenderer;
        public Sprite Center;
        public Sprite CornerLL;
        public Sprite CornerUL;
        public Sprite CornerUR;
        public Sprite CornerLR;
        public Sprite EdgeU;
        public Sprite EdgeL;
        public Sprite EdgeR;
        public Sprite EdgeD;
        public Sprite Solo;
        public Sprite NotConnected;

    void Start() {
        CheckNeighbors();
    }
    void Update()
    {
        if (Logic.UpdateTextures) {
            CheckNeighbors();
        }
    }
    void OnDestroy() {
        if (roadBefore) { //This line checks if there was a road before this gets destroyed, so that the number of active buildings is correct.
            Logic.residentialCount--;
        }
    }

    void CheckNeighbors() {
        if ((int)transform.position.x + Logic.rangeX + 1 < Logic.MapDimensionX && (int)transform.position.y + Logic.rangeY + 1 < Logic.MapDimensionY && -1 < (int)transform.position.x + Logic.rangeX - 1 && -1 < (int)transform.position.y + Logic.rangeY - 1) 
        {
            int Right = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY];
            int Left = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY];
            int Up = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY + 1];
            int Down = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY - 1];
            int RightUp = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY + 1];
            int RightDown = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY - 1];
            int LeftUp = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY + 1];
            int LeftDown = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY - 1];
            if (Right == 5) 
            {
            R = true;
            } 
            if (Left == 5) 
            {
            L = true;
            } 
            if (Up == 5) 
            {
            U = true;
            } 
            if (Down == 5) 
            {
            D = true;
            }
            //From here it is checking if neighbor cells are road.
            if (Right == 4) {nextToRoad = true;}
            else {if (Left == 4) {nextToRoad = true;} 
            else {if (Up == 4) {nextToRoad = true;} 
            else {if (Down == 4) {nextToRoad = true;}
            else {if (RightUp == 4) {nextToRoad = true;} 
            else {if (RightDown == 4) {nextToRoad = true; } 
            else {if (LeftUp == 4) {nextToRoad = true;} 
            else {if (LeftDown == 4) {nextToRoad = true;}
            else {nextToRoad = false;}}}}}}}}
            if (nextToRoad && !roadBefore) {
                personalCount = 1;
            }
            if (!nextToRoad && roadBefore) {
                personalCount = -1;
            }
            if (personalCount == 1) {
                Logic.residentialCount++;
                roadBefore = true;
            }
            if (personalCount == -1) {
                Logic.residentialCount--;
                roadBefore = false;
            }
            personalCount = 0;
            //Up to here.
        }
        //This section updates sprites.
        if (!roadBefore || !nextToRoad) {spriteRenderer.sprite = NotConnected;}
        else {
        if (R && U) {spriteRenderer.sprite = CornerLL;}
        else {
        if (R && D) {spriteRenderer.sprite = CornerUL;}
        else {
        if (L && U) {spriteRenderer.sprite = CornerLR;}
        else {
        if (L && D) {spriteRenderer.sprite = CornerUR;}
        else {
        if (U && D && R) {spriteRenderer.sprite = EdgeL;}
        else {
        if (U && D && L) {spriteRenderer.sprite = EdgeR;}
        else {
        if (L && R && D) {spriteRenderer.sprite = EdgeU;}
        else {
        if (L && R && U) {spriteRenderer.sprite = EdgeD;}
        else {
        if (L && R && U && D) {spriteRenderer.sprite = Center;}
        else {if (nextToRoad|| roadBefore) {spriteRenderer.sprite = Solo;}}}}}}}}}}}}
}
