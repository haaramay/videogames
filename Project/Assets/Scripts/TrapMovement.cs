using UnityEngine;
using System.Collections;

public class TrapMovement : MonoBehaviour {

	private float start_height;

	public float range;
	public int pos; //0 se mueve en x, 1 en y, 2 en z
	public float speed;
	private Vector3 aux;
	private float max_height;
	private float min_height;


	// Use this for initialization
	void Start () {
		if (pos == 1) {
			aux = new Vector3 (0.0f, 1.0f, 0.0f);
			start_height = transform.position.y;
		} else if (pos == 0) {
			aux = new Vector3 (1.0f, 0.0f, 0.0f);
			start_height = transform.position.x;
		} else {
			aux = new Vector3 (0.0f, 0.0f, 1.0f);
			start_height = transform.position.z;
		}
		rigidbody.velocity = aux * speed;
		max_height = start_height + range;
		min_height = start_height;
	}

	double CalculatePos()
	{
		if (pos == 1) {
			return transform.position.y;
		} else if (pos == 0) {
			return transform.position.x;
		} else {
			return transform.position.z;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (CalculatePos() >= max_height)
				rigidbody.velocity = aux * -speed;
		if (CalculatePos() <= min_height)
			rigidbody.velocity = aux * speed;

	}
}
