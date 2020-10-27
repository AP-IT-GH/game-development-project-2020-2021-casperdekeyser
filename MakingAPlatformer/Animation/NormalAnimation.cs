using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public abstract class NormalAnimation : Animation
    {
        public override void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            frameMovement += CurrentFrame.sourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= CurrentFrame.sourceRectangle.Width / framesPerSecond)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
                counter = 0;
        }
    }
}
