using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Script for radiation pocket

public class RadiationSource : MonoBehaviour
{
	// Component references
	SceneManager manager;
	SphereCollider c_collider;

	public float radius;
	public float[] exposureConstantList = { 12.838f, 1.03f, 0.720f, 1.48f, 14.9f, 3.400f, 1.46f, 4.69f, 8.25f };
	public float activity;
	public string[] elementList = { "cobalt", "molybdenum", "technetium", "palladium", "silver", "caesium", "iodine", "iridium", "radium" };
	public string element;
	public float exposureConstant;

    // Start is called before the first frame update
    void Start()
    {
		manager = GameObject.Find("Manager").GetComponent<SceneManager>();
		c_collider = GetComponent<SphereCollider>();
		exposureConstant = exposureConstantList[0];
		element = elementList[0];
		activity = 2.0f;
    }

	// Functions for controlling geiger counter sound in manager
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("Player"))
		{
			manager.IsExposed(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.transform.CompareTag("Player"))
		{
			manager.IsExposed(false);
			manager.UpdateCounter(0);
		}
	}

	// Function for handling player dosage
	private void OnTriggerStay(Collider collider)
	{
		// If the player is within the radius
		if(collider.transform.CompareTag("Player"))
		{
			// Set up variables for exposure rate formula
			radius = Vector3.Distance(transform.position, collider.transform.position);

			// Calculate radiation exposure
			// Radiation exposure rate = exposureConstant * activity / radius^2
			float exposureRate = exposureConstant * activity / Mathf.Pow(radius, 2);

			// Apply rad exposure to player
			manager.UpdateRadiation(exposureRate);
			manager.UpdateCounter(exposureRate);

		}
	}
}
