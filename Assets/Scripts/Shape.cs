using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public abstract class Shape
    {
        public bool IsHeavy { get; set; }
        public bool CanSprint { get; set; }
        public bool CanHighJump { get; set; }
        public bool CanGravChange { get; set; }
    }
}
