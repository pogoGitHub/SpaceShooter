using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
	public float xMin = -1;
	public float xMax = 1;
	public float yMin = -1;
	public float yMax = 1;
}

public class MovementScript : MonoBehaviour
{
	public enum ControllType {joystick, tilt, keys};
	public ControllType controllType = 0;
	public Joystick moveJoystick;

	public float speed;
	public Boundary boundary;

	private float moveHorizontal = 0.0f;
	private float moveVertical = 0.0f;

	void Start () 
	{
		Vector3 Size = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0));

		float width = Mathf.Floor (Size.x);

		boundary.xMin = 0 - width;
		boundary.xMax = 0 + width;

		Debug.Log ("Screen size: " + Size.x + "x" + Size.y);
	}

	void FixedUpdate ()
	{
		if (controllType == ControllType.joystick) 
		{
			moveHorizontal = moveJoystick.position.x;
			moveVertical = moveJoystick.position.y;
		}
		else if (controllType == ControllType.tilt) 
		{
			moveJoystick.Disable();
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y+0.5f;
		}
		else 
		{
			moveJoystick.Disable();
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}

		
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