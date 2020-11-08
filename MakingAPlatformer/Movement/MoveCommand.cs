using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class MoveCommand : IGameCommand
    {
        public Vector2 Speed;

        public MoveCommand(int runSpeed)
        {
            Speed = new Vector2(runSpeed);
        }

        public void Execute(ITransform transform, Vector2 direction)
        {
            direction.X *= Speed.X;
            transform.Position += direction;
        }
    }
}
