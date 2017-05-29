using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_sitting : MonoBehaviour {

    float timeRemaining;

    // Use this for initialization
    void Start () {

        timeRemaining = 5f;

    }
	
	// Update is called once per frame
	void Update () {

        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
        {
            timeRemaining = 5f;

            int x = SendSerial.sendAndReceive("5");

            print(x + " was just recieved, nice");

        }

    }
}
