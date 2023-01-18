using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyMoveStaticSheep: MonoBehaviour
{
	[SerializeField]
	private string filterTag = "Animal";
	[SerializeField]
	private GameObject sheep;
	[SerializeField]
	private float speed;
	[SerializeField]
	private bool toggle = false;
	[SerializeField]
	private float degreesPerSecond = 0;
	[SerializeField]
	private float MovementPerSecond = 2F;
	[SerializeField]
	private float angle;
	[SerializeField]
	private float minRandomNumber = 0;
	[SerializeField]
	private float maxRandomNumber = 100;
	[SerializeField]
	private float RandomNumber;
	[SerializeField]
	private float MovementNumber;
	[SerializeField]
	private int iteration = 2; // for switch case function down below
	// Start is called before the first frame update
	void Start()
	{
		toggle = true;
	}

	// Update is called once per frame
	void Update()
	{
		rotateAnimation();
	}
	
	// START ANIMATION
	void startanimation()
	{
		//RandomNumber = float randomNumber = Random.Range(0, 100);
		//degreesPerSecond = 20;
		MovementNumber = MovementPerSecond * -0.01F;
		transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
		transform.Translate(new Vector3(0, MovementNumber, 0) * Time.deltaTime);
	}

	private void rotateAnimation()
	{

		angle += degreesPerSecond * Time.deltaTime;
		if (toggle == true)
		{
			startanimation();
			
			checkAngle();
			
		}
		else
		{
			angle = 0;
		}
		
		
	}
	
	private void checkMovement()
	{
		if (MovementNumber >= 5)
		{
			//speed of rotation
			MovementPerSecond = -1;
		}
		else if (angle <= -2)
		{
			MovementPerSecond = 1;
		}
		else
		{
		 //Debug.Log("Something has gone wrong in Start animation sheep");
		}
	}
	
	private void checkAngle() // Check Angle against a random number between 1 and 100 (this will be the angle)
	{
		
		if (angle >= RandomNumber)
		{
			//speed of rotation
			degreesPerSecond = -5;
		}
		else if (angle <= 0)
		{
			//changes rotation to random one
			RandomNumber = Random.Range(minRandomNumber, maxRandomNumber); //changes rotation to random one
			//speed of rotation
			degreesPerSecond = 5;
		}
		else
		{
			//Debug.Log("Something has gone wrong in Start animation sheep");
		}
	}
}
