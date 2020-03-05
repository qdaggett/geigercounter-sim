using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Script for radiation pocket

public class RadiationSource : MonoBehaviour
{

	[SerializeField] GameObject counter;
	[SerializeField] TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float distance = Vector3.Distance(this.transform.position, counter.transform.position);

		text.text = distance.ToString("F2");
    }
}
