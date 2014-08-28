using UnityEngine;
using System.Collections;

public class DirectMove : MonoBehaviour 
{
	public float moveSpeed = 10;

	void Start ()
	{
		rigidbody.velocity = -transform.up * moveSpeed;
	}
}
