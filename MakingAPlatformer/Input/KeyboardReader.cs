using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class KeyboardReader : IInputReader
    {
        public bool CheckInput()
        {
            throw new NotImplementedException();
        }

        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                return new Vector2(-1, 0);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                return new Vector2(1, 0);
            }
            return new Vector2(0, 0);
        }
    }
}
