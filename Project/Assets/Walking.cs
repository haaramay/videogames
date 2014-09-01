using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {


	private Animator anim;
	public bool change;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("BeWalking", change);
	}
}
