using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour {

	public Rigidbody BallRigidBody;
	public Rigidbody PlayerOneRigidBody;
	public Rigidbody PlayerTwoRigidBody;
	public Transform TransformObject;
	public Text PlayerOneScore;
	public Text PlayerTwoScore;
	float velocityX;
	float velocityY;
	public float SpeedX = 8f;
	public float SpeedY = 4f;
	int scorePOne;
	int scorePTwo;

	

	// Use this for initialization
	void Start () {

		scorePOne = 0;
		scorePTwo = 0;

		/*playerOne = gameObject.GetComponent("PlayerMovement.cs");
		playerTwo = gameObject.GetComponent("PlayerTwoMovement.cs");*/

		startBall();
		
	}
	
	// Update is called once per frame
	void Update () {
		

		//curve ball mechanism
		if(BallRigidBody.velocity.x > 0)
		{
			if((BallRigidBody.velocity.y/BallRigidBody.velocity.x) > 1)
			{
				BallRigidBody.AddForce(new Vector3(5f, -5f,0));
			}
			else if((BallRigidBody.velocity.y/BallRigidBody.velocity.x) < -1)
			{
				BallRigidBody.AddForce(new Vector3(5f, 5f,0));
			}
		} else if(BallRigidBody.velocity.x < 0)
		{
			if((BallRigidBody.velocity.y/BallRigidBody.velocity.x) > 1)
			{
				BallRigidBody.AddForce(new Vector3(-5f, 5f,0));
			}
			else if((BallRigidBody.velocity.y/BallRigidBody.velocity.x) < -1)
			{
				BallRigidBody.AddForce(new Vector3(-5f, -5f,0));
			}
		}

		if(TransformObject.position.y < -5 || TransformObject.position.y > 5)
		{
			TransformObject.position = new Vector3(0, 0, 0);
			startBall();
		}
		
	}

	void OnCollisionEnter(Collision exampleCol)
	{

		if (exampleCol.collider.tag == "Player 1 wall")
     
		{
			/*if(gameObject.GetComponent("PlayerMovement.cs").specialOn)
			{
				scorePTwo = scorePTwo + 3;
			}
			else
			{
				scorePTwo = scorePTwo + 1;
			}*/
			
			scorePTwo = scorePTwo + 1;
			updateScore(scorePTwo, PlayerTwoScore);

			TransformObject.position = new Vector3(0, 0, 0);
		    startBall();
   		}

   		else if (exampleCol.collider.tag == "Player 2 wall")
     
		{

			/*if()
			{

			}*/
			scorePOne = scorePOne + 1;
			updateScore(scorePOne, PlayerOneScore);

			TransformObject.position = new Vector3(0, 0, 0);
			startBall();
		     
   		}

   		/*if(exampleCol.collider.tag == "Wall Top")
   		{
   			if(BallRigidBody.velocity.y < 10f)
   			{
   				BallRigidBody.AddForce(new Vector3(0, Random.Range(-60f, -55f),0));
   			}
   		}
   		else if(exampleCol.collider.tag == "Wall Bottom")
   		{
   			if(BallRigidBody.velocity.y > -10f)
   			{
   				BallRigidBody.AddForce(new Vector3(0, Random.Range(55f, 60f),0));
   			}
   		}*/

	}

	void startBall()
	{
		int randomX;
		int randomY;

		do
		{
			randomX = Random.Range(-1, 1);
			randomY = Random.Range(-1, 1);
		}while(randomX == 0 || randomY == 0);

		

		float randomYPosition = Random.Range(-2, 2);

		TransformObject.position = new Vector3(0,randomYPosition,0);

		velocityX = randomX * SpeedX;

		velocityY = randomY * SpeedY;

		BallRigidBody.velocity = new Vector3(velocityX, velocityY, 0);
	}

	void updateScore(int score, Text playerScoreText )
	{
		playerScoreText.text = score.ToString();
	}

}
