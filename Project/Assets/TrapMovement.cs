using UnityEngine;
using System.Collections;

public class TrapMovement : MonoBehaviour {

	public float max_height;
	public float min_height;
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= max_height)
				rigidbody.velocity = transform.forward * -speed;
		if (transform.position.y <= min_height)
			rigidbody.velocity = transform.forward * speed;


	}
}
