using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Square : Shape
    {
        public Square()
        {
            CanSprint = false;
            IsHeavy = true;
            CanHighJump = false;
            CanGravChange = false;
        }
    }
}
