using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

		void OnMouseEnter()
	{
		transform.localScale *= 1.2f;
	}

	void OnMouseExit()
	{
		transform.localScale *= 0.835f;
	}

	void OnMouseDown()
	{
		transform.localScale *= 0.9f;
	}

	void OnMouseUp()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
