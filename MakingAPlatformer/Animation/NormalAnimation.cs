
namespace MakingAPlatformer
{
    public class NormalAnimation : Animation
    {

        public NormalAnimation(string name, string path, int frames, int width) : base(name, path, frames, width) { }
             
        public override void FrameCountConditions()
        {
            if (frameMovement >= CurrentFrame.SourceRectangle.Width / framesPerSecond)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
                counter = 0;
        }
    }
}
