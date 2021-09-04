using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Interfaces
{
    public interface IJumpable
    {
        JumpCommand JumpCommand { get; set; }
    }
}
