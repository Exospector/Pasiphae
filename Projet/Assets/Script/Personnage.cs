using UnityEngine;
using System.Collections;

public class Personnage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Deplacement ();
	}
	void Deplacement(){
		Vector3 vec;
		if (transform.position.z < 0 || transform.position.z > 0) {
			vec=transform.position;
			vec.z=0;
			transform.position=vec;		
		}
		if(Input.GetKey("left")){
			vec=transform.localPosition;
			vec.x-=1;
			transform.localPosition=vec;
		}
		else if(Input.GetKey("right")){
			vec=transform.localPosition;
			vec.x+=1;
			transform.localPosition=vec;
		}
	}
}
