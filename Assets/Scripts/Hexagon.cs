using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Hexagon : Shape
    {
        public Hexagon()
        {
            CanSprint = false;
            IsHeavy = false;
            CanHighJump = false;
            CanGravChange = true;
        }
    }
}
