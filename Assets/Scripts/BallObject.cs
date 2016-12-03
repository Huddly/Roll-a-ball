using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MovingObject
{
	public BallObject () {
		obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
	    obj.transform.position = new Vector3(0, 0.11f, 0);
    	obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		targetPos = obj.transform.position;
	}
}
