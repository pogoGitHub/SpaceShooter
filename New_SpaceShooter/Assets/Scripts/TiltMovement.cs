using UnityEngine;
using System.Collections;

public class TiltMovement : MonoBehaviour 
{
	public float movementSpeed = 5;
	public Boundary boundary;
	
	void Update () {

		Vector3 movement = new Vector3 (Input.acceleration.x, Input.acceleration.y+0.5f, 0.0f);
		rigidbody.velocity = movement * movementSpeed;
		
		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);
	}
}
