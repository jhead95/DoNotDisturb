using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stretch_counter : MonoBehaviour {

	Text txt;
	int count = 0;

	// Use this for initialization
	void Start () {

		txt = gameObject.GetComponent<Text>(); 

		txt.text="" + count;
	
	}

	public void incrementStretchCount() {

		count += 1;

		txt.text="" + count;

	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
