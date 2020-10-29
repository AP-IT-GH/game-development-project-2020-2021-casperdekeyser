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

            // Add animations that need to be used
            Animator.Animations.Add(new NormalAnimation("HeroIdleRight", "Hero/Normal/Idle", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("HeroIdleLeft", "Hero/Mirrored/Idle-MIRRORED", 8, 150));
            Animator.Animations.Add(new NormalAnimation("HeroRunRight", "Hero/Normal/Run", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("HeroRunLeft", "Hero/Mirrored/Run-MIRRORED", 8, 150));

            // Initialize animations
            Animator.InitializeAnimations();

            // Set start animation
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