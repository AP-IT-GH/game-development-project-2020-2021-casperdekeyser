using Microsoft.Xna.Framework;

namespace MakingAPlatformer
{
    public class MoveCommand
    {
        private Vector2 _speed;
        private int _leftBorder = -62;
        private int _rightBorder = 1550 - 89;

        public MoveCommand(int runSpeed)
        {
            _speed = new Vector2(runSpeed);
        }

        public Vector2 Execute(ITransform transform, Movement moveDirection)
        {
            Vector2 direction = new Vector2(0,0);

            if (moveDirection == Movement.MoveLeft && transform.Position.X > _leftBorder) direction = new Vector2(-1, 0);
            if (moveDirection == Movement.MoveRight && transform.Position.X < _rightBorder) direction = new Vector2(1, 0);

            if (!CollisionManager.HorizontalColliding) Move(direction, transform);

            return direction;
        }

        private void Move(Vector2 direction, ITransform transform)
        {
            direction.X *= _speed.X;
            transform.Position += direction;
        }
    }
}
