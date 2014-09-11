using UnityEngine;
using System.Collections;

public class DetectCollisionWith : MonoBehaviour {
	
	// Use this for initialization
	private GameObject player;  //Player reference
	private Health health;		//Health script of the player
	public int damage; 			//How much damage makes to the player

	
	
	void Start()
	{	
		player = GameObject.FindWithTag ("Player");
		health = player.GetComponent<Health> ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Damage Player
		if (other.gameObject.tag == "Player") 
		{ 
			health.InputDamage (damage);
		}

		//Destroy trap if monster touches it
		if (other.gameObject.tag == "Creature") 
		{
			Destroy(this.gameObject);
		}

		
	}
}