using UnityEngine;
using System.Collections;

public class MovementBolt : MonoBehaviour {

	public float speed = 10;

	void Start () {
		rigidbody.velocity = transform.up * speed;
	}
	

}
