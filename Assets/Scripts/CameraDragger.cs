﻿using System;
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

    // Start is called before the first frame update
    void Start()
    {
		dist = transform.position.z;
		Debug.Log("Cumslut");
    }

    // Update is called once per frame
    void Update()
    {
		
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
		if (Math.Abs(transform.position.x) >= Logic.rangeX || Math.Abs(transform.position.y) >= Logic.rangeY) {
			RangeVector = new Vector3(Logic.rangeX, Logic.rangeY, 0);
			transform.position = RangeVector;
		}
    }
}
