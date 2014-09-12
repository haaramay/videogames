using UnityEngine;
using System.Collections;

public class Movement_Control : MonoBehaviour {

	private Animator anim;
	private Animator anim_creature;

	public float speed;
	public float jumpStrength;

	private int Jumps;
	private bool IsMounted;
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Jumps = 3;
		IsMounted = false;
	}
	public void Mount_Creature(bool Mounting)
	{
		IsMounted = Mounting;
		anim.SetBool("BeRiding",Mounting);
		
		if (IsMounted) 
			anim_creature=this.GetComponentsInChildren<Animator> ()[1]; //Find a better way to get child animator
		else
			anim_creature=null;
		
	}
	
	
	void FixedUpdate() 
	{
		float movHorizontal = Input.GetAxis ("Horizontal")*speed;
		bool movJump = Input.GetKeyDown(KeyCode.Space);
		//float movVertical = Input.GetAxis ("Vertical");
		
		Vector3 targetDirection = new Vector3 (transform.position.x+movHorizontal,transform.position.y,transform.position.z);
		transform.LookAt(targetDirection); 
		
		Vector3 movement = new Vector3 (movHorizontal,rigidbody.velocity.y, 0.0f );
		Vector3 jump = new Vector3(0.0f,2,0.0f);
		rigidbody.velocity = movement;
		
		
		if (movHorizontal != 0)
		{
			anim.SetBool("BeWalking",true);
			if(IsMounted)
				anim_creature.SetBool("BeWalking",true);
		}
		else
		{
			anim.SetBool("BeWalking",false);
			if(IsMounted)
				anim_creature.SetBool("BeWalking",false);
		}

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
		if (collision.gameObject.tag == "Floor") 
		{
			Jumps = 3;
		}
	}

}
