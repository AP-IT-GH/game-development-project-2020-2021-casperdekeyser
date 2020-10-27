using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace MakingAPlatformer
{
    public class HeroAnimation
    {
        public AnimationFrame CurrentFrame { get; set; }
        public Texture2D SpriteSheet { get; set; }
        public string SpriteSheetPath { get; set; }


        private List<AnimationFrame> frames;
        private int counter = 7;
        private double frameMovement = 0;
        private int framesPerSecond = 12;

        public HeroAnimation(string path)
        {
            frames = new List<AnimationFrame>();
            SpriteSheetPath = path;
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

            if (frameMovement >= CurrentFrame.sourceRectangle.Width / framesPerSecond)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
                counter = 0;


            // test left animation
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
