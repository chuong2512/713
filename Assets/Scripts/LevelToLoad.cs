using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelToLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene()
	{
		int randomNo = Random.Range (1, 10);
		SceneManager.LoadScene (randomNo);
	}
}
