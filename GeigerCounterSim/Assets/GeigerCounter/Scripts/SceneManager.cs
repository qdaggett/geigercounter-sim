using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to keep track of important things in the scene like time, radiation, and the game's state

public class SceneManager : MonoBehaviour
{
	// Object references
	[SerializeField] GameObject player;
	// Player motor script

	List<GameObject> radSources; // List of radiation sources
	float timer; // Timer float 

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
