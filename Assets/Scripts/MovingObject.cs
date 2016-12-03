using System;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject
{
	private GameObject obj;
	private Vector3 targetPos;

	public MovingObject () {
		obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
	    obj.transform.position = new Vector3(0, 0.11f, 0);
    	obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		targetPos = obj.transform.position;
	}

	public void Update() {
		obj.transform.position = targetPos;
	}

	public void SetPosition (Vector3 target) {
		targetPos = target;
	}
}
