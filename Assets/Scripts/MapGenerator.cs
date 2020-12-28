using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{   
      public GameObject Land;
      public GameObject Ocean;
      public GameObject Mountain;
     
     public void Start() {
         GenerateMap();
     }
     
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float heightScale, int seed) {
      
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
      
        float[,] noiseMap = GenerateNoiseMap(Logic.MapDimensionX, Logic.MapDimensionY, 13, 2012948);
        int OceanC = 0;
        int LandC = 0;
        int MountainC = 0;
        for (int x = 0; x < Logic.MapDimensionX; x++) {
      
            for (int y = 0; y < Logic.MapDimensionY; y++) {
                if (noiseMap[x,y] < 0.53333f) {
                    Object.Instantiate(Ocean, new Vector3(x - Logic.rangeX, y - Logic.rangeY, 0), Quaternion.identity);
                    OceanC++;
                } else {
                if (noiseMap[x,y] > 0.93333f) {
                    Object.Instantiate(Mountain, new Vector3(x - Logic.rangeX, y - Logic.rangeY, 0), Quaternion.identity);
                    MountainC++;
                } else {
                    Object.Instantiate(Land, new Vector3(x - Logic.rangeX, y - Logic.rangeY, 0), Quaternion.identity);
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
