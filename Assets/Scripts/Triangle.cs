using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Triangle : Shape
    {
        public Triangle()
        {
            CanSprint = false;
            IsHeavy = false;
            CanHighJump = true;
            CanGravChange = false;
        }
    }
}
