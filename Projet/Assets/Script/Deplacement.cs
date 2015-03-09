using UnityEngine;
using System.Collections;

public class Deplacement : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (animator.GetInteger ("Direction")==0) {
			animator.SetFloat("Vitesse",0);

		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float vitesse=0;
		int direction = 0;
		int tempdir = animator.GetInteger ("Direction");
		if(Input.GetKey(KeyCode.Q)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				animator.SetBool ("Course", true);
				vitesse-=0.1f;
			} else {
				animator.SetBool ("Course", false);
			}
			vitesse=animator.GetFloat("Vitesse")-0.1f;
			direction=1;
			animator.gameObject.transform.localEulerAngles=new Vector3(0,180,0);
		}
		else if(Input.GetKey(KeyCode.D)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				animator.SetBool ("Course", true);
				vitesse+=0.1f;
			} else {
				animator.SetBool ("Course", false);
			}
			animator.gameObject.transform.localEulerAngles=new Vector3(0,0,0);
			direction=2;
			vitesse=animator.GetFloat("Vitesse")+0.1f;
		}

		/*if (tempdir != 0 && tempdir != direction) {
			animator.SetInteger ("Direction", 0);
			animator.SetFloat("Vitesse",0);

		} else {
			animator.SetInteger ("Direction", direction);
		}*/
		animator.SetInteger ("Direction", direction);

		if (!animator.GetBool ("Course")) {
			if (vitesse > 20) {
				
				vitesse = 20;
			} else if (vitesse < -20) {
				vitesse = -20;
			}
		} else {
			if (vitesse > 30) {
				vitesse = 30;
			} else if (vitesse < -30) {
				vitesse = -30;
			}
		}
		if (Input.GetKey (KeyCode.Space)) {
			animator.SetTrigger("Saut");
		}
		animator.SetFloat("Vitesse",vitesse);

		animator.gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(vitesse*15,animator.gameObject.transform.position.y),ForceMode2D.Force);

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
