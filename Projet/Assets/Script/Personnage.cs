using UnityEngine;
using System.Collections;

public class Personnage : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Deplacement ();
	}
	void Deplacement(){
		float vitesse=0;
		int direction = 0;
		int tempdir = anim.GetInteger ("Direction");
		if(Input.GetKey(KeyCode.Q)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.SetBool ("Course", true);
				vitesse-=0.1f;
			} else {
				anim.SetBool ("Course", false);
			}
			vitesse=anim.GetFloat("Vitesse")-0.01f;
			direction=1;
			this.transform.localEulerAngles=new Vector3(0,180,0);
		}
		else if(Input.GetKey(KeyCode.D)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.SetBool ("Course", true);
				vitesse+=0.1f;
			} else {
				anim.SetBool ("Course", false);
			}
			this.transform.localEulerAngles=new Vector3(0,0,0);
			direction=2;
			vitesse=anim.GetFloat("Vitesse")+0.01f;
		}
		anim.SetInteger ("Direction", direction);
		
		if (!anim.GetBool ("Course")) {
			if (vitesse > 0.3f) {
				
				vitesse = 0.3f;
			} else if (vitesse < -0.3f) {
				vitesse = -0.3f;
			}
		} else {
			if (vitesse > 0.4f) {
				vitesse = 0.4f;
			} else if (vitesse < -0.4f) {
				vitesse = -0.4f;
			}
		}
		if (Input.GetKey (KeyCode.C)) {
			anim.SetBool ("Silencieux", true);
			if (vitesse > 0.2f) {
				vitesse = 0.2f;
			} else if (vitesse < -0.2f) {
				vitesse = -0.2f;
			}
		} else {
			anim.SetBool ("Silencieux", false);
		}
		anim.SetFloat("Vitesse",vitesse);

		this.transform.position = new Vector2 (transform.position.x + vitesse, transform.position.y);
		if (Input.GetKey (KeyCode.Space)) {
			anim.SetBool("Saut",true);
		}

	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (anim.GetBool ("Saut")) {
			anim.SetBool ("Saut", false);
		}
	}
}
