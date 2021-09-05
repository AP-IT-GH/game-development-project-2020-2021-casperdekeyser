
namespace MakingAPlatformer.Sound.Music
{
    public class BackGroundTrack : MusicTrack
    {
        public  override string FilePath { get; set; } = "Sound/background-music";
        public override int[] LevelsToPlayTrack { get; set; } = { 0, 1 };
    }
}
