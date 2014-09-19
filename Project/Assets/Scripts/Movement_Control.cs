using UnityEngine;
using System.Collections;

public class Movement_Control : MonoBehaviour {

	private Animator anim;
	private GameObject creature;
	private GameObject shield;

	private bool IsMounted;
	private bool ActiveShield;



	public float speed;
	public float jumpStrength;
	private int Jumps;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Jumps = 3;
		IsMounted = false;
		ActiveShield = false;
	}

	//Called from Interact with Creature
	private GameObject FindChildren(string tag)
	{
		Transform[] childrens = this.GetComponentsInChildren<Transform> ();

		foreach(Transform value in childrens)
			if(value.tag==tag)
				return value.gameObject;
		return null;

	}

	public void Mount_Creature(bool Mounting)
	{
		IsMounted = Mounting;
		anim.SetBool("BeRiding",Mounting);
		
		if (IsMounted)
				creature = FindChildren ("Creature");
		else
			creature=null;
	}
	
	public void Get_Shield(bool GainShield)
	{
		if (GainShield)
			shield = FindChildren ("Shield");
		else
			shield = null;
	}



	void Update()
	{
		if ( Input.GetKeyUp(KeyCode.LeftControl) && shield != null)
		{
			if(!ActiveShield) ActiveShield=true;
			else ActiveShield=false;


			shield.GetComponent<Animator> ().SetBool ("ActiveShield", ActiveShield);


			if(ActiveShield)
			{
				float direction=transform.forward.x;
				shield.transform.position= this.transform.position + (new Vector3(direction*5.0f,8.0f,0f));
				shield.transform.localScale= (new Vector3(4.0f,4.0f,4.0f));
			}
			else
			{
				shield.transform.position= this.transform.position + (new Vector3(0f,12f,0f));
				shield.transform.localScale= (new Vector3(1.5f,1.5f,1.5f));
			}
		}
	}
	
	void FixedUpdate() 
	{
		float movHorizontal = Input.GetAxis ("Horizontal")*speed;
		bool movJump = Input.GetKeyUp(KeyCode.Space);
		//float movVertical = Input.GetAxis ("Vertical");
		
		Vector3 targetDirection = new Vector3 (transform.position.x+movHorizontal,transform.position.y,transform.position.z);
		transform.LookAt(targetDirection); 
		
		Vector3 movement = new Vector3 (movHorizontal,rigidbody.velocity.y, 0.0f );
		Vector3 jump = new Vector3(0.0f,2,0.0f);
		rigidbody.velocity = movement;


		//WALK CONTROL
		bool IsWalking = false;
		if (movHorizontal!=0)
			IsWalking = true;

		anim.SetBool("BeWalking",IsWalking);
		if(IsMounted)
			creature.GetComponent<Animator>().SetBool("BeWalking",IsWalking);


		//JUMP CONTROL
		//Change this stuff for wing animations
		if(movJump && Jumps > 0)
		{
			//float jumpMovement = Input.GetAxis("Jump");
			Jumps--;
			rigidbody.velocity =(jump*jumpStrength);
			//rigidbody.velocity = jump*jumpStrength;
			
			anim.SetBool("BeJump",true);
		}
		else
			anim.SetBool("BeJump",false);
			
	}

	void OnCollisionEnter(Collision collision)
	{
		//Restart Jumps
		if (collision.gameObject.tag == "Floor") 
			Jumps = 3;

	}








}
