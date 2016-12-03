using System;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MovingObject
{
	public BallObject (String name) {
		objName = name;
		obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
	    obj.transform.position = new Vector3(0, 0.11f, 0);
    	obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		targetPos = obj.transform.position;
	}
}
