using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PreviousSceneLoader : MonoBehaviour {

	public List<string> previousScenes = new List<string> ();

	void Awake()
	{
		Scene scene = SceneManager.GetActiveScene ();
		previousScenes.Add (scene.name);

	}

	public void LoadPreviousScene()
	{
		string previousScene = string.Empty;
		if (previousScenes.Count > 1) {
			previousScene = previousScenes [previousScenes.Count - 1];
			previousScenes.RemoveAt (previousScenes.Count - 1);
			SceneManager.LoadScene (previousScene);
		} else {
			previousScene = previousScenes [0];
			SceneManager.LoadScene (previousScene);

		}
	}

}
