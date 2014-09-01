using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	
	
	private Animator anim;
	public float speed;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	
	
	
	
	void FixedUpdate() 
	{
		float movHorizontal = Input.GetAxis ("Horizontal")*speed;
		//float movVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movHorizontal,rigidbody.velocity.y, 0.0f );
		rigidbody.velocity = movement;
		if (movHorizontal != 0)
			anim.SetBool("BeWalking",true);
		else
			anim.SetBool("BeWalking",false);
		
	}
}
