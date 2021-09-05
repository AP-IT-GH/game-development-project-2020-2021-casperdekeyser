using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MakingAPlatformer.Interfaces
{
    public interface IAnimator
    {
        public List<Animation> Animations { get; set; }
        public PossibleAnimations PreviousAnimation { get; set; }

        void InitializeAnimations();
        Animation Animate(PossibleAnimations AnimToPlay);
        void Update(GameTime gameTime);
    }
}
