using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

	public GameObject TONE, TTWO, TTHREE, TFOUR;
	public GameObject VT1, VT2, VT3, VT4;

	public void SelectTurret(int turretNumber)
	{
		if (turretNumber == 1) {
			TONE.SetActive (true);

			TTWO.SetActive (false);
			TTHREE.SetActive (false);
			TFOUR.SetActive (false);

			VT1.SetActive (true);

			VT2.SetActive (false);
			VT3.SetActive (false);
			VT4.SetActive (false);

		}
		else if (turretNumber == 2) {
			TTWO.SetActive (true);

			TONE.SetActive (false);
			TTHREE.SetActive (false);
			TFOUR.SetActive (false);

			VT2.SetActive (true);

			VT1.SetActive (false);
			VT3.SetActive (false);
			VT4.SetActive (false);


		}
		else if (turretNumber == 3) {
			TTHREE.SetActive (true);

			TONE.SetActive (false);
			TTWO.SetActive (false);
			TFOUR.SetActive (false);

			VT3.SetActive (true);

			VT1.SetActive (false);
			VT2.SetActive (false);
			VT4.SetActive (false);



		}
		else if (turretNumber == 4) {
			TFOUR.SetActive (true);

			TONE.SetActive (false);
			TTWO.SetActive (false);
			TTHREE.SetActive (false);

			VT4.SetActive (true);

			VT1.SetActive (false);
			VT2.SetActive (false);
			VT3.SetActive (false);



		} else {
			Debug.Log ("turret failed: " + turretNumber);
		}
	}
		

}
