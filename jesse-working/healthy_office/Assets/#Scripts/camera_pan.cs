using UnityEngine;
using System.Collections;

public class camera_pan : MonoBehaviour {

	Animator animator;

	private float timeremaining;

	bool startTimer;

	// Use this for initialization
	void Start () {

		timeremaining = 0;

		startTimer = false;

		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (startTimer == true) {

			timeremaining -= Time.deltaTime;

		}

		if (timeremaining < 0) {

			animator.SetInteger("cameraShouldPan", 0);

			startTimer = false;

		}
	
	}

	public void panTheCamera() {

		animator.SetInteger("cameraShouldPan", 1);

		timeremaining = 2;

		startTimer = true;


	}
}
