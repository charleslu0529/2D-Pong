using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public Text PlayerOneScoreTxt;
	public Text PlayerTwoScoreTxt;
	public Text GameOverText;
	public Text PlayAgainText;
	public Text ExitToMenuText;

	// Use this for initialization
	void Start () {
		GameOverText.text = "";
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerOneScoreTxt.text == "11" || PlayerTwoScoreTxt.text == "11")
		{
			Time.timeScale = 0.0f;

			if(PlayerOneScoreTxt.text == "11")
			{
				GameOverText.text = "Game Over\nPlayer 1 wins!";
			} else if(PlayerTwoScoreTxt.text == "11")
			{
				GameOverText.text = "Game Over\nPlayer 2 wins!";
			}

			PlayAgainText.text = "Play again";
			ExitToMenuText.text = "Press \"Esc\" to exit";
		}
	}
}
