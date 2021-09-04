using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MakingAPlatformer
{
    public abstract class Animator
    {
        public List<Animation> Animations { get; set; }
        public PossibleAnimations PreviousAnimation { get; set; }

        public Animator()
        {
            Animations = new List<Animation>();
        }

        public void InitializeAnimations()
        {
            foreach (Animation animation in Animations)
            {
                for (int i = 0; i <= animation.Width * (animation.FrameAmount - 1); i = i + animation.Width)
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, animation.Width, animation.Width)));
                }
            }
        }

        public abstract Animation Animate(PossibleAnimations desiredAnimation);
        
        public void Update(GameTime gameTime)
        {
            foreach (Animation animation in Animations)
            {
                animation.Update(gameTime);
            }
        }
    }
}
