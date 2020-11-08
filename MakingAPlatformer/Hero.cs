using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Hero : IGameObject, ITransform, IAnimateable
    {
        public Vector2 Position { get; set; } 

        public Vector2 Direction;
        public Animator Animator { get; set; }
        public PossibleAnimations AnimToPlay { get; set; }

        public IInputReader KeyboardReader;
        public IGameCommand MoveCommand;
        public AnimateCommand AnimateCommand;

        private int runSpeed = 3;
        public  int jumpSpeed = 0; // private
        private Animation currentAnimation;

        public bool jumping;
        public float startY;

        public Hero()
        {
            // TODO: dependency-injection
            Animator = new HeroAnimator();
            KeyboardReader = new KeyboardReader();
            MoveCommand = new MoveCommand(runSpeed);
            AnimateCommand = new AnimateCommand();

            // Startposition
            Position = new Vector2(100, 250);

            // Add animations that need to be used
            Animator.Animations.Add(new NormalAnimation("Hero-Idle-Right", "Hero/Normal/Idle", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Idle-Left", "Hero/Mirrored/Idle-MIRRORED", 8, 150));
            Animator.Animations.Add(new NormalAnimation("Hero-Run-Right", "Hero/Normal/Run", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Run-Left", "Hero/Mirrored/Run-MIRRORED", 8, 150));

            // Initialize animations
            Animator.InitializeAnimations();

            // Set start animation
            currentAnimation = Animator.Animations[0];

            // jump
            jumping = false;
            startY = Position.Y;
        }

        public void Update(GameTime gameTime)
        {
            // Read input
            Direction = KeyboardReader.ReadInput();

            // Move character
            MoveCommand.Execute(this, Direction);

            // jumping test
            KeyboardState keyState = Keyboard.GetState();
            if (jumping)
            {
                Position = new Vector2(Position.X, jumpSpeed);
                jumpSpeed += 5; // falling speed
                if (Position.Y >= startY)
                {
                    Position = new Vector2(Position.X, startY);
                    jumping = false;
                }
            }
            else
            {
                if (keyState.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpSpeed = (int)Position.Y - 150; // initial jump heigth
                }
            }

            // Choose animation according to direction
            AnimateCommand.Execute(this, Direction);

            // Animate accordingly
            currentAnimation = Animator.Animate(AnimToPlay);

            Animator.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.SpriteSheet, Position, currentAnimation.CurrentFrame.sourceRectangle, Color.White);
        }
    }
}