using UnityEngine;
using System.Collections;

public class DetectCollisionWithPlayer : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	Health health;


	void Start()
	{	
		player = GameObject.FindWithTag ("Player");
		health = player.GetComponent<Health> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{ 
			health.InputDamage (1);
			Debug.Log(health.DisplayHealth());
		}


	}
}
