using UnityEngine;
using System.Collections;

public class LaunchSphere : MonoBehaviour {

	public GameObject Sphere;
	public float wait_time;
	
	private float launch_time;
	private float offset=-5.0f;
	Vector3 a = new Vector3(0.0f,0.0f,-30.0f);

	// Use this for initialization
	void Start () {
		launch_time = Time.time+wait_time;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (launch_time <= Time.time) 
		{
			Instantiate(Sphere,transform.position,transform.rotation);
			launch_time = Time.time+wait_time;
		}
	
	}
}
