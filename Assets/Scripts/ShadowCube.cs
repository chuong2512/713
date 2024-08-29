using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCube : MonoBehaviour {

	public GameObject shadowObject;

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
			GameObject pillar = other.gameObject.GetComponent<PlayerControl> ().pillar;
			GameObject shadow = pillar.transform.Find ("Shadow Pillar").gameObject;
			shadowObject = shadow;
			shadow.SetActive (true);
		}
	}
}
