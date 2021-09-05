
namespace MakingAPlatformer.Sound.Music
{
    public class DeathTrack : MusicTrack
    {
        public override string FilePath { get; set; } = "Sound/death-music";
        public override int[] LevelsToPlayTrack { get; set; } = { 3 };
    }
}
