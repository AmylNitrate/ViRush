using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrel : MonoBehaviour {

	Canvas canvas;

	public List<GameObject> bullets = new List<GameObject>();
	public List<float> speeds = new List<float>();
	public List<float> coolDowns = new List<float> ();
	public List<int> damages = new List<int>();

	public AudioClip clip;
	AudioSource source;

	public float cooldown;


	// Use this for initialization
	void Start () {
		canvas = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<Canvas> ();
		source = GameObject.Find ("GameManager").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldown -= Time.deltaTime;
	}

	public void InstantiateBullet(GameObject bulletType, float SpeedNum, int DamageNum, float coolD)
	{
		bullets.Add(bulletType);
		speeds.Add (SpeedNum);
		damages.Add (DamageNum);
		coolDowns.Add (coolD);
	}

	public void ClearList()
	{
		bullets.Clear ();
		speeds.Clear ();
		damages.Clear ();
	}

	void OnTriggerStay2D(Collider2D col)
	{

		for (int i = 0; i < bullets.Count; i++) 
		{
			switch (bullets [i].name) 
			{
			case "OBullet":
				if (col.gameObject.name.Equals ("OrangeVirus(Clone)")) 
				{
					if (cooldown <= 0) 
					{
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}
				}

				break;
			case "BBullet":
				if (col.gameObject.name.Equals ("BlueVirus(Clone)")) 
				{
					if (cooldown <= 0) 
					{
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}
				}
				break;
			case "GBullet":
				if (col.gameObject.name.Equals ("GreenVirus(Clone)")) 
				{
					if (cooldown <= 0) {
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}
				}
				break;
			case "PBullet":
				if (col.gameObject.name.Equals ("PinkVirus(Clone)")) 
				{
					if (cooldown <= 0) {
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}

				}
				break;
			case "OBig":
				if (col.gameObject.name.Equals ("OrangeVirus(Clone)")) 
				{
					if (cooldown <= 0) {
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}

				}

				break;
			case "BBig":
				if (col.gameObject.name.Equals ("BlueVirus(Clone)")) 
				{
					if (cooldown <= 0) {
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}

				}
				break;
			case "GBig":
				if (col.gameObject.name.Equals ("GreenVirus(Clone)")) 
				{
					if (cooldown <= 0) {
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}

				}
				break;
			case "PBig":
				if (col.gameObject.name.Equals ("PinkVirus(Clone)")) 
				{
					if (cooldown <= 0) {
						GameObject bulletSpawned = Instantiate ((GameObject)bullets [i]);
						bulletSpawned.transform.SetParent (canvas.transform, false);
						bulletSpawned.transform.position = gameObject.transform.position;
						bulletSpawned.transform.localRotation = Quaternion.identity;
						bulletSpawned.GetComponent<Bullet> ().targetPosition = col.transform;
						bulletSpawned.GetComponent<Bullet> ().damageAmount = damages[i];
						bulletSpawned.GetComponent<Bullet> ().speed = speeds[i];
						source.PlayOneShot (clip);
						Debug.Log("Bullet: " + bulletSpawned.name + " D: " + damages[i] + " S: " + speeds[i] + " C: " + coolDowns[i]);
						cooldown = coolDowns[i];
					}

				}
				break;

			default:
				

				break;
			}
		}
	}
}
