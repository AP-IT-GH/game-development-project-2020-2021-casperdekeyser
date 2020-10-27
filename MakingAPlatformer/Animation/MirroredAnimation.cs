using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public abstract class MirroredAnimation : Animation
    {
        
        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
            // test left animation --> WERKT NOG NIET!
            //CurrentFrame = frames[counter];

            //frameMovement += CurrentFrame.sourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            //if (frameMovement <= CurrentFrame.sourceRectangle.Width * framesPerSecond)
            //{
            //    counter--;
            //    frameMovement = 0;
            //}

            //if (counter <= 0)
            //    counter = frames.Count-1;
        }
    }
}
