using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
	public GameObject turret;
	public GameObject barrel;
	GameObject OBullet, BBullet, GBullet, PBullet, OBig, BBig, GBig, PBig;
	public int OStrength, BStrength, GStrength, PStrength;


	void Start()
	{
		UnityEngine.Object OObject = Resources.Load ("OBullet");
		OBullet = (GameObject)OObject;
		UnityEngine.Object BObject = Resources.Load ("BBullet");
		BBullet = (GameObject)BObject;
		UnityEngine.Object PObject = Resources.Load ("PBullet");
		PBullet = (GameObject)PObject;
		UnityEngine.Object GObject = Resources.Load ("GBullet");
		GBullet = (GameObject)GObject;

		UnityEngine.Object OObj = Resources.Load ("OBig");
		OBig = (GameObject)OObj;
		UnityEngine.Object BObj = Resources.Load ("BBig");
		BBig = (GameObject)BObj;
		UnityEngine.Object PObj = Resources.Load ("PBig");
		PBig = (GameObject)PObj;
		UnityEngine.Object GObj = Resources.Load ("GBig");
		GBig = (GameObject)GObj;

	}
	// Update is called once per frame
	public void SetBullet () 
	{
		OStrength = turret.gameObject.GetComponent<VirusSelect> ().OStrength;
		BStrength = turret.gameObject.GetComponent<VirusSelect> ().BStrength;
		GStrength = turret.gameObject.GetComponent<VirusSelect> ().GStrength;
		PStrength = turret.gameObject.GetComponent<VirusSelect> ().PStrength;

		switch (OStrength) 
		{
		case 1:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (OBullet, 5f, 25);

			break;
		case 2:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (OBullet, 10f, 25);

			break;
		case 3:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (OBullet, 15f, 25);

			break;
		case 4:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (OBig, 10f, 50);

			break;
		case 5:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (OBig, 15f, 50);

			break;
		default:
			//Debug.Log ("Default");
			break;
		}

		switch (BStrength) {
		case 1:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (BBullet, 5f, 25);

			break;
		case 2:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (BBullet, 10f, 25);

			break;
		case 3:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (BBullet, 15f, 25);

			break;
		case 4:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (BBig, 10f, 50);

			break;
		case 5:
			
			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (BBig, 15f, 50);

			break;
		default:
			//Debug.Log ("Default");
			break;
		}

		switch (GStrength) 
		{
		case 1:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (GBullet, 5f, 25);

			break;
		case 2:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (GBullet, 10f, 25);

			break;
		case 3:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (GBullet, 15f, 25);

			break;
		case 4:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (GBig, 10f, 50);

			break;
		case 5:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (GBig, 15f, 50);

			break;
		default:
			//Debug.Log ("Default");
			break;
		}

		switch (PStrength) 
		{
		case 1:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (PBullet, 5f, 25);

			break;
		case 2:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (PBullet, 10f, 25);

			break;
		case 3:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (PBullet, 15f, 25);

			break;
		case 4:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (PBig, 10f, 50);

			break;
		case 5:

			barrel.gameObject.GetComponent<Barrel> ().InstantiateBullet (PBig, 15f, 50);

			break;
		default:
			//Debug.Log ("Default");
			break;
		}

	}

}
