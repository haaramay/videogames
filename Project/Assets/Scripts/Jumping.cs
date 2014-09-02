using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {
	
	// Use this for initialization
	public float jumpStrength;
	private int Jumps;

	
	private Animator anim;

	void Start () {
		Jumps = 3;
		anim = GetComponent<Animator> ();

		//Physics.gravity = new Vector3 (0,-40F,0);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) && Jumps > 0)
		{
			Jumps--;
			Vector3 jump = new Vector3(0.0f,jumpStrength,0.0f);
			rigidbody.velocity = jump*jumpStrength;

			anim.SetBool("BeJump",true);

		}
		else
			anim.SetBool("BeJump",false);

	}
	
	void OnCollisionEnter(Collision collision)
	{
		Jumps = 3;
	}
}
