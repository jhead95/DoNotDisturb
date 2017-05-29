using System;
using System.IO.Ports;
using System.Threading.Tasks;

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
        serialport.PortName = "COM3";
        new Task(() => { resetBuffer(); }).Start();
        this.ledQuantity = ledQuantity;
        this.maxDuration = maxDuration;

        //reset();
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

    public void reset()
    {
        writeData("000");
    }

    public void writeData(String data)
    {
        //Just a neater wrapper method, fires asynchronously now
        new Task(() => { writeDataAsync(data); }).Start();
    }

    void resetBuffer()
    {
        try
        {
            serialport.Open();
            serialport.DiscardInBuffer();
            serialport.DiscardOutBuffer();
            serialport.Close();
        } catch
        {
            Task.Delay(10);
            new Task(() => { resetBuffer(); }).Start();
        }
    }

    void writeDataAsync(String data)
    {
        try
        {
            serialport.Open();
            serialport.Write(data);
            //Task.Delay(10);
            Console.WriteLine("Arduino says: " + serialport.ReadByte());
            serialport.Close();
            //new Task(() => { readDataAsync(); }).Start();
        }
        catch
        {
            Task.Delay(10);
            new Task(() => { writeDataAsync(data); }).Start();
        }
    }

    void readDataAsync()
    {
        try
        {
            serialport.Open();
            //serialport.ReadLine();
            Console.WriteLine("Arduino says: " + serialport.ReadByte());
            serialport.Close();
        }
        catch
        {
            Console.WriteLine("port open already");
            Task.Delay(100);
            new Task(() => { readDataAsync(); }).Start();
        }
    }

}
