using UnityEngine;
using System.Collections;

public class TrapMovement : MonoBehaviour {

	private float start_height;

	public float range;
	public float speed;


	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
		start_height = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float max_height = start_height + range;
		float min_height = start_height;

		if (transform.position.y >= max_height)
				rigidbody.velocity = transform.forward * -speed;
		if (transform.position.y <= min_height)
			rigidbody.velocity = transform.forward * speed;

	}
}
