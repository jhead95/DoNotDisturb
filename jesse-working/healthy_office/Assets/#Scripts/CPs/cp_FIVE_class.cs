using UnityEngine;
using System.Collections;

public class cp_FIVE_class : MonoBehaviour {

	float timeRemaining;

	void Start () {

		//timeRemaining = 2.0f;
	
	}


	void Update () {

		/*timeRemaining -= Time.deltaTime;
		if ( timeRemaining < 0 )
		{

		}*/
	
	}


	public void turnOnCP_FIVE()
	{
		Material newMat = Resources.Load("Contact_Point_Material", typeof(Material)) as Material;
		gameObject.GetComponent<Renderer>().material = newMat;
	}

	public void turnOffCP_FIVE()
	{
		Material newMat = Resources.Load("cp_default", typeof(Material)) as Material;
		gameObject.GetComponent<Renderer>().material = newMat;
	}




}
