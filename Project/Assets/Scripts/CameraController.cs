using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag ("Player");
		offset = transform.position-player.transform.position;//new Vector3 (0f, 5f, -20f);
			
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = offset + player.transform.position;


	}
}
