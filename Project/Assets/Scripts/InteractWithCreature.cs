using UnityEngine;
using System.Collections;

public class InteractWithCreature : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision)
	{
		/*if (collision.gameObject.tag == "Creature") 
		{
			GameObject creature= collision.gameObject;
			creature.transform.parent=this.transform;
			creature.transform.position= this.transform.position- this.transform.forward*10;


			creature.transform.LookAt(this.transform.position);
		}
		*/
		if (collision.gameObject.tag == "Creature") 
		{
			GameObject creature= collision.gameObject;
			transform.position= creature.transform.position+ (new Vector3(0f,5f,0f));
			creature.transform.parent=this.transform;

			creature.transform.rotation=this.transform.rotation;

			//Trigger Mount Animation & Status

		}


	}





}
