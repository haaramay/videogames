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
	
	
	private int Lock;
	private bool Lerping;
	private Vector3 Lerp_Position;
	
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Jumps = 3;
		IsMounted = false;
		ActiveShield = false;
		
		Lock = 0;
		Lerping = false;
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
	
	public int Get_Lock()
	{
		return Lock;
	}
	public void Set_Lock(int lock_time)
	{
		Lock = lock_time;
	}
	public void Update_Lock(int update)
	{
		Lock = Lock + update;
	}
	
	
	public void Mount_Creature()
	{
		IsMounted = true;
		anim.SetTrigger ("Mount");
		creature = FindChildren ("Creature");

		float height = 4.8f;
		Lerp_Position= creature.transform.position + (new Vector3 (0f, height, 0f));
		Lerping = true;
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
		//SHIELD POSITIONING
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

				shield.transform.position= this.transform.position + (new Vector3(0f,12f,0f))-this.transform.forward*2;
				shield.transform.localScale= (new Vector3(1.5f,1.5f,1.5f));
			}
		}

		//MAKE THIS STUFF ELEGANT
		if(Lerping)
		{
			creature.transform.parent=null;
			transform.position=Vector3.Lerp(transform.position,Lerp_Position,Time.deltaTime*2.0f);
			creature.transform.parent=this.transform;
			if( Vector3.Distance(transform.position,Lerp_Position)<0.1)
			{
				transform.position=Lerp_Position;
				Lerping=false;
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
		Vector3 jump = new Vector3(movHorizontal,jumpStrength,0.0f);
		if(Lock <= 50)
			rigidbody.velocity = movement;
		
		
		//WALK CONTROL
		bool IsWalking = false;
		if (movHorizontal!=0 && Lock <= 50)
			IsWalking = true;
		
		anim.SetBool("IsWalking",IsWalking);
		if(IsMounted)
			creature.GetComponent<Animator>().SetBool("IsWalking",IsWalking);
		
		
		//JUMP CONTROL
		//Change this stuff for wing animations
		if(movJump && Jumps > 0 && Lock<=50)
		{
			//float jumpMovement = Input.GetAxis("Jump");
			Jumps--;
			rigidbody.velocity =(jump);
			//rigidbody.velocity = jump*jumpStrength;
			
			anim.SetTrigger("Jump"); //Jumps if is on the ground. Flaps if it's on air
		}
		
		//LOCK
		if(Lock>0)
			Lock--;
	}
	void OnCollisionEnter(Collision collision)
	{
		//Restart Jumps
		if (collision.gameObject.tag == "Floor") 
		{
			anim.SetBool ("IsFlying", false);
			Jumps = 3;
		}
	}

	//Called at the end of Jump animation
	void Set_IsFlying()
	{
		anim.SetBool ("IsFlying", true);
	}

	

}
