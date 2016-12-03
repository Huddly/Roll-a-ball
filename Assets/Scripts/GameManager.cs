using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	// Use this for initialization
	void Start () {
        //Check if instance already exists
        if (instance == null)
			instance = this;
        else if (instance != this)
            Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		// setup    		
	}
	
	// Update is called once per frame
	void Update () {
		// update
	}
}
