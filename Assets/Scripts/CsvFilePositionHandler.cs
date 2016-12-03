using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Position {
	public int timestamp;
	public string objectName;
	public Vector3 position;
}

public class CsvFilePositionHandler : PositionHandler {
	private List<Position> positions;

	public CsvFilePositionHandler (string filename) {
        string[] lines = System.IO.File.ReadAllLines(filename);
		positions = new List<Position>();
        foreach (string line in lines) {
            //Debug.Log(line);
            positions.Add(parseLine(line));
        }
	}

    private Position parseLine(string line)
    {
    	char[] delimiterChars = {':'};
		Position pos = new Position();
		string[] words = line.Split(delimiterChars);
		pos.timestamp = int.Parse(words[0]);
		pos.objectName = string.Copy(words[1]);
		pos.position = new Vector3(float.Parse(words[2]), 0, float.Parse(words[3]));
		return pos;
    }
	public override void UpdatePositions(MovingObject[] objects) {
		foreach (MovingObject obj in objects) {
			obj.SetPosition(getCurrent(obj.GetName()));
		}
	}

	private Vector3 getCurrent(string name) {
		int currTime = (int) (Time.time * 1000.0f);
		Position bestPos = null;

		foreach	(Position pos in positions) {
			if (pos.objectName == name && pos.timestamp <= currTime) {
				if (bestPos != null) {
					if (pos.timestamp >= bestPos.timestamp)
						bestPos = pos;
				} else {
					bestPos = pos;
				}
			}
		}
		return bestPos.position;
	}
}