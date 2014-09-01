using UnityEngine;
using System.Collections;

public class TrapMovement : MonoBehaviour {

	private float max_height;
	private float min_height;

	public float range;
	public float speed;


	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
		max_height = transform.position.y + range;
		min_height = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= max_height)
				rigidbody.velocity = transform.forward * -speed;
		if (transform.position.y <= min_height)
			rigidbody.velocity = transform.forward * speed;

	}
}
