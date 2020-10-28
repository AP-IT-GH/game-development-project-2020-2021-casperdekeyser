using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class MoveCommand : IGameCommand
    {
        public Vector2 Speed;

        public MoveCommand(int speed)
        {
            Speed = new Vector2(speed, 0);
        }

        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= Speed;
            transform.Position += direction;
        }
    }
}
