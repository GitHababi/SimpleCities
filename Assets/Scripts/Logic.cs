using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public static int rangeX = 64;
    public static int rangeY = 64;
    public static int MapDimensionX = 2 * rangeX;
    public static int MapDimensionY = 2 * rangeY;
    
    public GameObject ToFlatten;

    void Update() {
    
    if (Input.GetMouseButtonDown(0)) { // this is the if statement where left clicks are detected.
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "Mountain") {
                    Instantiate(ToFlatten, hit.collider.gameObject.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                }
            }
    } 
    }
}
