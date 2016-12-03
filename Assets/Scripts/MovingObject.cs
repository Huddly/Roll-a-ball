using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject
{
	protected GameObject obj;
	protected String objName;
	protected Vector3 targetPos;

	public MovingObject() {
		objName = "unset";
	}

	public void Update() {
		obj.transform.position = targetPos;
	}

	public String GetName() {
		return objName;
	}

	public Vector3 GetPosition() {
		return obj.transform.position;
	}
	public void SetPosition(Vector3 target) {
		targetPos = target;
	}
}
