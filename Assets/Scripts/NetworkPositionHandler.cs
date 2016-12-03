using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPositionHandler : PositionHandler {
	Dictionary<string, Position> posDict;

	public NetworkPositionHandler()
	{
		posDict = new Dictionary<string, Position>();
	}

	public void AddPosition(Position pos)
	{
		posDict[pos.name] = pos;
	}

    public override void UpdatePositions(MovingObject[] objects) {
        foreach (MovingObject obj in objects) {
			if (posDict.ContainsKey(obj.GetName()))
            	obj.SetPosition(posDict[obj.GetName()].position);
        }
	}

}

public class NetworkServer : MonoBehaviour {
	// Use this for initialization
	string msg = "";
	Thread mThread; 
	bool mRunning;
	TcpListener tcp_Listener = null;
	NetworkPositionHandler posHandler;

	public NetworkServer (NetworkPositionHandler handler)
	{
		posHandler = handler;
	}

	public void Start()
	{
		mRunning = true;
		ThreadStart ts = new ThreadStart(ServerThread);
		mThread = new Thread(ts);
		mThread.Start();
	}

	public void stopListening()
	{
		mRunning = false;
	}

	public void ServerThread()
	{
		try {
			tcp_Listener = new TcpListener(8123);
			tcp_Listener.Start();
			while (mRunning)
			{
				// check if new connections are pending, if not, be nice and sleep 100ms
				if (!tcp_Listener.Pending()) {
					Thread.Sleep(100);
				}
				else {
					TcpClient client = tcp_Listener.AcceptTcpClient();
					NetworkStream ns = client.GetStream();
					while (true) {
						StreamReader reader = new StreamReader(ns);
					    msg = reader.ReadLine();
					    posHandler.AddPosition(Position.ParseLine(msg));
						Thread.Sleep(1);
					}
				}
			}
		}
		catch (ThreadAbortException) {
			print("exception");
		}
		finally {
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
