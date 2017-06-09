using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Circle : Shape
    {
        public Circle()
        {
            CanSprint = true;
            IsHeavy = false;
            CanHighJump = false;
            CanGravChange = false;
        }
    }
}
