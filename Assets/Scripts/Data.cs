using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using GameSparks.Api;
using GameSparks.Core;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;


public class Data : MonoBehaviour {


	public static Data control;
	public int Wave;

	//stores number of virus' surviving a wave
	public int OrangeVirus, BlueVirus, GreenVirus, PinkVirus;

	//stores number of virus' spawned in wave
	public float Ovir, Bvir, Gvir, Pvir;

	//stores the wave# and Prop of Viruses for each virus.
	public List<Vector2> series1Data, series2Data, series3Data, series4Data;

	public int SpawnCount;
	public int SpawnDestroy;
	public int LossAmount, Lives;
	public int Points;
	public bool NotSet;

	public string PlayerID;


	// Use this for initialization
	void Awake ()
	{
		if (control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this)
		{
			Destroy(gameObject);
		}

	}

	public void TurretSet()
	{
		NotSet = false;
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData _data = new PlayerData();
		_data.wave = Wave;
		_data.points = Points;


		bf.Serialize(file, _data);
		file.Close();
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData _data = (PlayerData)bf.Deserialize(file);
			file.Close();

			Wave = _data.wave;
			Points = _data.points;

	
		}
	}

	public void SaveToGameSparks()
	{
		PlayerData _ViRushData = new PlayerData ();

		_ViRushData.playerId = PlayerID;

		_ViRushData.wave = Wave;

		_ViRushData.OSpawn = Ovir;
		_ViRushData.BSpawn = Bvir;
		_ViRushData.GSpawn = Gvir;
		_ViRushData.PSpawn = Pvir;

		_ViRushData.OSurv = OrangeVirus;
		_ViRushData.GSurv = GreenVirus;
		_ViRushData.BSurv = BlueVirus;
		_ViRushData.PSurv = PinkVirus;

		_ViRushData.lives = Lives;
		_ViRushData.spawnCounter = SpawnCount;

		_ViRushData.series1Data = series1Data;
		_ViRushData.series2Data = series2Data;
		_ViRushData.series3Data = series3Data;
		_ViRushData.series4Data = series4Data;

		LogEventRequest request = new LogEventRequest ();
		request.SetEventKey ("PData");
		request.SetEventAttribute ("PData", JsonUtility.ToJson (_ViRushData));

		request.Send ((response) => {
			if (!response.HasErrors) {
				Debug.Log ("Added");
			} else {
				Debug.Log (response.Errors.JSON);
			}
		});
	}


}

[Serializable]
class PlayerData
{
	public string playerId;

	public int wave, points;

	//stores number of virus' spawned in wave
	public float OSpawn, BSpawn, GSpawn, PSpawn;

	//stores number of virus' surviving a wave
	public int OSurv, BSurv, GSurv, PSurv;

	//stores the wave# and Prop of Viruses for each virus.
	public List<Vector2> series1Data, series2Data, series3Data, series4Data;

	public int spawnCounter;

	public int lives;


}