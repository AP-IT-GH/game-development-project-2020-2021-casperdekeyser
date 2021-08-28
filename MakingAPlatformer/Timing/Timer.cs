using Microsoft.Xna.Framework;
using System;

namespace MakingAPlatformer.Timing
{
    public static class Timer
    {
        private static TimeSpan timeToWait;
        private static TimeSpan timeStamp;
        private static bool timeIsSet = false;

        public static bool SecondsElapsed(int seconds, GameTime gameTime)
        {
            timeToWait = TimeSpan.FromMilliseconds(seconds * 1000);
            SetReferenceTimeStamp(timeIsSet, gameTime);

            if (timeStamp + timeToWait < gameTime.TotalGameTime) return true;
            return false;
        }

        private static void SetReferenceTimeStamp(bool isSet, GameTime gameTime)
        {
            if (!isSet)
            {
                timeStamp = gameTime.TotalGameTime;
                timeIsSet = true;
            }
        }
    }
}
