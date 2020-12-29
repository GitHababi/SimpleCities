using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoadConnector : MonoBehaviour
{
        bool L = false;
        bool R = false;
        bool U = false;
        bool D = false;
        
        public SpriteRenderer spriteRenderer;
        public Sprite Intersection;
        public Sprite Road;
        public Sprite RoadD;
        public Sprite RoadL;
        public Sprite RoadLR;
        public Sprite RoadR;
        public Sprite RoadU;
        public Sprite RoadUD;
        public Sprite TIntersectionD;
        public Sprite TIntersectionL;
        public Sprite TIntersectionLD;
        public Sprite TIntersectionLU;
        public Sprite TIntersectionR;
        public Sprite TIntersectionU;
        public Sprite TIntersectionDR;
        public Sprite TIntersectionUR;
    void Start() {
     if (Logic.UpdateTextures == true) {
         InvokeRepeating("CheckNeighbors", 0f, 0.5f);
      } 
    }
    void Update()
    {
        
    }

    void CheckNeighbors() {
        if ((int)transform.position.x + Logic.rangeX + 1 < Logic.MapDimensionX && (int)transform.position.y + Logic.rangeY + 1 < Logic.MapDimensionY && -1 < (int)transform.position.x + Logic.rangeX - 1 && -1 < (int)transform.position.y + Logic.rangeY - 1) {
            int Right = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY];
            int Left = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY];
            int Up = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY + 1];
            int Down = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY - 1];
            if (Right == 4) 
            {
            R = true;
            } 
            if (Left == 4) 
            {
            L = true;
            } 
            if (Up == 4) 
            {
            U = true;
            } 
            if (Down == 4) 
            {
            D = true;
            }
        }
        if (R) {spriteRenderer.sprite = RoadR;}
        if (L) {spriteRenderer.sprite = RoadL;}
        if (U) {spriteRenderer.sprite = RoadU;}
        if (D) {spriteRenderer.sprite = RoadD;}
        if (R && L) {spriteRenderer.sprite = RoadLR;}
        if (U && D) {spriteRenderer.sprite = RoadUD;}
        if (R && U) {spriteRenderer.sprite = TIntersectionUR;}
        if (R && D) {spriteRenderer.sprite = TIntersectionDR;}
        if (L && U) {spriteRenderer.sprite = TIntersectionLU;}
        if (L && D) {spriteRenderer.sprite = TIntersectionLD;}
        if (U && D && R) {spriteRenderer.sprite = TIntersectionR;}
        if (U && D && L) {spriteRenderer.sprite = TIntersectionL;}
        if (L && R && D) {spriteRenderer.sprite = TIntersectionD;}
        if (L && R && U) {spriteRenderer.sprite = TIntersectionU;}
        if (L && R && U && D) {spriteRenderer.sprite = Intersection;}
    }
}
