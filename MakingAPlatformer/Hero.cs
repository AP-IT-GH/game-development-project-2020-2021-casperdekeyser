using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer
{
    public enum Movement { MoveRight, MoveLeft, Idle, Jump }
    public enum PossibleAnimations { RunRight, RunLeft, IdleRight, IdleLeft, AttackRight, AttackLeft, JumpLeft, JumpRight }
    public enum States { Jumping, Idling, Falling}

    public class Hero : IGameObject, ITransform, IAnimateable
    {
        public static States State = States.Idling;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Movement MoveDirection;
        public Animator Animator { get; set; }
        public PossibleAnimations AnimToPlay { get; set; }
        public JumpCommand JumpCommand { get; set; }
        public BoxCollider Collider { get; set; }

        public IInputReader KeyboardReader;
        public MoveCommand MoveCommand;
        public AnimateCommand AnimateCommand;

        private int _runSpeed = 3;
        private Animation _currentAnimation;
        private int _jumpSpeed = 5;
        private int _jumpHeight = 150;
        private int _xOffset = 60;
        private int _yOffset = 45;

        public Hero(Vector2 pos, HeroAnimator anim, IInputReader input, AnimateCommand animcom)
        {
            // Startposition
            Position = pos;

            Animator = anim;
            KeyboardReader = input;
            AnimateCommand = animcom;
            MoveCommand = new MoveCommand(_runSpeed);
            JumpCommand = new JumpCommand(_jumpSpeed, _jumpHeight, Position.Y);

            // Add animations that need to be used
            Animator.Animations.Add(new NormalAnimation("Hero-Idle-Right", "Hero/Normal/Idle", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Idle-Left", "Hero/Mirrored/Idle-MIRRORED", 8, 150));
            Animator.Animations.Add(new NormalAnimation("Hero-Run-Right", "Hero/Normal/Run", 8, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Run-Left", "Hero/Mirrored/Run-MIRRORED", 8, 150));
            Animator.Animations.Add(new NormalAnimation("Hero-Jump-Right", "Hero/Normal/Jump", 2, 150));
            Animator.Animations.Add(new MirroredAnimation("Hero-Jump-Left", "Hero/Mirrored/Jump-MIRRORED", 2, 150));

            // Initialize animations
            Animator.InitializeAnimations();

            // Set start animation
            _currentAnimation = Animator.Animations[0];

            // Collision
            Collider = new BoxCollider(Position, "Hero-Collider", 30, 50, _xOffset, _yOffset);
        }

        public void Update(GameTime gameTime)
        {
            // Read input
            MoveDirection = KeyboardReader.ReadInput();

            // Jumping
            JumpCommand.CheckJumping();
            JumpCommand.Execute(this);

            // Move character
            Direction = MoveCommand.Execute(this, MoveDirection);

            // Update collider
            Collider = CollisionManager.UpdateCollider(Position, Collider, _xOffset, _yOffset);

            // Choose animation according to direction
            AnimateCommand.Execute(this, MoveDirection);

            // Animate accordingly
            _currentAnimation = Animator.Animate(AnimToPlay);

            Animator.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_currentAnimation.SpriteSheet, Position, _currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}