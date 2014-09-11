using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {


	public int max_health;
	private int health_points;
	public GameObject health_display;


	void Start()
	{
		health_points = max_health;
	}





	public void InputDamage(int damage)
	{
		health_points -= damage;
		for (int i=0; i<damage; i++)
			RemoveHearth ();
			
		if (health_points <= 0) 
		{
			health_points = 0;
			//INSERT DEAD ANIMATION HERE
		}
	}
	private void RemoveHearth()
	{
		if (health_display.transform.childCount > 0) 
		{
			GameObject hearth = health_display.transform.GetChild (health_display.transform.childCount - 1).gameObject;
			hearth.transform.parent=null;
			Destroy (hearth);

		}
	}


}
