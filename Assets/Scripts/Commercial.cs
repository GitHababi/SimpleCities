using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commercial : MonoBehaviour
{
        bool L = false;
        bool R = false;
        bool U = false;
        bool D = false;
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

    void Start() {
        CheckNeighbors();
    }
    void Update()
    {
        if (Logic.UpdateTextures) {
            CheckNeighbors();
        }
    }

    void CheckNeighbors() {
        if ((int)transform.position.x + Logic.rangeX + 1 < Logic.MapDimensionX && (int)transform.position.y + Logic.rangeY + 1 < Logic.MapDimensionY && -1 < (int)transform.position.x + Logic.rangeX - 1 && -1 < (int)transform.position.y + Logic.rangeY - 1) {
            int Right = Logic.Grid[(int)transform.position.x + Logic.rangeX + 1, (int)transform.position.y + Logic.rangeY];
            int Left = Logic.Grid[(int)transform.position.x + Logic.rangeX - 1, (int)transform.position.y + Logic.rangeY];
            int Up = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY + 1];
            int Down = Logic.Grid[(int)transform.position.x + Logic.rangeX, (int)transform.position.y + Logic.rangeY - 1];
            if (Right == 6) 
            {
            R = true;
            } 
            if (Left == 6) 
            {
            L = true;
            } 
            if (Up == 6) 
            {
            U = true;
            } 
            if (Down == 6) 
            {
            D = true;
            }
        }
        if (R && U) {spriteRenderer.sprite = CornerLL;}
        if (R && D) {spriteRenderer.sprite = CornerUL;}
        if (L && U) {spriteRenderer.sprite = CornerLR;}
        if (L && D) {spriteRenderer.sprite = CornerUR;}
        if (U && D && R) {spriteRenderer.sprite = EdgeL;}
        if (U && D && L) {spriteRenderer.sprite = EdgeR;}
        if (L && R && D) {spriteRenderer.sprite = EdgeU;}
        if (L && R && U) {spriteRenderer.sprite = EdgeD;}
        if (L && R && U && D) {spriteRenderer.sprite = Center;}
    }
}
