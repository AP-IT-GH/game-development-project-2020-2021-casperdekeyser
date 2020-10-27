using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Animator
    {
        public Animation RunRight;
        public Animation RunLeft;

        public List<Animation> Animations;

        public Animator()
        {
            Animations = new List<Animation>();
            Animations.Add(new Animation("Hero/Normal/Run"));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(0, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(150, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(300, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(450, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(600, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(750, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(900, 0, 150, 150)));
            Animations[0].AddFrame(new AnimationFrame(new Rectangle(1050, 0, 150, 150)));
        }

        public void Update(GameTime gameTime)
        {
            Animations[0].Update(gameTime);
        }
    }
}
