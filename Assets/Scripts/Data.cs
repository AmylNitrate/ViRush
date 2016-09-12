using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Data : MonoBehaviour {


	public static Data control;

	public int Wave;

	public int OrangeVirus, BlueVirus, GreenVirus, PinkVirus;

	public int SpawnCount;
	public int SpawnDestroy;

	public int LossAmount, Lives;

	public int Points;

	public bool NotSet;

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

}

[Serializable]
class PlayerData
{
	public int wave;
	public int points;

}