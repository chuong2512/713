using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelowBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		Destroy (other.gameObject);

	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log (other.gameObject.name);
		Destroy (other.gameObject);
	}
}
