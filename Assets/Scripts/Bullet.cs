using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public int damageAmount;
	public Transform targetPosition;
	public Quaternion targetRotation;
	public string _target;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate()
	{
		if (targetPosition) {
			Vector3 dir = targetPosition.position - transform.position;
			targetRotation = Quaternion.LookRotation (-dir, Vector3.left);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * speed;
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals(_target)) 
		{
			col.gameObject.GetComponent<Virus> ().DecreaseHealth (damageAmount);
			Destroy (gameObject);

		} else
		{
		//Destroy (gameObject);
		}
	}
}
