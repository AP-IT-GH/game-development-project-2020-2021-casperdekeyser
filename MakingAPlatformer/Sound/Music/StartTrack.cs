
namespace MakingAPlatformer.Sound.Music
{
    public class StartTrack : MusicTrack
    {
        public override string FilePath { get; set; } = "Content/mainmenu-music";
        public override int[] LevelsToPlayTrack { get; set; } = { 4 };
    }
}
