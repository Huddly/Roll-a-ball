using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject
{
	protected GameObject obj;
	protected Vector3 targetPos;

	public void Update() {
		obj.transform.position = targetPos;
	}

	public void SetPosition (Vector3 target) {
		targetPos = target;
	}
}
