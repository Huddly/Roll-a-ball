using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	GameObject ball;
	Vector3[] positions;
	int i;

	// Use this for initialization
	void Start () {
        //Check if instance already exists
        if (instance == null)
			instance = this;
        else if (instance != this)
            Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		// setup
		ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = new Vector3(0, 0.11f, 0);
        ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

		positions = new Vector3[10000];
		positions[0].x = 0;
		positions[0].y = 0.11f;
		positions[0].z = 0;
		for (i = 1; i < positions.Length; i++) {
			positions[i].x = positions[i-1].x + Random.Range(-0.1f ,0.2f);
			positions[i].y = 0.11f;
			positions[i].z = positions[i-1].z + Random.Range(-0.1f ,0.2f);
		}
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (i < positions.Length) {
			ball.transform.position = positions[i++];
		}
	}
}
