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
	[SerializeField] TextMeshPro currentRadText;
	[SerializeField] TextMeshPro totalRadText;
	[SerializeField] AudioSource counterSound;
	// Player motor script

	List<GameObject> radSources; // List of radiation sources
	float exposure;
	float timer; // Timer float 
	bool exposed;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (exposed)
		{
			if (Random.Range(0, 10) > 6 && !counterSound.isPlaying)
				counterSound.Play();
		}
    }

	// Function for updating how much radiation the player has been exposed to
	public void UpdateRadiation(float update)
	{
		exposure += update;
		totalRadText.text = exposure.ToString("F2");
	}

	// Function for updating text element on virtual geiger counter
	public void UpdateCounter(float update)
	{
		currentRadText.text = update.ToString("F2");

	}

	public void IsExposed(bool cond)
	{
		exposed = cond;
	}
}
