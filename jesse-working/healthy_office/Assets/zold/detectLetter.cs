using UnityEngine;
using System.Collections;

public class detectLetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other) {

		//Debug.Log ("It hit it.");

		/*GameObject go = GameObject.Find("Display_Display");
		changeDisplay secondDisplay = (changeDisplay) go.GetComponent(typeof(changeDisplay));
		secondDisplay.turnScreenOn();*/

	}

	/*
	void OnTriggerExit (Collider other) {

		Debug.Log ("It left.");

		//GameObject go = GameObject.Find("Display_Display");
		//changeDisplay hey = (changeDisplay) go.GetComponent(typeof(changeDisplay));
		//hey.turnScreenOff();

	}*/
	
	// Update is called once per frame
	void Update () {
	
	}
}
