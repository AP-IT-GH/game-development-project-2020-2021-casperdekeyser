using Microsoft.Xna.Framework;

namespace MakingAPlatformer
{
    public class MoveCommand
    {
        private Vector2 _speed;

        public MoveCommand(int runSpeed)
        {
            _speed = new Vector2(runSpeed);
        }

        public Vector2 Execute(ITransform transform, Movement moveDirection)
        {
            Vector2 direction = new Vector2(0,0);

            if (moveDirection == Movement.MoveLeft && transform.Position.X > -62) direction = new Vector2(-1, 0);
            if (moveDirection == Movement.MoveRight && transform.Position.X < 1550-89) direction = new Vector2(1, 0);
            if (!CollisionManager.HorizontalColliding)
            {
                direction.X *= _speed.X;
                transform.Position += direction;
            }

            return direction;
        }
    }
}
