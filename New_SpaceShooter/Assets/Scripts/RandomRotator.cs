using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble; // rotation speed 
	void Start () {
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble; // ROTATION ON AXIS X AND Y MUST BE FREEZED

	}
	

}
