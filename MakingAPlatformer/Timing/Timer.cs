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
        private bool timeIsSet = false;

        public bool SecondsElapsed(int seconds, GameTime gameTime)
        {
            timeToWait = TimeSpan.FromMilliseconds(seconds * 1000);
            setReferenceTimeStamp(timeIsSet, gameTime);

            if (timeStamp + timeToWait < gameTime.TotalGameTime) return true;
            return false;
        }

        private void setReferenceTimeStamp(bool isSet, GameTime gameTime)
        {
            if (!isSet)
            {
                timeStamp = gameTime.TotalGameTime;
                timeIsSet = true;
            }
        }
    }
}
