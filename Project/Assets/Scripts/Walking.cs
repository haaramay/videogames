using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	
	
	private Animator anim;
	private Animator anim_creature;
	
	private bool IsMounted;
	
	public float speed;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		IsMounted = false;
	}
	public void Mount_Creature(bool Mounting)
	{
		IsMounted = Mounting;
		anim.SetBool("BeRiding",true);
	}
	
	
	void FixedUpdate() 
	{
		float movHorizontal = Input.GetAxis ("Horizontal")*speed;
		//float movVertical = Input.GetAxis ("Vertical");
		
		Vector3 targetDirection = new Vector3 (transform.position.x+movHorizontal,transform.position.y,transform.position.z);
		transform.LookAt(targetDirection); 
		
		Vector3 movement = new Vector3 (movHorizontal,rigidbody.velocity.y, 0.0f );
		rigidbody.velocity = movement;
		
		if (IsMounted) 
		{
			Animator[] child_anim=this.GetComponentsInChildren<Animator> ();
			anim_creature=child_anim[1];//FIND A BETTER WAY TO GET THE CREATURE ANIMATOR
		}
		
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
		
	}
}
