using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgainButtonScript : MonoBehaviour {
	public Button TargetButton;

	// Use this for initialization
	void Start () {
		Button btn = TargetButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
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
}
