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

	// Debug du projeté orthogonal de la caméra
	//private GameObject marqueurDebug;

	void Awake()
	{
		distance = 0;
		target = GameObject.FindGameObjectWithTag("Player");
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

		// Debug du projeté orthogonal de la caméra
		//marqueurDebug = Instantiate(Resources.Load("Prefab/MarqueurDebug")) as GameObject;
		//marqueurDebug.transform.position = target.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		// Debug du projeté orthogonal de la caméra
		/*marqueurDebug.transform.position = new Vector3(target.transform.position.x + (Input.mousePosition.x - Screen.width/2)/100,
		                                               target.transform.position.y + (Input.mousePosition.y - Screen.height/2)/100,
		                                               0.0f);*/

		transform.position = new Vector3(target.transform.position.x + (Input.mousePosition.x - Screen.width/2)/100,
		                                 target.transform.position.y + (Input.mousePosition.y - Screen.height/2)/100,
		                                 transform.position.z);
	}
}
