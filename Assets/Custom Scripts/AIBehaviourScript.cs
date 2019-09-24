using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBehaviourScript : MonoBehaviour {

	public float speed = 0.175f;
	public Rigidbody Target;
	public Rigidbody Self;
	public Transform TransformObject;
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
		float distance = Target.position.y - transform.position.y;
		float movement = 0;

		float ssjChance = Random.Range(0, 100f);


	    if(distance > 1f && Target.velocity.x > 0){

	        if(TransformObject.position.y >= 3.41)
			{
				movement = 0;
			}
			else
			{
				movement = 1 * speed;
			}
	    }

	    if(distance < 1f && Target.velocity.x > 0){
	       	if(TransformObject.position.y <= -3.41)
			{
				movement = 0;
			}
			else
			{
				movement = -1 * speed;
			}
	    }

	    if(ssjChance == Random.Range(80f, 200f))
	    {
	    	if(specialOn == false)
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

	    if((Self.position.x - Target.position.x) < 3.5)
		{
			TransformObject.Translate(0, movement,0);
		}
			
	}

	void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
     		GetComponent<AudioSource> ().Play ();     
    }
	    
}
