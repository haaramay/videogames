using UnityEngine;
using System.Collections;

public class ActivateTrapSet : MonoBehaviour {

	// Use this for initialization

	public GameObject TrapSet;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
			foreach (TrapMovement trap in TrapSet.GetComponentsInChildren<TrapMovement>())
				trap.enabled = true;
		

	}

}
