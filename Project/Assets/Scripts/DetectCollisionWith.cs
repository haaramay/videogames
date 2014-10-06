using UnityEngine;
using System.Collections;

public class DetectCollisionWith : MonoBehaviour {
	
	// Use this for initialization
	private GameObject player;  //Player reference
	private Health health;		//Health script of the player
	public int damage; 			//How much damage makes to the player

	public string DestroyerTag; //If the Trigger has this tag then destroy it


	void Start()
	{	
		player = GameObject.FindWithTag ("Player");
		health = player.GetComponent<Health> ();
	}

	void OnCollisionEnter(Collision other)
	{
		Animator anim = other.gameObject.GetComponent<Animator>();
		Movement_Control mov_c = other.gameObject.GetComponent<Movement_Control>();
		//Damage Player
		if (other.gameObject.tag == "Player" && mov_c.Get_Lock()<=0) 
		{ 
			health.InputDamage (damage);
			//Lock for 150 ticks
			mov_c.Set_Lock(150);
			//Move upward from damage
			Vector3 jump = new Vector3(0.0f,2,0.0f);
			other.gameObject.rigidbody.velocity = (jump*10);
			//Animation
			//anim.SetTrigger("getDamage");
			//anim.SetTrigger("BeJump");
			
		}


	}



	void OnTriggerEnter(Collider other)
	{
		//Damage Player
		Animator anim = other.gameObject.GetComponent<Animator>();
		Movement_Control mov_c = other.gameObject.GetComponent<Movement_Control>();
		//Damage Player
		if (other.gameObject.tag == "Player" && mov_c.Get_Lock()<=0) 
		{ 
			health.InputDamage (damage);
			//Lock for 150 ticks
			mov_c.Set_Lock(150);
			//Move upward from damage
			Vector3 jump = new Vector3(0.0f,2,0.0f);
			other.gameObject.rigidbody.velocity = (jump*10);
			//Animation
			//anim.SetTrigger("getDamage");
			//anim.SetTrigger("BeJump");
			
		}

		//Destroy trap if a specific monster touches it
		if (other.gameObject.tag == DestroyerTag) 
		{
			Destroy(this.gameObject);
		}

		//Destroy arrow if collides with something solid
		if(this.gameObject.tag=="Arrow" && !other.isTrigger)
			Destroy(this.gameObject);

	}
}