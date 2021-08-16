using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class MoveCommand
    {
        public Vector2 Speed;
        public CollisionManager cm;

        public MoveCommand(int runSpeed)
        {
            Speed = new Vector2(runSpeed);
        }

        public Vector2 Execute(ITransform transform, Movement moveDirection)
        {
            Vector2 direction = new Vector2(0,0);
            if (moveDirection == Movement.MoveLeft && transform.Position.X > -62)
            {
                direction = new Vector2(-1, 0);
            }
            if (moveDirection == Movement.MoveRight && transform.Position.X < 1550-89)
            {
                direction = new Vector2(1, 0);
            }
            
            if (!CollisionManager.HorizontalColliding)
            {
                direction.X *= Speed.X;
                transform.Position += direction;
            }

            return direction;
        }
    }
}
