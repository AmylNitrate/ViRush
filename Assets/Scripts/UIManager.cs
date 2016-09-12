using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text Orange, Blue, Pink, Green;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(string scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
