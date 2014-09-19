using UnityEngine;
using System.Collections;

public class LaunchArrow : MonoBehaviour {

	// Use this for initialization
	public GameObject Arrow;
	public float wait_time;

	private float launch_time;
	private float offset=5.0f;

	void Start () {
		launch_time = Time.time+wait_time;
	}
	
	// Update is called once per frame
	void Update () {
		if (launch_time <= Time.time) 
		{
			Instantiate(Arrow,transform.position+transform.forward*offset,transform.rotation);
			launch_time = Time.time+wait_time;
		}

	}
}
