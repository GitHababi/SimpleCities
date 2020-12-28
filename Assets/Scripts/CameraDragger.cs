using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragger : MonoBehaviour
{
	public Logic logic;
	
	private float dist;
	private Vector3 RangeVector;
	private Vector3 MouseStart;
	private Vector3 derp;
	private Vector3 distance;
    bool cameramovement;
	private float CameraX = Logic.rangeX - 4;
	private float CameraY = Logic.rangeY - 4;

    // Start is called before the first frame update
    void Start()
    {
		cameramovement = true;
		dist = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
		if (cameramovement == true) {
			if (Input.GetMouseButtonDown(1)) {
				MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
				MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
				MouseStart.z = transform.position.z;

			}
			else if (Input.GetMouseButton(1)) {
				var MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
				MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
				MouseMove.z = transform.position.z;
				transform.position = transform.position - (MouseMove - MouseStart);
			} 
		}
		if (transform.position.x <= -CameraX) { //Fuck me this code looks ugly but hey, it works. 
			RangeVector = new Vector3(-CameraX, transform.position.y, -10);
			transform.position = RangeVector;
		}
		if (transform.position.y <= -CameraY) {
			RangeVector = new Vector3(transform.position.x,-CameraY, -10);
			transform.position = RangeVector;
		}
		if (transform.position.x >= CameraX) {
			RangeVector = new Vector3(CameraX, transform.position.y, -10);
			transform.position = RangeVector;
		}
		if (transform.position.y >= CameraY) {
			RangeVector = new Vector3(transform.position.x,CameraY, -10);
			transform.position = RangeVector;
		}
    }
}
