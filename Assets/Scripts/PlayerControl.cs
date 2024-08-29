using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float speed = 5f;
	public float backSpeed = 2f;
	public bool moving = true;
	public bool backMoving = false;
	public bool rotating = false;
	public Slider control;
	public GameObject cube;
	public GameObject cubeDownside;
	float ySize;
	float zsize;
	public GameObject pillar;
	float distance;
	float length;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		pillar = FindClosestPillar ();
		distance = pillar.transform.position.x - transform.position.x;
		length = pillar.transform.position.x - transform.position.x;
		Vector3 pillarPos = new Vector3 (pillar.transform.position.x, transform.position.y, transform.position.z);
		if (distance < 55f && distance > 0f) {

			cube.SetActive (true);
			cubeDownside.SetActive (true);

			cube.transform.position = pillarPos;
			cube.transform.localScale = new Vector3(cube.transform.localScale.x, transform.localScale.y, transform.localScale.z);

			cubeDownside.transform.position = new Vector3 (transform.position.x, cubeDownside.transform.position.y, transform.position.z);
			cubeDownside.transform.localScale = new Vector3 (length, 0.1f, transform.localScale.z);
		} else {

			cube.SetActive (false);
			cubeDownside.SetActive (false);

		}

		if (moving && !rotating) {
			FrontMove ();
		} else {
			StartCoroutine (ReturnToFrontMove());
		}

		if(backMoving)
		{
			BackMove ();
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			if(gameObject.transform.localScale.y < 3f)
			{
				float ySize = gameObject.transform.localScale.y;
				float zsize = gameObject.transform.localScale.z;
				ySize += 0.1f;
				zsize -= 0.1f;
				gameObject.transform.localScale = new Vector3 (transform.localScale.x, ySize, zsize);
			}
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			if(gameObject.transform.localScale.z < 3f)
			{
				float ySize = gameObject.transform.localScale.y;
				float zsize = gameObject.transform.localScale.z;
				ySize -= 0.1f;
				zsize += 0.1f;
				gameObject.transform.localScale = new Vector3 (transform.localScale.x, ySize, zsize);
			}
		}
			

			ySize = gameObject.transform.localScale.y;
			zsize = gameObject.transform.localScale.z;


			ySize = 1f + control.value + control.value;
			zsize = 3f - control.value - control.value;

			gameObject.transform.localScale = new Vector3 (transform.localScale.x, ySize, zsize);
	}

	public void FrontMove()
	{
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	public void BackMove()
	{
		transform.Translate (Vector3.left * Time.deltaTime * backSpeed);
	}

	IEnumerator ReturnToFrontMove()
	{
		yield return new WaitForSeconds (2f);
		moving = true;
		backMoving = false;
	}

	public GameObject FindClosestPillar()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}
