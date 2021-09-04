using Microsoft.Xna.Framework;
using System;

namespace MakingAPlatformer.Timing
{
    public class Timer
    {
        private TimeSpan _timeToWait;
        private TimeSpan _timeStamp;
        private bool _timeIsSet = false;

        public bool SecondsElapsed(int seconds, GameTime gameTime)
        {
            _timeToWait = TimeSpan.FromMilliseconds(seconds * 1000);
            SetReferenceTimeStamp(_timeIsSet, gameTime);

            if (_timeStamp + _timeToWait < gameTime.TotalGameTime) return true;
            return false;
        }

        private void SetReferenceTimeStamp(bool isSet, GameTime gameTime)
        {
            if (!isSet)
            {
                _timeStamp = gameTime.TotalGameTime;
                _timeIsSet = true;
            }
        }
    }
}
