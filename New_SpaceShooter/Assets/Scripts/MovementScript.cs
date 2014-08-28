using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary // values for setting scale of boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class MovementScript : MonoBehaviour
{
	public float speed;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
	
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3 // setting the actual boundary for the player, by clamping him in specific values of xMin, xMax, yMin, yMax
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
				0.0f 
			);
	}
}