using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPost : MonoBehaviour
{
	// This script is used on the endpoint that the player must reach

	SceneManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("Player"))
		{

		}
	}
}
