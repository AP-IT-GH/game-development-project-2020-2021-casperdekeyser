using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MakingAPlatformer
{
    public class JumpCommand
    {
        public float CurrentHeight;

        private bool _rising = false;
        private bool _falling = false;
        private bool _jumping = false;
        private int _jumpSpeed = 5;
        private int _jumpHeight = 150;
        private float _startY;
        private float _ground;

        public JumpCommand(int speed, int height, float ground)
        {
            _jumpSpeed = speed;
            _jumpHeight = height;
            _startY = ground;
            CurrentHeight = ground;
            _ground = ground;
        }

        public void CheckJumping()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space) && (!_jumping) && (!_falling))
            {
                Hero.State = States.Jumping;
                _rising = true;
            }
        }

        public void Execute(IGameObject Hero)
        {
            if (_falling && !CollisionManager.VerticalColliding)
            {
                CurrentHeight += _jumpSpeed; // falling speed
                Hero.Position = new Vector2(Hero.Position.X, CurrentHeight);
                Hero.Direction = new Vector2(Hero.Position.X, CurrentHeight);

                if (Hero.Position.Y >= _startY)
                {
                    Hero.Position = new Vector2(Hero.Position.X, _startY);
                    _falling = false;
                    MakingAPlatformer.Hero.State = States.Idling;
                    _jumping = false;
                    _startY = Hero.Position.Y;
                }
            }

            if (_rising)
            {
                _jumping = true;
                Hero.Position = new Vector2(Hero.Position.X, CurrentHeight);
                if (Hero.Position.Y <= _startY - _jumpHeight)
                {
                    _rising = false;
                    _falling = true;
                }
                CurrentHeight -= _jumpSpeed; // rising speed
            }

            if (CollisionManager.VerticalColliding)
            {
                MakingAPlatformer.Hero.State = States.Idling;
                _jumping = false;
                _falling = false;
                _startY = Hero.Position.Y;
            }

            else
            {
                if(!_jumping) _startY = _ground; // FIX
            }

            if (!CollisionManager.VerticalColliding && (!_jumping) && (Hero.Position.Y < _ground))
            {
                _falling = true;
            }
        }
    }
}
