using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return; // ends the execution of a function
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
