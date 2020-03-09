using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used to keep track of important things in the scene like time, radiation, and the game's state

public class SceneManager : MonoBehaviour
{
	// Object references
	[SerializeField] GameObject player;
	[SerializeField] GameObject counter;
	[SerializeField] TextMeshPro text;
	// Player motor script

	List<GameObject> radSources; // List of radiation sources
	float exposure;
	float timer; // Timer float 

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Function for updating how much radiation the player has been exposed to
	public void UpdateRadiation(float update)
	{
		exposure += update;
	}

	// Function for updating text element on virtual geiger counter
	public void UpdateCounter(float update)
	{
		text.text = update.ToString();
	}
}
