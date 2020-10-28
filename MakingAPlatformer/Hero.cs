using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Hero : IGameObject
    {
        public Vector2 Position { get; set; }

        public Vector2 Direction;
        public Animator Animator { get; set; }
        public IInputReader KeyboardReader;

        private int speed = 2;
        private Animation currentAnimation;

        public Hero()
        {
            // DIP: injection
            Animator = new Animator();
            currentAnimation = Animator.Animations[0];
            KeyboardReader = new KeyboardReader();
        }

        public void Update(GameTime gameTime)
        {
            // Read input
            Direction = KeyboardReader.ReadInput();
            // Move character
            Direction.X *= speed;
            Position += Direction;
            // Animate correctly
            currentAnimation = Animator.Animate(Direction.X);
            Animator.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.SpriteSheet, Position, currentAnimation.CurrentFrame.sourceRectangle, Color.White);
        }
    }
}
