using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class NormalAnimation : Animation
    {

        public NormalAnimation(string name, string path, int frames) : base(name, path, frames) { }
             
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
