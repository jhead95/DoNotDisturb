using System.Collections;
using UnityEngine;
using System.IO.Ports;
using System.Threading;


public class SendSerial : MonoBehaviour {
	//Serial for PC
	public static SerialPort sp = new SerialPort("COM6", 9600);

	//Serial for Mac
	//public static SerialPort sp = new SerialPort("/dev/tty.usbmodem1431", 9600);

	// Use this for initialization
	void Start () {
		//OpenConnection();
	}

	// Update is called once per frame
	void Update () {
		
	}

    /*
	public void OpenConnection() 
	{
		if (sp != null) 
		{
			if (sp.IsOpen) 
			{
				sp.Close();
				print("Closing port, because it was already open!");
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 16;  // sets the timeout value before reporting error
				print("Port Opened!");
				//		message = "Port Opened!";
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
	}
    */





    /*public static void updateClock()
    {
        // recursive function or just have bool stored.
        // also need to be using jaiedens arduino here.

        sp.Open();

        // apparently i need to write first?
        sp.Write("5");

        // maybe add slight delay

        string currentCycleCount = sp.ReadLine();

        sp.Close();

        // make the below a new function tho?

        if (currentCycleCount == "1")
        {

        }


    }*/


   /* public static void sendData(string dataToSend)
    {

        sp.Open();

        // apparently i need to write first?
        sp.Write(dataToSend);

        // maybe add slight delay

        string currentCycleCount = sp.ReadLine();

        sp.Close();

        // make the below a new function tho?

        if (currentCycleCount == "1")
        {
            
        }


    }*/
















public static int sendAndReceive(string data)
    {
        SerialPort jArduino = new SerialPort();
        jArduino.BaudRate = 9600;
        jArduino.PortName = "COM9";
        int output = -1;

        while (output < 0)
        {
            try
            {
                jArduino.Open();
                jArduino.DiscardInBuffer();
                jArduino.DiscardOutBuffer();
                jArduino.Write(data);
                output = jArduino.ReadByte();
                return output;
            }
            catch
            {
                //return sendAndReceive(data);
                //new Task(() => { sendAndReceive(data); }).Start();
            }
        }
        return -1;

    }










    void OnApplicationQuit() 
	{
		sp.Close();
	}

    public static void closeConnection()
    {
        sp.Close();
    }



    public static void sendStretch1Blink(){
        sp.Open();
		sp.Write ("a");
        sp.Close();
    }

	public static void sendStretch1Solid(){
        sp.Open();
        sp.Write("1");
        sp.Close();
    }



	public static void sendStretch2Blink(){
        sp.Open();
        sp.Write ("b");
        sp.Close();
    }

	public static void sendStretch2Solid(){
        sp.Open();
        sp.Write("2");
        sp.Close();
    }



	public static void sendStretch3Blink(){
        sp.Open();
        sp.Write ("c");
        sp.Close();
    }

	public static void sendStretch3Solid(){
        sp.Open();
        sp.Write("3");
        sp.Close();
    }



	public static void sendStretch4Blink(){
        sp.Open();
        sp.Write ("d");
        sp.Close();
    }

    public static void sendStretch4Solid(){
        sp.Open();
        sp.Write("4");
        sp.Close();
    }



	public static void sendStretch5Blink(){
        sp.Open();
        sp.Write ("e");
        sp.Close();
    }

    public static void sendStretch5Solid(){
        sp.Open();
        sp.Write("5");
        sp.Close();
    }



	public static void sendStretch6Blink(){
        sp.Open();
        sp.Write ("f");
        sp.Close();
    }

    public static void sendStretch6Solid(){
        sp.Open();
        sp.Write("6");
        sp.Close();
    }



	public static void sendStretch7Blink(){
        sp.Open();
        sp.Write ("g");
        sp.Close();
    }

	public static void sendStretch7Solid(){
        sp.Open();
        sp.Write("7");
        sp.Close();
    }



	public static void sendStretch8Blink(){
        sp.Open();
        sp.Write ("h");
        sp.Close();
    }

	public static void sendStretch8Solid(){
        sp.Open();
        sp.Write("8");
        sp.Close();
    }



	public static void sendStretch9Blink(){
        sp.Open();
        sp.Write ("i");
        sp.Close();
    }

	public static void sendStretch9Solid(){
        sp.Open();
        sp.Write("9");
        sp.Close();
    }



    public static void sendOff(){
        sp.Open();
        sp.Write("0");
        sp.Close();
    }










    public static void finishedStretching()
    {
       // sp.Open();
        //sp.Write("x");
        //sp.Close();
    }





}