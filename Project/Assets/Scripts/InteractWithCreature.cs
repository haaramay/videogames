using UnityEngine;
using System.Collections;

public class InteractWithCreature : MonoBehaviour {
	
	
	private Movement_Control movement_player;
	void Start () {
		movement_player = GetComponent<Movement_Control> ();
	}
	
	
	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Creature") 
		{
			GameObject creature= collision.gameObject;

			transform.position= creature.transform.position+ (new Vector3(0f,5f,0f));
			creature.transform.rotation=this.transform.rotation;
			creature.transform.parent=this.transform;
			
			movement_player.Mount_Creature(true);
			//Trigger Mount Animation & Status
		}

		if (collision.gameObject.tag == "Shield") 
		{
			GameObject shield= collision.gameObject;
			shield.transform.parent=this.transform;

			shield.transform.position= this.transform.position+  new Vector3(0f,12f,0f);
			shield.transform.localScale= new Vector3(1.5f,1.5f,1.5f);

			shield.transform.rotation=this.transform.rotation;
			movement_player.Get_Shield(true);

		}

	}
	
	
	
	
	
}
