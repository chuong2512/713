using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player")
		{
			player = other.gameObject;

			if(other.gameObject.GetComponent<PlayerControl> ().speed >= 0f)
			{
				other.gameObject.GetComponent<PlayerControl> ().speed -= 0.1f;
			}

			StartCoroutine (WaitForGameWin());


		}
	}

	IEnumerator WaitForGameWin()
	{
		yield return new WaitForSeconds (1.5f);
		player.GetComponent<PlayerControl> ().speed = 0f;
		GameObject.Find ("Menu").GetComponent<Menu> ().GameWon ();
		GameObject.Find ("Menu").GetComponent<Menu> ().Level ();
	}
}
