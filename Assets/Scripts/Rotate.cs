using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rotatingAngle = 90f;
	public bool rotating = false;
	public bool moveAgain = false;
	GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(player != null)
		{

			if (rotating) {
				Vector3 to = new Vector3 (0f, rotatingAngle + 1f, 0f);	
				player.GetComponent<PlayerControl> ().moving = false;
				player.transform.eulerAngles = Vector3.Lerp (player.transform.rotation.eulerAngles, to, Time.deltaTime * 10f);
				if (player.transform.eulerAngles.y > rotatingAngle) {
					rotating = false;
				}
				//GameObject.FindGameObjectWithTag("Main Camera").transform.eulerAngles = Vector3.Lerp (GameObject.FindGameObjectWithTag("Main Camera").transform.rotation.eulerAngles, to, Time.deltaTime * 5f);

				//rotating = false;

			} else {

				player.GetComponent<PlayerControl> ().rotating = false;
				player.GetComponent<PlayerControl> ().moving = true;
			}

		}

		
	}

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag == "Player")
		{
			rotating = true;
			player = other.gameObject;
			player.GetComponent<PlayerControl> ().rotating = true;

		}

	}
}
