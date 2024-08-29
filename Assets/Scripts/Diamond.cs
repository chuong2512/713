using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			int diamo = PlayerPrefs.GetInt ("Diamonds", 0);
			int currentDiamond = PlayerPrefs.GetInt ("Current Diamond", 0);
			diamo += 1;
			currentDiamond += 1;
			PlayerPrefs.SetInt ("Diamonds", diamo);
			PlayerPrefs.SetInt ("Current Diamond", currentDiamond);
			Destroy (gameObject);
		}
	}
}
