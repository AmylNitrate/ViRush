using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text Orange, Blue, Pink, Green;

	// Use this for initialization
	void Start () 
	{
		Scene scene = SceneManager.GetActiveScene ();
		if (scene.name.Equals ("Menu")) {
			Data.control.DeleteFile ();
		} else {
			Debug.Log ("Scene: " + scene.name);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(string scene)
	{
		if (scene == "Menu") 
		{
			Data.control.DeleteFile ();
		}
		SceneManager.LoadScene (scene);

	}

	public void Exit()
	{
		Data.control.DeleteFile();
		Application.Quit ();
	}
}
