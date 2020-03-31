using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPost : MonoBehaviour
{
	// This script is used on the endpoint that the player must reach


	[SerializeField] GameObject winText;
	//SceneManager manager;

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
			winText.SetActive(true);
			SceneManager.LoadScene(0);
		}
	}
}
