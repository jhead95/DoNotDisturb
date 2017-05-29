using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_sitting : MonoBehaviour {

    float timeRemaining;
    public Image img;
    public Sprite[] sprites;

    static bool running = false;

    //SpriteRenderer sr;

    // Use this for initialization
    void Start () {

        //sr = GetComponent<SpriteRenderer>();
        img = GetComponent<Image>();
        timeRemaining = 5f;

    }
	
    public static void setRunning()
    {
        running = false;
    }

	// Update is called once per frame
	void Update () {

        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
        {
            timeRemaining = 5f;




            int x = SendSerial.sendAndReceive("5"); //make 5 later

            string spriteName = "ts_" + x.ToString();

    

            //Sprite tsSprite = Resources.Load(spriteName, typeof(Sprite)) as Sprite;

            //GetComponent<SpriteRenderer>().sprite = tsSprite;
            img.sprite = sprites[x];
            print(x + " was just recieved, nice");



            if (x == 6 && running == false)
            {
                running = true;

                GameObject theDude = GameObject.Find("Y_Bot");
                movements transClass = (movements)theDude.GetComponent(typeof(movements));
                transClass.changeTheDude();

                
            }

            


        }

    }
}
