using UnityEngine;
using System.Collections;

public class ActivateLever : MonoBehaviour {

	public GameObject Gate;
	private GateControl gate_control;

	private bool LeverActivated;


	private Quaternion UnactiveRotation;
	private Quaternion ActiveRotation;
	private Quaternion TargetRotation;
	private float rotate_speed;

	// Use this for initialization
	void Start () 
	{
		LeverActivated = false;
		gate_control = Gate.GetComponent<GateControl> ();

		//Determinate rotations
		UnactiveRotation = transform.rotation;
		transform.Rotate (45f, 0f, 0f);
		ActiveRotation = transform.rotation;
		transform.rotation = UnactiveRotation;
		TargetRotation = UnactiveRotation;
		rotate_speed = 3.0f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.rotation!= TargetRotation)
			transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, rotate_speed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Player" && !LeverActivated) 
		{
			LeverActivated=true;
			gate_control.OpenDoor(true);
			TargetRotation=ActiveRotation;
		}
		else if (collision.gameObject.tag == "Player" && LeverActivated) 
		{
			LeverActivated=false;
			gate_control.OpenDoor(false);
			TargetRotation=UnactiveRotation;
		}

	}

}
