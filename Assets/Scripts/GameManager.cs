using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	MovingObject[] objects;
	PositionHandler positionHandler;

	// Use this for initialization
	void Start () {
        //Check if instance already exists
        if (instance == null)
			instance = this;
        else if (instance != this)
            Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		positionHandler = new NetworkPositionHandler();

		NetworkServer posServer = new NetworkServer((NetworkPositionHandler) positionHandler);
		posServer.Start ();

		//positionHandler = new RandomPositionHandler();
		//positionHandler = new CsvFilePositionHandler("positions.csv");
		SetupObjects();
	}

	// Update is called once per frame
	void Update () {
		positionHandler.UpdatePositions(objects);
		
		foreach (MovingObject obj in objects) {
			obj.Update();
		}
	}

	void SetupObjects() {
		objects = new MovingObject[3];
		objects[0] = new BallObject("ball1");
		objects[1] = new PlayerObject("player1");
		objects[2] = new PlayerObject("player2");
	}
}
