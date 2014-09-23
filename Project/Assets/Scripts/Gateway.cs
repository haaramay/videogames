using UnityEngine;
using System.Collections;

public class Gateway : MonoBehaviour {

	public GameObject Destiny_Gateway;
	public KeyCode Active_Key;
	
	private GameObject player;
	private Animator anim_player;
	private Quaternion original_rotation;

	private bool is_origin;
	private bool in_gateway;
	private bool is_crossing;

	private float speed;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		anim_player = player.GetComponent<Animator> ();
		speed = 1.5f;
		is_crossing = false;
		in_gateway = false;
		is_origin = false;
	}

	public void set_crossing_gateway(bool crossing_gateway)
	{
		is_crossing = crossing_gateway;
	}




	// Update is called once per frame
	void FixedUpdate () {

		//The player is at this gateway entrace, wasn't crossing previously and Input the action of crossing
		if (in_gateway && !is_crossing && Input.GetKeyDown (Active_Key))
		{
			is_origin=true; //this gate is 
			is_crossing = true;	//Now is crossing
			Destiny_Gateway.GetComponent<Gateway>().set_crossing_gateway(is_crossing); //The destiny gateway_entrance also knows it's crossing

			original_rotation=player.transform.rotation;				  //Save the original rotation
			player.transform.LookAt(Destiny_Gateway.transform.position); //The player looks at the destiny layer.
			//anim_player.SetBool("IsWalking",true);

		}

		//player is crossing and I have reference to the player
		if (is_origin && is_crossing) 
		{
			//Lerp it to through the gateway toward the DestinyGateway
			Vector3 destinyPosition=Destiny_Gateway.transform.position;
			destinyPosition.y=player.transform.position.y; //keep the player height constant
			player.transform.position=Vector3.Lerp(player.transform.position,destinyPosition,speed*Time.deltaTime);

			//ReachDestinyPosition
			if(Vector3.Distance(player.transform.position,destinyPosition)<1.0)
			{
				player.transform.position=destinyPosition; //Translate to destiny position
				//anim_player.SetBool("IsWalking",false);
				player.transform.rotation=original_rotation;	//Recover initial rotation

				is_origin=false;	//This Entrance is not the origin of the translation anymore
				is_crossing=false; //It finished crossing
				Destiny_Gateway.GetComponent<Gateway>().set_crossing_gateway(is_crossing); //The Destiny gateway also knows it finished crossing
			}
		}
	}

	//When entering gateway entrance.
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
			in_gateway = true;		//The player is in the gateway_entrance position
	}

	//When leaving gateway_entrance
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
			in_gateway = false; 	//The player is not anymore at this gateway entrance
	}


	 
	/* If I dont want to keep the reference to the player
	if(Vector3.Distance(player.transform.position,destinyPosition)<1.0)	//player=null;	//The starting GatewayEntrance forgets about the player
	void OnTriggerEnter(Collider other)	//player=other.gameObject;	//Save the reference for this entrance
	void OnTriggerExit(Collider other)	//if(!is_crossing)player=null;	//If the player didn't cross and leaves, release it's reference								//I keep the reference if it's crossing to Lerp it through the gateway from THIS CLASS
	*/


}
