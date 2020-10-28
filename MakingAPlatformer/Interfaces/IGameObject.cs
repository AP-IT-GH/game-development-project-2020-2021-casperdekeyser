using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Interfaces
{
    public interface IGameObject
    {
        Animator Animator { get; set; }
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
