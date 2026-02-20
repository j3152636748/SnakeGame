using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SnakeGame
{
    internal class SnakeBody : SnakeHead
    {
        
        String style = "¤";
        public String Style => style;
        public SnakeBody(int x, int y) : base(x, y)
        {
           
        }
    }
}
