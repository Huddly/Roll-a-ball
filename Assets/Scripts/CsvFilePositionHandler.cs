using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class CsvFilePositionHandler : PositionHandler {
	private Dictionary<string, List<Position>> posDict;

	public CsvFilePositionHandler (string filename) {
		posDict = new Dictionary<string, List<Position>>();

        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines) {
            //Debug.Log(line);
			addPosition(Position.ParseLine(line));
        }
	}

	private void addPosition(Position pos)
	{
		if (!posDict.ContainsKey(pos.name)) {
			posDict.Add(pos.name, new List<Position>());
		}

		posDict[pos.name].Add(pos);
	}

	public override void UpdatePositions(MovingObject[] objects) {
		foreach (MovingObject obj in objects) {
			obj.SetPosition(getCurrent(obj.GetName()));
		}
	}

	private Vector3 getCurrent(string name) {
		int currTime = (int) (Time.time * 1000.0f);
		Position bestPos = null;

		if (!posDict.ContainsKey(name))
			return new Vector3();
		
		foreach	(Position pos in posDict[name]) {
			if (pos.timestamp <= currTime) {
				if (bestPos != null && pos.timestamp >= bestPos.timestamp) {
					bestPos = pos;
				} else {
					bestPos = pos;
				}
			}
		}

		if (bestPos == null)
			return new Vector3();
		return bestPos.position;
	}
}