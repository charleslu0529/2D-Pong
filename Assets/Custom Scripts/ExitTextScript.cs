using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
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
		Application.Quit();
	}
}
