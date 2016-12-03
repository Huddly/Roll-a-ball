using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MovingObject
{
	public PlayerObject(String name) {
		objName = name;
		obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		if (objName == "player1")
		    obj.transform.position = new Vector3(15.0f, 1.0f, 2.5f);
		else
			obj.transform.position = new Vector3(17.0f, 1.0f, 26.0f);
    	obj.transform.localScale = new Vector3(0.2f, 2.0f, 0.2f);
		targetPos = obj.transform.position;
	}
}
