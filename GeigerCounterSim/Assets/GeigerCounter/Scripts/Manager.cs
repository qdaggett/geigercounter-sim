using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used to keep track of important things in the scene like time, radiation, and the game's state

public class Manager : MonoBehaviour
{
	// Object references
	[SerializeField] GameObject player;
	[SerializeField] GameObject counter;
	[SerializeField] TextMeshPro currentRadText;
	[SerializeField] TextMeshPro totalRadText;
	[SerializeField] AudioSource counterSoundSource;
	[SerializeField] AudioClip[] counterSounds;
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
			if (Random.Range(0, 10) > 6 && !counterSoundSource.isPlaying) // Change this to work based on distance from source
			{
				counterSoundSource.clip = counterSounds[Random.Range(0, 5)]; // Plays a random geiger counter sound from array
				counterSoundSource.Play();
			}
				
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

	// Function for updating if the player is within range of a radiation source
	public void IsExposed(bool cond)
	{
		exposed = cond;
	}

	public void GameOver()
	{

	}
}
