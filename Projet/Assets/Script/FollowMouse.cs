using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
	float rightBound = 50f;
	float leftBound = -50f;
	float topBound = 25f;
	float bottomBound = -25f;

	private GameObject target;
	private float distance;

	// Use this for initialization
	void Start()
	{
		distance = 0;
		target = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		/*transform.position = new Vector3(Mathf.Clamp((Input.mousePosition.x - Screen.width/2), leftBound, rightBound),
		                                 Mathf.Clamp((Input.mousePosition.y - Screen.height/2), bottomBound, topBound),
		                                 -10.0f);*/

		RaycastHit vHit = new RaycastHit();
		Ray vRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		Physics.Raycast(vRay, out vHit, 50);

		distance = Vector2.Distance(target.transform.position, vHit.point);
		//Debug.Log (distance);

		if(distance != 0)
		{
			transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
		}
		else
		{

		}
	}
}
