using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastAttemptUI : MonoBehaviour {

	Text textRef2;

	// Use this for initialization
	void Start () {

		textRef2 = GameObject.Find ("PastAttemptValue_Text").GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		textRef2.text = "Wave: " + Data.control.Wave;
	
	}
}
