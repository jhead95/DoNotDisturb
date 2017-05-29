using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class high_score : MonoBehaviour {

    Text txt;
    int highScore = 1;

    int count = 0;

    // Use this for initialization
    void Start () {

        txt = gameObject.GetComponent<Text>();

        txt.text = "" + highScore;
        //txt.color = new Color(93 / 255f, 204 / 255f, 102 / 255f);

    }

    public void incrementStretchCountForHS()
    {
        count += 1;

    }

    // Update is called once per frame
    void Update () {

        if (count > highScore)
        {
            txt.text = "" + count;
            txt.color = new Color(93 / 255f, 204 / 255f, 102 / 255f);
        }
       

        
		
	}


   
}
