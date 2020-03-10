using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// This script moves the player using input from the touchpad on HTC vive controllers

public class PlayerMotor : MonoBehaviour
{
	// Component references
	CharacterController controller;
	Transform cameraRig;
	Transform head; 

	float sensitivity = 0.1f;
	float maxVel = 3.0f; // The fastest the player will be allowed to travel
	[SerializeField] SteamVR_Action_Boolean movePress = null; // Bool for whether or not the player is touching the touchpad
	[SerializeField] SteamVR_Action_Vector2 moveVal = null; // The input through the touchpad ranges from -1 to 1 in the x and y axes
	float velocity = 0.0f; // Player's current velocity
	float gravity = 9.81f;

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	// Start is called before the first frame update
	void Start()
    {
		cameraRig = SteamVR_Render.Top().origin;
		head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
		HandleHead();
		HandleHeight();
		HandleMovement();
		
    }

	void HandleHead()
	{
		// Current position and rotation
		Vector3 oldPos = cameraRig.position;
		Quaternion oldRot = cameraRig.rotation;

		// Perform rotation
		transform.eulerAngles = new Vector3(0.0f, head.rotation.eulerAngles.y, 0.0f);

		// Restore old position and rotation
		cameraRig.position = oldPos;
		cameraRig.rotation = oldRot;
	}

	void HandleMovement()
	{
		// Get movement orientation
		Vector3 rotationEuler = new Vector3(0, transform.eulerAngles.y, 0);
		Quaternion rotation = Quaternion.Euler(rotationEuler);
		Vector3 movementVector = Vector3.zero;

		// If the player is not touching the touchpad, don't move
		if (movePress.GetStateUp(SteamVR_Input_Sources.Any)) 
			velocity = 0;

		if(movePress.state)
		{
			// Adding velocity to the player
			velocity += moveVal.axis.y * sensitivity;
			velocity = Mathf.Clamp(velocity, -maxVel, maxVel);

			// Making the sure player moves forward in the direction they are looking
			movementVector += rotation * (velocity * Vector3.forward) * Time.deltaTime;

		}

		// Process gravity for the player
		movementVector.y -= gravity * Time.deltaTime; 

		// Apply movement vector to controller
		controller.Move(movementVector);

	}

	void HandleHeight()
	{
		// Get head position in local space
		float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
		controller.height = headHeight;

		// Halve the value
		Vector3 newCenter = Vector3.zero;
		newCenter.y = controller.height / 2;
		newCenter.y += controller.skinWidth;

		// Move capsule in local space
		newCenter.x = head.localPosition.x;
		newCenter.z = head.localPosition.z;

		newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

		// Apply new center to character controller
		controller.center = newCenter;
	}
}
