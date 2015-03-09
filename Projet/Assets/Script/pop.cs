using UnityEngine;
using System.Collections;

public class pop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject chat=Instantiate (Resources.Load ("Prefab/Chat"))as GameObject;
	}
}
