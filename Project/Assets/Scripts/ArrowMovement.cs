using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {



	public float speed;
	
	
	void Start()
	{	
		rigidbody.velocity = transform.forward * speed;
	}





}
