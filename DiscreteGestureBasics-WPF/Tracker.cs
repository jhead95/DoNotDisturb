using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


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
        int swIncrement;
        
        

        public Tracker()
        {
            this.sittingTime = new TimeSpan();
            this.standingTime = new TimeSpan();
            this.avg = 0F;
            this.avgLen = 0;
            this.confThreshold = 0.5F;
            this.sw = new Stopwatch();
            this.sw.Start();
            int swIncrement = 1000;
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
            this.swIncrement = 1000;

        }

        public void addConfidence(float confidence)
        {
            this.avg = ((this.avg * this.avgLen) + confidence) / (this.avgLen + 1);
            this.avgLen++;
            if (sw.ElapsedMilliseconds >= swIncrement)
            {
                update();
            }
        }

        private void update()
        {
            if (avg>confThreshold)
            {
                this.sittingTime = this.sittingTime.Add(this.sw.Elapsed);
            }
            else
            {
                this.standingTime = this.standingTime.Add(this.sw.Elapsed);
            }
            Console.WriteLine(this.toString());
            this.sw.Restart();
        }

        public String toString()
        {
            String output = "";
            output += "Sitting time:  " + this.sittingTime + Environment.NewLine;
            output += "Standing time:  " + this.standingTime + Environment.NewLine;
            return output;
        }




    }
}
