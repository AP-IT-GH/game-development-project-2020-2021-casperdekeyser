
namespace MakingAPlatformer
{
    public class MirroredAnimation : Animation
    {
        public MirroredAnimation(string name, string path, int frames, int width) : base(name, path, frames, width) { }

        public override void FrameCountConditions()
        {
            if (frameMovement >= CurrentFrame.SourceRectangle.Width / framesPerSecond)
            {
                counter--;
                frameMovement = 0;
            }

            if (counter <= 0)
                counter = frames.Count - 1;
        }
    }
}
