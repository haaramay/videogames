using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {


	public int max_health;
	private int health_points;


	void Start()
	{
		health_points = max_health;
	}

	// Update is called once per frame
	void Update () 
	{
		if (health_points == 0) 
		{
			//INSERT HERE DEAD ANIMATION STUFF
		}

	}


	public void InputDamage(int damage)
	{
		health_points -= damage;
		if (health_points <= 0)
			health_points = 0;
	}
	public int DisplayHealth()
	{
		return health_points;
	}


}
