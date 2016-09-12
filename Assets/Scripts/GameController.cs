using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour {


	public GameObject[] waypoints;
	public GameObject[] viruses;
	public GameObject[] turrets;
	public GameObject[] SelectionTurrets;
	public GameObject[] upgradeButtons;
	public GameObject intermission, setTurrets, failed, warning;

	Text textRef2, textRef3, textRef4, textRef5;
	Text Otext, Btext, Ptext, Gtext;

	public int tempO, tempP, tempG, tempB, tempPoints;

	public int parasitesEliminated, tempParElim;
	int spawnAmount;
	int totalLossAmount;


	// Use this for initialization
	void Start () 
	{
		
		textRef2 = GameObject.Find ("ParaElimValue").GetComponent<Text> ();
		textRef3 = GameObject.Find ("WaveValue").GetComponent<Text> ();
		textRef4 = GameObject.Find ("PointsValue").GetComponent<Text> ();
		textRef5 = GameObject.Find ("LossCounter").GetComponent<Text> ();
		Otext = GameObject.Find ("OrangeElimValue").GetComponent<Text> ();
		Btext = GameObject.Find ("BlueElimValue").GetComponent<Text> ();
		Ptext = GameObject.Find ("PinkElimValue").GetComponent<Text> ();
		Gtext = GameObject.Find ("GreenElimValue").GetComponent<Text> ();

		turrets = GameObject.FindGameObjectsWithTag("Turrets");
		SelectionTurrets = GameObject.FindGameObjectsWithTag("SelectionTurret");
		upgradeButtons = GameObject.FindGameObjectsWithTag ("Upgrade");

		spawnAmount = 40;
		totalLossAmount = 20;

		Data.control.Lives = 3;
		Data.control.Wave = 1;
		Data.control.LossAmount = 20;
		Data.control.Points = 0;
		Data.control.BlueVirus = 2;
		Data.control.GreenVirus = 2;
		Data.control.PinkVirus = 2;
		Data.control.OrangeVirus = 2;
		Data.control.NotSet = false;

		for (int i = 0; i < 4; i++) 
		{
			SelectionTurrets [i].SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Data.control.SpawnCount >= spawnAmount) 
		{
			for (int i = 0; i < 4; i++) 
			{
				waypoints [i].GetComponent<WayPoint> ().CancelSpawn ();
			}
		}
		if (Data.control.SpawnDestroy >= spawnAmount) 
		{
			ResetWaypointAndBarrel ();

			intermission.SetActive (true);

			ResetTurret ();

			Data.control.Wave++;
			Data.control.SpawnCount = 0;
			Data.control.SpawnDestroy = 0;
			Data.control.LossAmount = totalLossAmount;

		}
		if (Data.control.LossAmount <= 0) 
		{
			ResetWaypointAndBarrel ();
			ResetTurret ();
			warning.SetActive (true);
			Data.control.SpawnCount = 0;
			Data.control.SpawnDestroy = 0;
			Data.control.LossAmount = totalLossAmount;
			Data.control.Lives--;
			parasitesEliminated = tempParElim;
			Data.control.BlueVirus = tempB;
			Data.control.GreenVirus = tempG;
			Data.control.OrangeVirus = tempO;
			Data.control.PinkVirus = tempP;
			Data.control.Points = tempPoints;
		}
		if (Data.control.Lives <= 0) 
		{
			ResetWaypointAndBarrel ();
			ResetTurret ();
			failed.SetActive (true);
			Data.control.Wave = 1;
			Data.control.SpawnCount = 0;
			Data.control.SpawnDestroy = 0;
			Data.control.LossAmount = totalLossAmount;
			Data.control.Points = 0;
			Data.control.Lives = 3;
			Data.control.OrangeVirus = 2;
			Data.control.BlueVirus = 2;
			Data.control.GreenVirus = 2;
			Data.control.PinkVirus = 2;
			parasitesEliminated = 0;
		}

		SetTexts ();

		if (Data.control.Points >= 50) 
		{
			CanUpgrade ();
		}
		else if (Data.control.Points < 50) 
		{
			noUpgrade ();
		}

		if (Data.control.Wave >= 5) 
		{
			totalLossAmount = 15;
		} 
		else if (Data.control.Wave >= 10) 
		{
			totalLossAmount = 10;
		}
	
	}

	public void NextWave()
	{
		
		for (int i = 0; i < 4; i++) 
		{
			int VN = turrets [i].GetComponent<VirusSelect> ().virusNumber;
			if (VN <= 0) 
			{
				Data.control.NotSet = true;
			} 
		}

		if (Data.control.NotSet) 
		{
			setTurrets.SetActive (true);
		} 
		else if(!Data.control.NotSet)
		{
			tempParElim = parasitesEliminated;
			tempB = Data.control.BlueVirus;
			tempG = Data.control.GreenVirus;
			tempO = Data.control.OrangeVirus;
			tempP = Data.control.PinkVirus;
			tempPoints = Data.control.Points;

			for (int i = 0; i < 4; i++) 
			{
				waypoints [i].GetComponent<WayPoint> ().Spawn (4f);
			}

			Data.control.OrangeVirus = 0;
			Data.control.BlueVirus = 0;
			Data.control.GreenVirus = 0;
			Data.control.PinkVirus = 0;
			Data.control.NotSet = true;
		}


	}

	void DestroyAllObjects()
	{
		viruses = GameObject.FindGameObjectsWithTag ("Virus");

		for(int i = 0 ; i < viruses.Length ; i ++)
		{
			Destroy(viruses[i]);
		}
	}

	void ResetTurret()
	{
		for (int i = 0; i < turrets.Length; i++) 
		{
			turrets [i].GetComponent<VirusSelect> ().ResetTurrets ();
		}
	}

	public void CanUpgrade ()
	{

		for (int i = 0; i < upgradeButtons.Length; i++) 
		{
			upgradeButtons [i].SetActive (true);
		}


	}

	public void noUpgrade()
	{
		for (int i = 0; i < upgradeButtons.Length; i++) {
			upgradeButtons [i].SetActive (false);
		}
	}

	public void ResetWaypointAndBarrel()
	{
		for (int i = 0; i < 4; i++) 
		{
			waypoints [i].GetComponent<WayPoint> ().CancelSpawn ();
			DestroyAllObjects ();
			GameObject.Find ("EyeLenseGun1").GetComponent<Barrel> ().ClearList ();
			GameObject.Find ("EyeLenseGun2").GetComponent<Barrel> ().ClearList ();
			GameObject.Find ("EyeLenseGun3").GetComponent<Barrel> ().ClearList ();
			GameObject.Find ("EyeLenseGun4").GetComponent<Barrel> ().ClearList ();

		}

		Time.timeScale = 1;
		Data.control.NotSet = false;

	}

	public void SetTexts()
	{
		textRef2.text = parasitesEliminated.ToString ();
		textRef3.text = Data.control.Wave.ToString ();
		textRef4.text = Data.control.Points.ToString () + "/50";
		textRef5.text = Data.control.LossAmount.ToString ();
		Otext.text = Data.control.OrangeVirus.ToString ();
		Ptext.text = Data.control.PinkVirus.ToString ();
		Gtext.text = Data.control.GreenVirus.ToString ();
		Btext.text = Data.control.BlueVirus.ToString ();
	}

	public void FastForward(float speed)
	{
		Time.timeScale = speed;
	}

}
