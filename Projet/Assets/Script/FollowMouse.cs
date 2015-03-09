using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
	float rightBound = 50f;
	float leftBound = -50f;
	float topBound = 25f;
	float bottomBound = -25f;

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector3(Mathf.Clamp((Input.mousePosition.x - Screen.width/2), leftBound, rightBound),
		                                 Mathf.Clamp((Input.mousePosition.y - Screen.height/2), bottomBound, topBound),
		                                 -10.0f);
	}
}
