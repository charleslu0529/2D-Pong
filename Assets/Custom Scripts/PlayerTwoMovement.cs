using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTwoMovement : MonoBehaviour {

	public Transform TransformObject;
	public Rigidbody PlayerBody;
	public Rigidbody BallBody;
	public float MovementSpeed = 0.175f;
	//public float JumpDistance;
	public AudioClip CollisionSound;
	int special;
	public bool specialOn = false;
	public float SSJTime = 10.0f;
	public Text SSJText;
	public Text SSJTimeText;
	float timeLeft;
	
	// Use this for initialization
	void Start () {

		special = 2;
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = CollisionSound;

		timeLeft = SSJTime;

	}
	
	// Update is called once per frame
	void Update () {

		float movement = 0;		
		
		if (Input.GetKey("up"))
		{
			if(TransformObject.position.y >= 3.41 || Input.GetKey("down"))
			{
				movement = 0;
			}
			else
			{
				movement = 1 * MovementSpeed;
			}
		}else if (Input.GetKey("down"))
		{
			if(TransformObject.position.y <= -3.41 || Input.GetKey("up"))
			{
				movement = 0;
			}
			else
			{
				movement = -1 * MovementSpeed;
			}
		}
		else if(Input.GetKey("up") && Input.GetKey("down"))
		{
			movement = 0;
		}

		if (Input.GetKey("escape"))
		{
			SceneManager.LoadScene("MainMenu");
		}

		if(Input.GetKeyDown(KeyCode.Keypad0) && specialOn == false)
		{
			
			if(special > 0)
			{
				specialOn = true;
				special = special - 1;
			}
			if(special == 1)
			{
				SSJText.text = "超";
			}
			else if (special == 0)
			{
				SSJText.text = "";
			}
			
		}

		if(specialOn)
		{
			movement = movement * 2;
			SSJTime -= Time.deltaTime;
			
			SSJTimeText.text = SSJTime.ToString();
		}

		if(SSJTime < 0)
		{
			specialOn = false;
			SSJTimeText.text = "";
			SSJTime = timeLeft;
		}

		TransformObject.Translate(0, movement,0);
	}

	void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
     		GetComponent<AudioSource> ().Play ();     
    }
}
