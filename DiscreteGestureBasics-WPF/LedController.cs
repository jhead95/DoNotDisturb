using System;
using System.IO.Ports;


class LedController
{
    SerialPort serialport;
    //number of leds on strip
    public int ledQuantity;
    //LED strip becomes 100% at this time (in seconds)
    public int maxDuration;
        
    public LedController(int ledQuantity, int maxDuration)
    {
        serialport = new SerialPort();
        serialport.BaudRate = 9600;
        serialport.PortName = "COM9";
        this.ledQuantity = ledQuantity;
        this.maxDuration = maxDuration;
    }

    public void refresh(int seconds)
    {
        int ledIncrement = maxDuration / ledQuantity;
        
        if (seconds >= ledIncrement)
        {
            int x = seconds / ledIncrement;
            x = x > ledQuantity ? ledQuantity : x;
            this.writeData(x.ToString());
        }
    }

    public void writeData(String data)
    {
        while (serialport.IsOpen) { };

        serialport.Open();
        serialport.Write(data);
        serialport.Close();

    }

}
