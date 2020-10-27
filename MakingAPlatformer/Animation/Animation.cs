using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Animation
    {
        private List<AnimationFrame> frames;
        private int counter;
        private double frameMovement = 0;
        private int framesPerSecond = 12;
        public AnimationFrame CurrentFrame { get; set; }

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }
        
        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            frameMovement += CurrentFrame.sourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= CurrentFrame.sourceRectangle.Width/framesPerSecond)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
                counter = 0;
        }
    }
}
