using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{   
     
     public void Awake() {
         GenerateMap();
     }
     
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float heightScale, long seed) {
      
       float[,] noiseMap = new float[mapWidth,mapHeight];
      if (heightScale <= 0) {
          heightScale = 0.0001f;
      }
      
       for (int y = 0; y < mapHeight; y++) {
      
           for (int x = 0; x < mapWidth; x++) {
            float noiseHeight = 0;
            float amp = 1;
               for (int i = 0; i < 16; i++) {
               float XFloat = x / heightScale + seed;
               float YFloat = y / heightScale + seed;
               float perlinVal = Mathf.PerlinNoise(XFloat,YFloat);
               noiseHeight += perlinVal * amp;
               amp *= 0.5f;

               }
           noiseMap [x , y] = noiseHeight;
           }
       }
       return noiseMap;
   }

    public void GenerateMap() {
      
        long Seed = (long)Mathf.Floor(Random.Range(0f, 10f) * 2000);
        Debug.Log("World Seed: " + Seed);
        float[,] noiseMap = GenerateNoiseMap(Logic.MapDimensionX, Logic.MapDimensionY, 13, Seed);
        int OceanC = 0;
        int LandC = 0;
        int MountainC = 0;
        for (int x = 0; x < Logic.MapDimensionX; x++) {
      
            for (int y = 0; y < Logic.MapDimensionY; y++) {
                if (noiseMap[x,y] < 0.73333f) {
                    Logic.Grid[x,y] = 1;
                    OceanC++;
                } else {
                if (noiseMap[x,y] > 1.23333f) {
                    Logic.Grid[x,y] = 2;
                    MountainC++;
                } else {
                    Logic.Grid[x,y] = 3;
                    LandC++;
                }
                }
            }
        }
        Debug.Log("Ocean Count: " + OceanC);
        Debug.Log("Land Count: " + LandC);
        Debug.Log("Mountain Count: " + MountainC);
    }
}
