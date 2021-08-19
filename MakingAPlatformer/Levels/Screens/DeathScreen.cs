using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public class DeathScreen : Screen
    {
        public override int ScreenId { get; set; } = 3;
        public override Color DrawingColor { get; set; } = Color.Red;

        public DeathScreen(Game1 game) : base(game) { }

    }
}
