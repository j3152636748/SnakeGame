using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    
    class SnakeHead
    {
        public int posX;
        public int posY;
        protected string style = "◎";
        public String Style => style;
        
        

        public SnakeHead(int x,int y) {
            posX = x;
            posY = y;
        }
    }
}
