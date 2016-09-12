using UnityEngine;
using System.Collections.Generic;

public class Hearts : MonoBehaviour 
{
	public GameObject H1, H2, H3;
	List<GameObject> HSprites = new List<GameObject>();

	void Start()
	{
		HSprites.Add (H1);
		HSprites.Add (H2);
		HSprites.Add (H3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Data.control.Lives >= 3) {
			for (int i = 0; i < 3; i++) {
				HSprites [i].SetActive (true);
			}
		} else if (Data.control.Lives == 2) {
			H1.SetActive (true);
			H2.SetActive (true);
			H3.SetActive (false);
		} else if (Data.control.Lives == 1) {
			H1.SetActive (true);
			H2.SetActive (false);
			H3.SetActive (false);
		} else if (Data.control.Lives <= 0) {
			for (int i = 0; i < 3; i++) {
				HSprites [i].SetActive (false);
			}
		}
	}
}
