using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScene : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		if (time > 3) {
			SceneManager.LoadScene ("Menu");
		}
	}
}
