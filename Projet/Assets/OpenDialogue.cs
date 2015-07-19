using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace AssemblyCSharp{
public class OpenDialogue : StateMachineBehaviour {
		string[] lines;
		GameObject box=null;
		int compteur=0;
		public static bool enter=false;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if (!enter) {
				compteur=0;
				Dialogue dial = new Dialogue ();
				lines = dial.open ("Dialogue");
				box = (GameObject)Instantiate (Resources.Load ("Prefab/Dialog"));
				string[] info = dial.ReadLine (lines [compteur]);
				compteur++;
				Image im=box.transform.GetChild(3).GetComponent<Image>();
				im.sprite=Resources.Load<Sprite>("Texture/"+info[0]);
				Text te = box.transform.GetChild (0).gameObject.GetComponent<Text> ();
				te.text = info [0];
				te = box.transform.GetChild (2).gameObject.GetComponent<Text> ();
				te.text = info [1];
				enter=true;
			}
		}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if(Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.KeypadEnter)){
				if (compteur == lines.GetLength(0)-1||!Personnage.pnjcollide) {
					enter=false;
					animator.SetBool("Dialogue",false);
					compteur=0;
				}else{
				Dialogue dial = new Dialogue ();
				string[] info=dial.ReadLine (lines [compteur]);
				compteur++;
				Image im=box.transform.GetChild(3).GetComponent<Image>();
				im.sprite=Resources.Load<Sprite>("Texture/"+info[0]);
				Text te=box.transform.GetChild(0).gameObject.GetComponent<Text>();
				te.text = info[0];
					te=box.transform.GetChild(2).gameObject.GetComponent<Text>();
				te.text = info [1];
				}
			}

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if (enter == false){
				GameObject.Destroy (GameObject.Find ("Dialog(Clone)"));
		}		
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {


	}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
}