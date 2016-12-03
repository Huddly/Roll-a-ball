using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PositionHandler {
	public void UpdatePositions(MovingObject[] objects) {
		foreach (MovingObject obj in objects) {
			Vector3 pos = obj.GetPosition();
			pos.x = pos.x + Random.Range(-0.1f ,0.2f);
			pos.z = pos.z + 0.5f * Random.Range(-0.1f ,0.2f);
			obj.SetPosition(pos);
		}
	}
}
