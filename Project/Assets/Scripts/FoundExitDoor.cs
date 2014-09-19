using UnityEngine;
using System.Collections;

public class FoundExitDoor : MonoBehaviour {

	public GUIText winText;
	// Use this for initialization
	void Start () {
		
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Win")
		{
			other.gameObject.SetActive(false);
			winText.text = "You Win";
		}
	}

}
