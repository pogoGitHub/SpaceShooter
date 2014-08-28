using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
	public float speed;
	public Boundary boundary;

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