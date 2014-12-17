using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
	float rightBound = 50f;
	float leftBound = -50f;
	float topBound = 20f;
	float bottomBound = -20f;

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		/*if((Input.mousePosition.x > leftBound + Screen.width/2) && (Input.mousePosition.x < rightBound + Screen.width/2) && (Input.mousePosition.y < topBound + Screen.height/2) && (Input.mousePosition.y > bottomBound + Screen.height/2))
			GetComponent<Transform>().position = new Vector3(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2, -10.0f);
		else if(Input.mousePosition.x > rightBound + Screen.width/2)
			GetComponent<Transform>().position = new Vector3(rightBound, Input.mousePosition.y - Screen.height/2, -10.0f);
		else if(Input.mousePosition.x < leftBound + Screen.width/2)
			GetComponent<Transform>().position = new Vector3(leftBound, Input.mousePosition.y - Screen.height/2, -10.0f);
		else if(Input.mousePosition.y > topBound + Screen.height/2)
			GetComponent<Transform>().position = new Vector3(Input.mousePosition.x - Screen.width/2, topBound, -10.0f);
		else if(Input.mousePosition.y < bottomBound + Screen.height/2)
			GetComponent<Transform>().position = new Vector3(Input.mousePosition.x - Screen.width/2, bottomBound, -10.0f);*/
	}
}
