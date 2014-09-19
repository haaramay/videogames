using UnityEngine;
using System.Collections;

public class GateControl : MonoBehaviour {

	private float max_height;
	private float zero_height;
	private Vector3 target_height;
	private float open_speed;

	// Use this for initialization
	void Start () 
	{
		zero_height = transform.position.y;
		max_height = transform.position.y + 30f;
		target_height = transform.position;
		open_speed = 3f;
	}
	
	void Update()
	{
		transform.position = Vector3.Lerp (transform.position, target_height, open_speed*Time.deltaTime);
	}
	
	public void OpenDoor(bool Open)
	{
		if (Open)
			target_height.y = max_height;
		else
			target_height.y = zero_height;

	}

}
