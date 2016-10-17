using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using GameSparks.Api;
using GameSparks.Core;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


	public GameObject[] waypoints;
	public GameObject[] viruses;
	public GameObject[] turrets;
	public GameObject[] SelectionTurrets;
	public GameObject[] upgradeButtons;
	public GameObject intermission, setTurrets, failed, warning;

	Text textRef2, textRef3, textRef4, textRef5, textRef6;
	Text Otext, Btext, Ptext, Gtext;

	public int tempO, tempP, tempG, tempB, tempPoints;

	public int tempParElim;
	int spawnAmount;
	int totalLossAmount;
	public string timeS;
	bool isAuthenticated;

	// Use this for initialization
	void Start () 
	{

		textRef2 = GameObject.Find ("ParaElimValue").GetComponent<Text> ();
		textRef3 = GameObject.Find ("WaveValue").GetComponent<Text> ();
		textRef4 = GameObject.Find ("PointsValue").GetComponent<Text> ();
		textRef5 = GameObject.Find ("LossCounter").GetComponent<Text> ();
		textRef6 = GameObject.Find ("TimeScale").GetComponent<Text> ();
		Otext = GameObject.Find ("OrangeElimValue").GetComponent<Text> ();
		Btext = GameObject.Find ("BlueElimValue").GetComponent<Text> ();
		Ptext = GameObject.Find ("PinkElimValue").GetComponent<Text> ();
		Gtext = GameObject.Find ("GreenElimValue").GetComponent<Text> ();

		turrets = GameObject.FindGameObjectsWithTag("Turrets");
		SelectionTurrets = GameObject.FindGameObjectsWithTag("SelectionTurret");
		upgradeButtons = GameObject.FindGameObjectsWithTag ("Upgrade");

		spawnAmount = 40;
		totalLossAmount = 20;
		timeS = "1x";

		Data.control.Lives = 3;
		Data.control.Wave = 1;
		Data.control.LossAmount = 20;
		Data.control.Points = 0;
		Data.control.ParasitesEliminated = 0;
		Data.control.BlueVirus = 2;
		Data.control.GreenVirus = 2;
		Data.control.PinkVirus = 2;
		Data.control.OrangeVirus = 2;
		Data.control.NotSet = false;

		Data.control.Load ();

		for (int i = 0; i < 4; i++) 
		{
			SelectionTurrets [i].SetActive (false);
		}

		Data.control.PlayerID = GeneratePlayerID ();
		AuthenticatePlayer ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//if 40 virus' have been spawned, then stop spawning
		if (Data.control.SpawnCount >= spawnAmount) 
		{
			for (int i = 0; i < 4; i++) 
			{
				waypoints [i].GetComponent<WayPoint> ().CancelSpawn ();
			}
		}

		//if all spawned virus' have been destroyed, then reset and go to next wave
		if (Data.control.SpawnDestroy >= spawnAmount) 
		{
			
			Data.control.series1Data.Add (new Vector2(Data.control.Wave, (Data.control.Ovir/40) * 100));
			Data.control.series2Data.Add (new Vector2(Data.control.Wave, (Data.control.Bvir/40) * 100));
			Data.control.series3Data.Add (new Vector2(Data.control.Wave, (Data.control.Gvir/40) * 100));
			Data.control.series4Data.Add (new Vector2(Data.control.Wave, (Data.control.Pvir/40) * 100));

			Data.control.SaveToGameSparks ();

			ResetWaypointAndBarrel ();
			intermission.SetActive (true);
			ResetTurret ();
			ResetValues ();
			Data.control.Wave++;
			Data.control.TurretSelects.Clear ();
			Data.control.Save ();


		}

		//if 20 virus' get through your defence, then reset entire wave
		if (Data.control.LossAmount <= 0) 
		{
			Data.control.series1Data.Add (new Vector2(Data.control.Wave, (Data.control.Ovir/40) * 100));
			Data.control.series2Data.Add (new Vector2(Data.control.Wave, (Data.control.Bvir/40) * 100));
			Data.control.series3Data.Add (new Vector2(Data.control.Wave, (Data.control.Gvir/40) * 100));
			Data.control.series4Data.Add (new Vector2(Data.control.Wave, (Data.control.Pvir/40) * 100));

			Data.control.SaveToGameSparks();

			Data.control.TurretSelects.Clear ();

			if (Data.control.Lives <= 1) {
				Data.control.series1Data.Clear ();
				Data.control.series2Data.Clear ();
				Data.control.series3Data.Clear ();
				Data.control.series4Data.Clear ();
				Data.control.DeleteFile ();
				ResetWaypointAndBarrel ();
				ResetTurret ();
				failed.SetActive (true);
				ResetValues ();
				Data.control.Wave = 1;
				Data.control.Points = 0;
				Data.control.Lives = 3;
				Data.control.OrangeVirus = 2;
				Data.control.BlueVirus = 2;
				Data.control.GreenVirus = 2;
				Data.control.PinkVirus = 2;
				Data.control.ParasitesEliminated = 0;
				GameObject.Find ("Back_Button1").SetActive (false);
				GameObject.Find ("Skip").SetActive (false);

			} 
			else 
			{
				ResetWaypointAndBarrel ();
				ResetTurret ();
				warning.SetActive (true);
				Data.control.Lives--;
				ResetValues ();
				Data.control.ParasitesEliminated = tempParElim;
				Data.control.BlueVirus = tempB;
				Data.control.GreenVirus = tempG;
				Data.control.OrangeVirus = tempO;
				Data.control.PinkVirus = tempP;
				Data.control.Points = tempPoints;
				GameObject.Find ("Back_Button1").SetActive (false);
				GameObject.Find ("Skip").SetActive (false);
				Data.control.Save ();
			}
		
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
			tempParElim = Data.control.ParasitesEliminated;
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

	public void ResetValues()
	{
		Data.control.SpawnCount = 0;
		Data.control.SpawnDestroy = 0;
		Data.control.LossAmount = totalLossAmount;
		Data.control.Ovir = 0;
		Data.control.Bvir = 0;
		Data.control.Gvir = 0;
		Data.control.Pvir = 0;
		timeS = "1x";
	}

	public void SetTexts()
	{
		textRef2.text = Data.control.ParasitesEliminated.ToString ();
		textRef3.text = Data.control.Wave.ToString ();
		textRef4.text = Data.control.Points.ToString () + "/50";
		textRef5.text = Data.control.LossAmount.ToString ();
		textRef6.text = timeS;
		Otext.text = Data.control.OrangeVirus.ToString ();
		Ptext.text = Data.control.PinkVirus.ToString ();
		Gtext.text = Data.control.GreenVirus.ToString ();
		Btext.text = Data.control.BlueVirus.ToString ();
	}

	public void FastForward()
	{

		if (Time.timeScale == 1) {
			Time.timeScale = 3;
			timeS = "2x";
		}
		else
		{
			Time.timeScale = 1;
			timeS = "1x";
		}
	}

	public void Pause()
	{
		if (Time.timeScale >= 1) {
			Time.timeScale = 0;
			timeS = "0";
		}
		else
		{
			Time.timeScale = 1;
			timeS = "1x";
		}
	}
	public void UnPause()
	{
		Time.timeScale = 1;
		timeS = "1x";
	}

	string GeneratePlayerID()
	{
		string temp;
		int rand = UnityEngine.Random.Range (0, 100000);
		temp = Application.systemLanguage + Application.platform.ToString () + System.DateTime.Now + rand.ToString ();
		return temp;
	}

	void AuthenticatePlayer()
	{
		if (!isAuthenticated) {
			Debug.Log ("calling");
			new GameSparks.Api.Requests.DeviceAuthenticationRequest ().SetDisplayName (Data.control.PlayerID).Send ((response) => {
				if (!response.HasErrors) {
					Debug.Log ("Device Authenticated...");
					isAuthenticated = true;
				} else {
					Debug.Log ("Error Authenticating Device...");
					isAuthenticated = false;
				}
			});
		}
	}


}
