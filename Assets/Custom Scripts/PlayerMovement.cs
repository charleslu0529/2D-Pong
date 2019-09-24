using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

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
	float jumpTime = 0.5f;
	
	// public Vector3 ForwardJump = (0.5,0,0);
	
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
		
		//move up when w is pressed, and move down when s is pressed
		if (Input.GetKey("w"))
		{
			if(TransformObject.position.y >= 3.41 || Input.GetKey("s"))
			{
				movement = 0;
			}
			else
			{
				movement = 1 * MovementSpeed;
			}
		}else if (Input.GetKey("s"))
		{
			if(TransformObject.position.y <= -3.41 || Input.GetKey("w"))
			{
				movement = 0;
			}
			else
			{
				movement = -1 * MovementSpeed;
			}
		}

		// supa saiyajin mode when space is pressed
		if(Input.GetKeyDown("space") && specialOn == false)
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

		if (Input.GetKey("escape"))
		{
			SceneManager.LoadScene("MainMenu");
		}

		if(specialOn)
		{
			movement = movement * 2;
			SSJTime -= Time.deltaTime;
			
			SSJTimeText.text = SSJTime.ToString();

			/*if((PlayerBody.position.x - BallBody.position.x) < 0.5f)
			{
				TransformObject.Translate(0.5f, 0,0,jumpTime * Time.deltaTime);
			}*/
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
