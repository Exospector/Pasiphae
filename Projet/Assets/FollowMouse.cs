using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
	float rightBound = 15;
	float leftBound = -15;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.mousePosition.x > leftBound + Screen.width/2 && Input.mousePosition.x < rightBound + Screen.width/2)
			GetComponent<Transform>().Translate(0.5f, 0.0f, .0f);
		else if(Input.mousePosition.x > rightBound)
			GetComponent<Transform>().position = new Vector3(rightBound, 0.0f, -10.0f);
		else if(Input.mousePosition.x < leftBound)
			GetComponent<Transform>().position = new Vector3(leftBound, 0.0f, -10.0f);
	}
}
