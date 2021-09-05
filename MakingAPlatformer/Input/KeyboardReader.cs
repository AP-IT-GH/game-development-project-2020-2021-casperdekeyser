using Microsoft.Xna.Framework.Input;

namespace MakingAPlatformer
{
    public class KeyboardReader : IInputReader
    {
        public Movement ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                return Movement.MoveLeft;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                return Movement.MoveRight;
            }

            if (state.IsKeyDown(Keys.Space))
            {
                return Movement.Jump;
            }
            // default
            return Movement.Idle;
        }
    }
}
