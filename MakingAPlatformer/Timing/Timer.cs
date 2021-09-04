using Microsoft.Xna.Framework;
using System;

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
            SetReferenceTimeStamp(timeIsSet, gameTime);

            if (timeStamp + timeToWait < gameTime.TotalGameTime) return true;
            return false;
        }

        private void SetReferenceTimeStamp(bool isSet, GameTime gameTime)
        {
            if (!isSet)
            {
                timeStamp = gameTime.TotalGameTime;
                timeIsSet = true;
            }
        }
    }
}
