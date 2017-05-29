using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class movements : MonoBehaviour {




	Animator animator;
	int randomInt;

	bool contactPoint1;
	bool contactPoint2;
	bool contactPoint3;
	bool contactPoint4;
	bool contactPoint5;
	bool contactPoint6;

	int stretchToBeDone;

	private float timeremaining = 10;
	bool timerIsGoing = false;

    bool isBlinking;
    bool isSolid;


    




    // Use this for initialization
    void Start () {

		contactPoint1 = false;
		contactPoint2 = false;
		contactPoint3 = false;
		contactPoint4 = false;
		contactPoint5 = false;
		contactPoint6 = false;

		stretchToBeDone = 0;

		timeremaining = 10;
		timerIsGoing = false;

        isBlinking = false;
        isSolid = false;

		animator = GetComponent<Animator>();

	}

	
	void Update () {

        // Reset functions

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SendSerial.sendAndReceive("00");
        }

        //***********************************//

        if (Input.GetKey(KeyCode.W)) {

            print("W");

			contactPoint1 = true;
		} else {
			contactPoint1 = false;
		}

		// ********************************* //

		if (Input.GetKey(KeyCode.A)) {
            print("A");
            contactPoint2 = true;
		} else {
			contactPoint2 = false;
		}

		// ********************************* //

		if (Input.GetKey(KeyCode.S)) {
            print("S");
            contactPoint3 = true;
		} else {
			contactPoint3 = false;
		}

		// ********************************* //

		if (Input.GetKey(KeyCode.D)) {
            print("D");
            contactPoint4 = true;
		} else {
			contactPoint4 = false;
		}

		// ********************************* //

		if (Input.GetKey(KeyCode.F)) {
            print("F");
            contactPoint5 = true;
		} else {
			contactPoint5 = false;
		}

		// ********************************* //

		if (Input.GetKey(KeyCode.G)) {
            print("G");
            contactPoint6 = true;
		} else {
			contactPoint6 = false;
		}




















        // ************************************************************************************************************************************ //
        // ************************************************************************************************************************************ //
        // **************** SET ONE ***************** //

        if (contactPoint2 == true && contactPoint4 == true) {

			if (stretchToBeDone == 1) {

				if (timerIsGoing == false) {
					timeremaining = 10;
					timerIsGoing = true;
				}

                /*if (timeremaining < 3) {
					playDoneAudio ();
				}*/

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch8Solid();
                }

                timeremaining -= Time.deltaTime;

				if (timeremaining < 0 && timerIsGoing == true) {

					timerIsGoing = false;

					stretchToBeDone = 2;

					addToStretchCount ();

                    SendSerial.sendAndReceive("3");

                    playStartAudio ();

					//*****************************//

					animator.SetInteger("movementInt", 2);

					//*************************************//

					turnOffAllCP ();

					SendSerial.sendOff ();

					//*************************************//

					GameObject go = GameObject.Find("cp5");
					cp_FIVE_class secondDisplay = (cp_FIVE_class) go.GetComponent(typeof(cp_FIVE_class));
					secondDisplay.turnOnCP_FIVE();

					//***************** PAN THE CAMERA BELOW ********************//

					giveTheCameraAPan ();

				}

				
			}

		}

		if (contactPoint2 == false || contactPoint4 == false) {

			if (stretchToBeDone == 1) {

                isSolid = false;

                if (isBlinking == false) {

                    isBlinking = true;
                    SendSerial.sendStretch8Blink();
                }

			}

		}








































		if (contactPoint5 == true) {

			if (stretchToBeDone == 2) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch2Solid();
                }

                timeremaining -= Time.deltaTime;

				if (timeremaining < 0 && timerIsGoing == true) {

					timerIsGoing = false;

					addToStretchCount ();

                    SendSerial.sendAndReceive("3");

                    stretchToBeDone = 3;

					playStartAudio ();

					//*****************************//

					animator.SetInteger("movementInt", 3);

					//*************************************//

					turnOffAllCP ();

                    SendSerial.sendOff();

                    //*************************************//

                    GameObject go = GameObject.Find("cp2");
					cp_TWO_class secondDisplay = (cp_TWO_class) go.GetComponent(typeof(cp_TWO_class));
					secondDisplay.turnOnCP_TWO();

					//*************************************//

					GameObject go2 = GameObject.Find("cp3");
					cp_THREE_class another_go_class = (cp_THREE_class) go2.GetComponent(typeof(cp_THREE_class));
					another_go_class.turnOnCP_THREE();

					//***************** PAN THE CAMERA BELOW ********************//

					giveTheCameraAPan ();

				}

			}

		}





        if (contactPoint5 == false)
        {

            if (stretchToBeDone == 2)
            {

                isSolid = false;

                if (isBlinking == false)
                {
                    isBlinking = true;
                    SendSerial.sendStretch2Blink();
                }

            }

        }































        if (contactPoint2 == true && contactPoint3 == true) {

			if (stretchToBeDone == 3) {

				if (timerIsGoing == false) {
					timeremaining = 10;
					timerIsGoing = true;
				}

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch5Solid();
                }

                timeremaining -= Time.deltaTime;

				if (timeremaining < 0 && timerIsGoing == true) {

					timerIsGoing = false;

					addToStretchCount ();

                    SendSerial.sendAndReceive("3");

                    stretchToBeDone = 0;

					playStartAudio ();

                    time_sitting.setRunning();

                    //*****************************//

                    animator.SetInteger("movementInt", 33);

					//*************************************//

					turnOffAllCP ();

                    SendSerial.sendOff();

                    SendSerial.finishedStretching();

                    //**************** RESTART CLOCK *********************//

                    GameObject go_clock = GameObject.Find("clock");
					countdown clock_class = (countdown) go_clock.GetComponent(typeof(countdown));
					clock_class.restartClock();


				}

			}

		}




        if (contactPoint2 == false || contactPoint3 == false)
        {

            if (stretchToBeDone == 3)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch5Blink();
                }

            }

        }








































        // ************************************************************************************************************************************ //
        // ************************************************************************************************************************************ //
        // **************** SET TWO ***************** //

        if (contactPoint1 == true && contactPoint3 == true) {

			if (stretchToBeDone == 4) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                /*if (timeremaining < 3) {
					playDoneAudio ();
				}*/

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch9Solid();
                }

                timeremaining -= Time.deltaTime;

                if (timeremaining < 0 && timerIsGoing == true)
                {

                    timerIsGoing = false;

                    stretchToBeDone = 5;

                    addToStretchCount();

                    SendSerial.sendAndReceive("3");

                    playStartAudio();

                    //*****************************//

                    animator.SetInteger("movementInt", 5);

                    //*************************************//

                    turnOffAllCP();

                    SendSerial.sendOff();

                    //*************************************//

                    GameObject go = GameObject.Find("cp5");
                    cp_FIVE_class secondDisplay = (cp_FIVE_class)go.GetComponent(typeof(cp_FIVE_class));
                    secondDisplay.turnOnCP_FIVE();

                    //*************************************//

                    GameObject go2 = GameObject.Find("cp6");
                    cp_SIX_class another_go_class = (cp_SIX_class)go2.GetComponent(typeof(cp_SIX_class));
                    another_go_class.turnOnCP_SIX();

                    //***************** PAN THE CAMERA BELOW ********************//

                    giveTheCameraAPan();

                }

            }

		}






        if (contactPoint1 == false || contactPoint3 == false)
        {

            if (stretchToBeDone == 4)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch9Blink();
                }

            }

        }





































        if (contactPoint5 == true && contactPoint6 == true) {

			if (stretchToBeDone == 5) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch7Solid();
                }

                timeremaining -= Time.deltaTime;

                if (timeremaining < 0 && timerIsGoing == true)
                {

                    timerIsGoing = false;

                    addToStretchCount();

                    SendSerial.sendAndReceive("3");

                    stretchToBeDone = 6;

                    playStartAudio();

                    //*****************************//

                    animator.SetInteger("movementInt", 6);

                    //*************************************//

                    turnOffAllCP();

                    SendSerial.sendOff();

                    //*************************************//

                    GameObject go = GameObject.Find("cp2");
                    cp_TWO_class secondDisplay = (cp_TWO_class)go.GetComponent(typeof(cp_TWO_class));
                    secondDisplay.turnOnCP_TWO();

                    //***************** PAN THE CAMERA BELOW ********************//

                    giveTheCameraAPan();

                }

            }

		}



        if (contactPoint5 == false || contactPoint6 == false)
        {

            if (stretchToBeDone == 5)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch7Blink();
                }

            }

        }





































        if (contactPoint2 == true) {

			if (stretchToBeDone == 6) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch3Solid();
                }

                timeremaining -= Time.deltaTime;

                if (timeremaining < 0 && timerIsGoing == true)
                {

                    timerIsGoing = false;

                    addToStretchCount();

                    SendSerial.sendAndReceive("3");

                    stretchToBeDone = 0;

                    time_sitting.setRunning();

                    playStartAudio();

                    //*****************************//

                    animator.SetInteger("movementInt", 66);

                    //*************************************//

                    turnOffAllCP();

                    SendSerial.sendOff();

                    SendSerial.finishedStretching();

                    //**************** RESTART CLOCK *********************//

                    GameObject go_clock = GameObject.Find("clock");
                    countdown clock_class = (countdown)go_clock.GetComponent(typeof(countdown));
                    clock_class.restartClock();


                }

            }

		}




        if (contactPoint2 == false)
        {

            if (stretchToBeDone == 6)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch3Blink();
                }

            }

        }






















        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // ********************************* //
        // *************** SET THREE ****************** //

        if (contactPoint1 == true && contactPoint4 == true) {

			if (stretchToBeDone == 7) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                /*if (timeremaining < 3) {
					playDoneAudio ();
				}*/

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch6Solid();
                }

                timeremaining -= Time.deltaTime;

                if (timeremaining < 0 && timerIsGoing == true)
                {

                    timerIsGoing = false;

                    stretchToBeDone = 8;

                    addToStretchCount();

                    SendSerial.sendAndReceive("3");

                    playStartAudio();

                    //*****************************//

                    animator.SetInteger("movementInt", 8);

                    //*************************************//

                    turnOffAllCP();

                    SendSerial.sendOff();

                    //*************************************//

                    GameObject go = GameObject.Find("cp1");
                    cp_ONE_class secondDisplay = (cp_ONE_class)go.GetComponent(typeof(cp_ONE_class));
                    secondDisplay.turnOnCP_ONE();

                    //***************** PAN THE CAMERA BELOW ********************//

                    giveTheCameraAPan();

                }

            }

		}



        if (contactPoint1 == false || contactPoint4 == false)
        {

            if (stretchToBeDone == 7)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch6Blink();
                }

            }

        }





























        if (contactPoint1 == true) {

			if (stretchToBeDone == 8) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch4Solid();
                }

                timeremaining -= Time.deltaTime;

                if (timeremaining < 0 && timerIsGoing == true)
                {

                    timerIsGoing = false;

                    addToStretchCount();

                    SendSerial.sendAndReceive("3");

                    stretchToBeDone = 9;

                    playStartAudio();

                    //*****************************//

                    animator.SetInteger("movementInt", 9);

                    //*************************************//

                    turnOffAllCP();

                    SendSerial.sendOff();

                    //*************************************//

                    GameObject go = GameObject.Find("cp6");
                    cp_SIX_class secondDisplay = (cp_SIX_class)go.GetComponent(typeof(cp_SIX_class));
                    secondDisplay.turnOnCP_SIX();

                    //***************** PAN THE CAMERA BELOW ********************//

                    giveTheCameraAPan();

                }

            }

		}



        if (contactPoint1 == false)
        {

            if (stretchToBeDone == 8)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch4Blink();
                }

            }

        }































        if (contactPoint6 == true) {

			if (stretchToBeDone == 9) {

                if (timerIsGoing == false)
                {
                    timeremaining = 10;
                    timerIsGoing = true;
                }

                isBlinking = false;

                if (isSolid == false)
                {
                    isSolid = true;
                    SendSerial.sendStretch1Solid();
                }

                timeremaining -= Time.deltaTime;

                if (timeremaining < 0 && timerIsGoing == true)
                {

                    timerIsGoing = false;

                    addToStretchCount();

                    SendSerial.sendAndReceive("3");

                    stretchToBeDone = 0;

                    time_sitting.setRunning();

                    playStartAudio();

                    //*****************************//

                    animator.SetInteger("movementInt", 99);

                    //*************************************//

                    turnOffAllCP();

                    SendSerial.sendOff();

                    SendSerial.finishedStretching();

                    //**************** RESTART CLOCK *********************//

                    GameObject go_clock = GameObject.Find("clock");
                    countdown clock_class = (countdown)go_clock.GetComponent(typeof(countdown));
                    clock_class.restartClock();


                }

            }

		}



        if (contactPoint6 == false)
        {

            if (stretchToBeDone == 9)
            {

                isSolid = false;

                if (isBlinking == false)
                {

                    isBlinking = true;
                    SendSerial.sendStretch1Blink();
                }

            }

        }






















    }


































	public void changeTheDude () {

        randomInt = Random.Range(1,4);
        //randomInt = Random.Range(2,3);

		if (randomInt == 1) {

			animator.SetInteger("movementInt", 1);

			stretchToBeDone = 1;
			timerIsGoing = false;

			playDoneAudio ();

            isBlinking = false;
            isSolid = false;

            //*************************************//

            GameObject go = GameObject.Find("cp2");
			cp_TWO_class secondDisplay = (cp_TWO_class) go.GetComponent(typeof(cp_TWO_class));
			secondDisplay.turnOnCP_TWO();

			//*************************************//

			GameObject go2 = GameObject.Find("cp4");
			cp_FOUR_class another_go_class = (cp_FOUR_class) go2.GetComponent(typeof(cp_FOUR_class));
			another_go_class.turnOnCP_FOUR();

			//***************** PAN THE CAMERA BELOW ********************//

			giveTheCameraAPan ();



		} else if (randomInt == 2) {

			animator.SetInteger("movementInt", 4);

			stretchToBeDone = 4;
			timerIsGoing = false;

			playDoneAudio ();

            isBlinking = false;
            isSolid = false;

            //*************************************//

            GameObject go = GameObject.Find("cp1");
			cp_ONE_class secondDisplay = (cp_ONE_class) go.GetComponent(typeof(cp_ONE_class));
			secondDisplay.turnOnCP_ONE();

			//*************************************//

			GameObject go2 = GameObject.Find("cp3");
			cp_THREE_class another_go_class = (cp_THREE_class) go2.GetComponent(typeof(cp_THREE_class));
			another_go_class.turnOnCP_THREE();

			//***************** PAN THE CAMERA BELOW ********************//

			giveTheCameraAPan ();



		} else if (randomInt == 3) {

			animator.SetInteger("movementInt", 7);

			stretchToBeDone = 7;
			timerIsGoing = false;

			playDoneAudio ();

            isBlinking = false;
            isSolid = false;

            //*************************************//

            GameObject go = GameObject.Find("cp1");
			cp_ONE_class secondDisplay = (cp_ONE_class) go.GetComponent(typeof(cp_ONE_class));
			secondDisplay.turnOnCP_ONE();

			//*************************************//

			GameObject go2 = GameObject.Find("cp4");
			cp_FOUR_class another_go_class = (cp_FOUR_class) go2.GetComponent(typeof(cp_FOUR_class));
			another_go_class.turnOnCP_FOUR();

			//***************** PAN THE CAMERA BELOW ********************//

			giveTheCameraAPan ();



		}




	}




	public void turnOffAllCP () {

		GameObject go_one = GameObject.Find("cp1");
		cp_ONE_class one_class = (cp_ONE_class) go_one.GetComponent(typeof(cp_ONE_class));
		one_class.turnOffCP_ONE();

		//*************************************//

		GameObject go_two = GameObject.Find("cp2");
		cp_TWO_class two_class = (cp_TWO_class) go_two.GetComponent(typeof(cp_TWO_class));
		two_class.turnOffCP_TWO();

		//*************************************//

		GameObject go_three = GameObject.Find("cp3");
		cp_THREE_class three_class = (cp_THREE_class) go_three.GetComponent(typeof(cp_THREE_class));
		three_class.turnOffCP_THREE();

		//*************************************//

		GameObject go_four = GameObject.Find("cp4");
		cp_FOUR_class four_class = (cp_FOUR_class) go_four.GetComponent(typeof(cp_FOUR_class));
		four_class.turnOffCP_FOUR();

		//*************************************//

		GameObject go_five = GameObject.Find("cp5");
		cp_FIVE_class five_class = (cp_FIVE_class) go_five.GetComponent(typeof(cp_FIVE_class));
		five_class.turnOffCP_FIVE();

		//*************************************//

		GameObject go_six = GameObject.Find("cp6");
		cp_SIX_class six_class = (cp_SIX_class) go_six.GetComponent(typeof(cp_SIX_class));
		six_class.turnOffCP_SIX();

		//*************************************//


	}


	void addToStretchCount() {

		GameObject go_clock = GameObject.Find("stretch_count");
		stretch_counter clock_class = (stretch_counter) go_clock.GetComponent(typeof(stretch_counter));
		clock_class.incrementStretchCount();

        GameObject go_hs = GameObject.Find("high_score");
        high_score hs_class = (high_score) go_hs.GetComponent(typeof(high_score));
        hs_class.incrementStretchCountForHS();


    }


	void giveTheCameraAPan() {

		GameObject camera = GameObject.Find("camera");
		camera_pan camera_class = (camera_pan) camera.GetComponent(typeof(camera_pan));
		camera_class.panTheCamera();


	}


	void playStartAudio() {

		GameObject go_audio = GameObject.Find("audio_start");
		audio_start audiostart_class = (audio_start) go_audio.GetComponent(typeof(audio_start));
		audiostart_class.playAudio_START();

	}

	void playDoneAudio() {

		GameObject go_audio = GameObject.Find("audio_done");
		audio_done audiostart_class = (audio_done) go_audio.GetComponent(typeof(audio_done));
		audiostart_class.playAudio_DONE();

	}





}
