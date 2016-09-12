using UnityEngine;
using System;
using System.Collections.Generic;


public class WayPoint : MonoBehaviour 
{
	public GameObject Bluevirus, PinkVirus, OrangeVirus, GreenVirus;
	public GameObject[] waypoints;

	public List<GameObject> virus = new List<GameObject>();

	System.Random random = new System.Random();

	void setViruses()
	{
		int Blues = (Data.control.BlueVirus+1) * 4;

		int Greens = (Data.control.GreenVirus+1) * 4;

		int Pinks = (Data.control.PinkVirus+1) * 4;

		int Oranges = (Data.control.OrangeVirus+1) * 4;


		for (int i = 0; i < Blues; i++) 
		{
			virus.Add (Bluevirus);
		}
		for (int i = 0; i < Pinks; i++) 
		{
			virus.Add (PinkVirus);
		}
		for (int i = 0; i < Oranges; i++) 
		{
			virus.Add (OrangeVirus);
		}
		for (int i = 0; i < Greens; i++) 
		{
			virus.Add (GreenVirus);
		}
			
	}

	public void SpawnNext()
	{

		Instantiate (virus[random.Next( 0, virus.Count)]).GetComponent<Virus> ().waypoints = waypoints;
		Data.control.SpawnCount++;
	}
	public void Spawn(float interval)
	{
		setViruses ();
		InvokeRepeating ("SpawnNext", interval, interval);
	}

	public void CancelSpawn()
	{
		CancelInvoke ();
		virus.Clear ();
	}

}