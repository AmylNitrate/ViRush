using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour 
 {


	[HideInInspector]
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	public float speed = 1f;
	public int health;
	public GameObject splat;
	public Vector3 deathPos;


	void Start()
	{
		lastWaypointSwitchTime = Time.time;
		if(Data.control.Wave < 10)
		{
			health = 50;
		}
		else if (Data.control.Wave >= 10) {
			health = 100;
		}
	}

	void Update()
	{

		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

		float pathLength = Vector3.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / speed;
		float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

		if (gameObject.transform.position.Equals(endPosition)) 
		{
			if (currentWaypoint < waypoints.Length - 2) 
			{
				currentWaypoint++;
				lastWaypointSwitchTime = Time.time;
			} 
			else 
			{
				if (gameObject.name.Equals ("OrangeVirus(Clone)")) 
				{
					Data.control.OrangeVirus++;
					Destroy (gameObject);
					Data.control.SpawnDestroy++;
					Data.control.LossAmount--;
				}
				if (gameObject.name.Equals ("BlueVirus(Clone)")) 
				{
					Data.control.BlueVirus++;
					Destroy (gameObject);
					Data.control.SpawnDestroy++;
					Data.control.LossAmount--;
				}
				if (gameObject.name.Equals ("GreenVirus(Clone)")) 
				{
					Data.control.GreenVirus++;
					Destroy (gameObject);
					Data.control.SpawnDestroy++;
					Data.control.LossAmount--;
				}
				if (gameObject.name.Equals ("PinkVirus(Clone)")) 
				{
					Data.control.PinkVirus++;
					Destroy (gameObject);
					Data.control.SpawnDestroy++;
					Data.control.LossAmount--;
				}

			}
		}

		if (health <= 0) 
		{
			GameObject.Find("GameManager").GetComponent<GameController>().parasitesEliminated += 1;
			Data.control.Points += 1;
			Data.control.SpawnDestroy++;
			deathPos = gameObject.transform.position;
			Instantiate (splat, deathPos, Quaternion.Euler(0,0,90));
			Destroy (gameObject);
		}
	}

	public void DecreaseHealth(int damage)
	{
		health -= damage;
	}
 }