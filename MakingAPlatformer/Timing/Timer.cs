using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Timing
{
    public class Timer
    {
        private TimeSpan timeToWait;
        private TimeSpan timeStamp;

        public void WaitForSeconds(int seconds, GameTime gameTime)
        {
            bool finished = false;
            timeToWait = TimeSpan.FromMilliseconds(seconds * 1000);
            while (!finished)
            {
                if (timeStamp == TimeSpan.Zero) 
                    timeStamp = gameTime.TotalGameTime;

                if (timeStamp + timeToWait < gameTime.TotalGameTime) 
                    finished = true;
            }
        }
    }
}
