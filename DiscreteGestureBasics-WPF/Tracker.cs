using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Ports;


namespace Microsoft.Samples.Kinect.DiscreteGestureBasics
{
    class Tracker
    {

        TimeSpan sittingTime;
        TimeSpan standingTime;
        float confThreshold;
        float avg;
        int avgLen;
        Stopwatch sw;
        const int SWINCREMENT = 1000;
        LedController ledStrip;
        const int LEDMAXDURATION = 45;
        const int LEDQUANTITY = 6;
        Dictionary<ulong, Tuple<float, int>> people = new Dictionary<ulong, Tuple<float, int>>();




        public Tracker()
        {
            this.sittingTime = new TimeSpan();
            this.standingTime = new TimeSpan();
            this.avg = 0F;
            this.avgLen = 0;
            this.confThreshold = 0.5F;
            this.sw = new Stopwatch();
            this.sw.Start();
            ledStrip = new LedController(LEDQUANTITY, LEDMAXDURATION);
            Dictionary<ulong, Tuple<float, int>> people = new Dictionary<ulong, Tuple<float, int>>();
            //ledStrip.refresh(0);


        }
        public Tracker(float confThreshold)
        {
            this.sittingTime = new TimeSpan();
            this.standingTime = new TimeSpan();
            this.avg = 0F;
            this.avgLen = 0;
            this.confThreshold = confThreshold;
            this.sw = new Stopwatch();
            this.sw.Start();
            ledStrip = new LedController(LEDQUANTITY, LEDMAXDURATION);
            Dictionary<ulong, Tuple<float, int>> people = new Dictionary<ulong, Tuple<float, int>>();
            //ledStrip.refresh(0);

        }

        public void addConfidenceID(float confidence, ulong trackingID)
        {
            if (this.people.ContainsKey(trackingID))
            {
                float avg = this.people[trackingID].Item1;
                int avgLen = this.people[trackingID].Item2;
                avg = ((avg * avgLen) + confidence) / (avgLen + 1);
                avgLen++;
                this.people[trackingID] = Tuple.Create(avg, avgLen);
            }
            else
            {
                people.Add(trackingID, Tuple.Create(confidence, 1));
            }
            this.avg = ((this.avg * this.avgLen) + confidence) / (this.avgLen + 1);
            this.avgLen++;
            //Console.WriteLine(trackingID);

            if (sw.ElapsedMilliseconds >= SWINCREMENT)
            {
                update();
            }
        }

        private float getHighestConfidence()
        {
            float highscore = 0F;
            foreach (KeyValuePair<ulong, Tuple<float, int>> entry in this.people)
            {
                // do something with entry.Value or entry.Key
                highscore = entry.Value.Item1 > highscore ? entry.Value.Item1 : highscore;
            }
            //Needs to return the highest avg confidence from the people dict
            return highscore;

        }

        public void addConfidence(float confidence)
        {
            this.avg = ((this.avg * this.avgLen) + confidence) / (this.avgLen + 1);
            this.avgLen++;

            if (sw.ElapsedMilliseconds >= SWINCREMENT)
            {
                update();
            }
        }

        private void update()
        {
            //if (avg>confThreshold)
            if (this.getHighestConfidence()>confThreshold)
            {
                this.sittingTime = this.sittingTime.Add(this.sw.Elapsed);
            }
            else
            {
                //this.standingTime = this.standingTime.Add(this.sw.Elapsed);
            }
            
            if ((int)this.sittingTime.TotalSeconds >= ledStrip.maxDuration/ledStrip.ledQuantity)
            {
                ledStrip.writeData("6");
                //Console.WriteLine(this.avg);
                this.reset();
                //Console.WriteLine(this.avg);
            }
            
            Console.WriteLine(this.avg);
            Console.WriteLine(this.sittingTime);
            //this.reset();
            //Console.WriteLine(this.avg);
            this.sw.Restart();
            this.people = new Dictionary<ulong, Tuple<float, int>>();
            this.avg = 0F;
            this.avgLen = 0;
        }

        public String toString()
        {
            String output = "";
            output += "Sitting time:  " + this.sittingTime + Environment.NewLine;
            output += "Standing time:  " + this.standingTime + Environment.NewLine;
            return output;
        }

        public void reset()
        {
            this.sittingTime = new TimeSpan();
            this.standingTime = new TimeSpan();
            this.avg = 0F;
            this.avgLen = 0;
        }




    }
}
