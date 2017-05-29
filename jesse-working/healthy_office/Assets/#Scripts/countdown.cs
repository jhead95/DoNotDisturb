using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

	Text txt;
	private float timeremaining = 59;
	bool timerComplete;



	void Start () {

		txt = gameObject.GetComponent<Text>(); 
		txt.text="00:" + timeremaining;

		timerComplete = false;
	
	}

	public void restartClock() {

		timeremaining = 59;

		txt.text="00:" + timeremaining;

		timerComplete = false;
	}


	void Update () {

		timeremaining -= Time.deltaTime * (float)20;

		if (timeremaining > 10) {

			txt.text = "00:" + (int)timeremaining;

		} else if (timeremaining < 0) {

			txt.text = "00:00";

			if (timerComplete == false) {

				timerComplete = true;


                //SendSerial.sendAndReceive("2");

				GameObject theDude = GameObject.Find("Y_Bot");
				movements transClass = (movements) theDude.GetComponent(typeof(movements));
				transClass.changeTheDude();




			}


		} else {

			txt.text = "00:0" + (int)timeremaining;
		}
	}



}
