using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Hero : IGameObject, ITransform
    {
        public Vector2 Position { get; set; } 

        public Vector2 Direction;
        public Animator Animator { get; set; }

        public IInputReader KeyboardReader;
        public IGameCommand MoveCommand;

        private int speed = 3;
        private Animation currentAnimation;

        public Hero()
        {
            // TODO: dependency-injection
            Animator = new Animator();
            KeyboardReader = new KeyboardReader();
            MoveCommand = new MoveCommand(speed);
            Position = new Vector2(100, 250);

            currentAnimation = Animator.Animations[0];
        }

        public void Update(GameTime gameTime)
        {
            // Read input
            Direction = KeyboardReader.ReadInput();
            // Move character
            MoveCommand.Execute(this, Direction);
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
