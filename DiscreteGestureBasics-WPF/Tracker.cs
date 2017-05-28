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
        const int SWINCREMENT = 1000;
        LedController ledStrip;
        const int LEDMAXDURATION = 12;
        const int LEDQUANTITY = 6;
        
        

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
            ledStrip.refresh(0);


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
            ledStrip.refresh(0);

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
            if (avg>confThreshold)
            {
                this.sittingTime = this.sittingTime.Add(this.sw.Elapsed);
            }
            else
            {
                this.standingTime = this.standingTime.Add(this.sw.Elapsed);
            }

            if ((int)this.sittingTime.TotalSeconds >= ledStrip.maxDuration/ledStrip.ledQuantity)
            {
                ledStrip.writeData("6");
                this.reset();
            }
            this.sw.Restart();
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
