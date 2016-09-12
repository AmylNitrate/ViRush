using UnityEngine;
using System.Collections;

public class DestroyFX : MonoBehaviour {

	public AudioClip clip;
	public AudioSource source;
	// Use this for initialization
	void Start () 
	{
		source = GameObject.Find ("GameManager").GetComponent<AudioSource> ();
		source.PlayOneShot (clip);
		Destroy (gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
