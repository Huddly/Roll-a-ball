using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position {
	public int timestamp;
	public string name;
	public Vector3 position;

	public static Position ParseLine(string line)
    {
    	char[] delimiterChars = {':'};
		Position pos = new Position();
		string[] words = line.Split(delimiterChars);
		pos.timestamp = int.Parse(words[0]);
		pos.name = string.Copy(words[1]);
		pos.position = new Vector3(float.Parse(words[2]), 0, float.Parse(words[3]));
		return pos;
    }
}

public abstract class PositionHandler {
	public abstract void UpdatePositions(MovingObject[] objects);
}
