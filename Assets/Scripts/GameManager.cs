using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	MovingObject[] objects;
	PositionHandler positionHandler;

	// Use this for initialization
	void Start () {
		Networktest test = new Networktest ();

		test.Start ();
        //Check if instance already exists
        if (instance == null)
			instance = this;
        else if (instance != this)
            Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		//positionHandler = new RandomPositionHandler();
		positionHandler = new CsvFilePositionHandler("positions.csv");
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

public class Networktest : MonoBehaviour {

	// Use this for initialization

	string msg = "";
	 Thread mThread; 
	 bool mRunning;
	TcpListener tcp_Listener = null;
	public void Start()
	{
		mRunning = true;
		ThreadStart ts = new ThreadStart(SayHello);
		mThread = new Thread(ts);
		mThread.Start();
		print("Thread done...");
	}
	public void stopListening()
	{
		mRunning = false;
	}
	 public void SayHello()
	{
		try
		{
			tcp_Listener = new TcpListener(8123);
			tcp_Listener.Start();
			print("Server Start");
			while (mRunning)
			{
				// check if new connections are pending, if not, be nice and sleep 100ms
				if (!tcp_Listener.Pending())
				{
					Thread.Sleep(100);
				}
				else
				{
					print("1");
					TcpClient client = tcp_Listener.AcceptTcpClient();
					print("2");
					NetworkStream ns = client.GetStream();
					print("3");
					while (true) {
					StreamReader reader = new StreamReader(ns);
					    print("4");
					    msg = reader.ReadLine();
					    print(msg);
						Thread.Sleep(1);
					}
//					reader.Close();
//					client.Close();
				}
			}
		}
		catch (ThreadAbortException)
		{
			print("exception");
		}
		finally
		{
			mRunning = false;
			tcp_Listener.Stop();
		}
	}
	void OnApplicationQuit()
	{
		// stop listening thread
		stopListening();
		// wait fpr listening thread to terminate (max. 500ms)
		mThread.Join(500);
	}
}

