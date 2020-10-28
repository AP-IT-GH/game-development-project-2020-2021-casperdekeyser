using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public abstract class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        public Texture2D SpriteSheet { get; set; }
        public string SpriteSheetPath { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }

        protected List<AnimationFrame> frames;
        protected int counter;

        protected double frameMovement = 0;
        protected int framesPerSecond = 12;

        public Animation(string name, string path, int frameamount, int width)
        {
            frames = new List<AnimationFrame>();
            Name = name;
            SpriteSheetPath = path;
            counter = frameamount-1;
            Width = width;
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }

        public abstract void Update(GameTime gameTime);

        public override string ToString() // Debug
        {
            return $"{Name} has {frames.Count} frames and uses this spritesheet: {SpriteSheetPath}";
        }

    }
}

