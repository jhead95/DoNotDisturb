using System;
using System.IO.Ports;


class LedController
{
    SerialPort serialport;
    //number of leds on strip
    int ledQuantity;
    //LED strip becomes 100% at this time (in seconds)
    int maxDuration;
        
    public LedController(int ledQuantity, int maxDuration)
    {
        serialport = new SerialPort();
        serialport.BaudRate = 9600;
        serialport.PortName = "COM3";
        this.ledQuantity = ledQuantity;
        this.maxDuration = maxDuration;
    }

    public void refresh(int seconds)
    {
        int ledIncrement = maxDuration / ledQuantity;
        int x = seconds / ledIncrement;
        x = x > ledQuantity ? ledQuantity : x;
        this.writeData(x.ToString());
    }

    private void writeData(String data)
    {
        if (serialport.IsOpen)
        {
            serialport.Close();
        }
        serialport.Open();
        serialport.Write(data);
        serialport.Close();

    }

}
