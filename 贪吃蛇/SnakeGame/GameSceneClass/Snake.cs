using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    internal class Snake : Ipaint
    {
        //当前蛇头的位置
        public int initHeadPosX;
        public int initHeadPosY;

        //蛇头
        private SnakeHead snakeHead;
        //蛇身用一个列表表示
        private List<SnakeBody> snakeBodies;

        //存储蛇尾(便于后续擦除)
        SnakeBody lastBody;
        //当前蛇头前进方向
        private E_Direction nowDirection = E_Direction.Down;

        //初始化蛇
        public Snake(){
            //蛇头的初始位置为奇数
            //否则撞墙判定会提前
            initHeadPosX = 5;
            initHeadPosY = 5;
            snakeHead = new SnakeHead(initHeadPosX, initHeadPosY);
            snakeBodies = new List<SnakeBody>();
            snakeBodies.Add(new SnakeBody(initHeadPosX - 2, initHeadPosY));
            
        }

        //将蛇用不同颜色打印出来
        public void Paint()
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(snakeHead.posX,snakeHead.posY);
            Console.Write(snakeHead.Style);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var i in snakeBodies)
            {
                Console.SetCursorPosition(i.posX, i.posY);
                Console.Write(i.Style);
            }
            
        }

        //在蛇尾出打印空格字符消除
        //否则蛇移动了但尾巴依然存在
        private void ClearTail()
        {
            Console.SetCursorPosition(lastBody.posX, lastBody.posY);
            Console.Write(" ");
        }
        //改变蛇头前进方向
        //并且判断改变方向不为当前方向的相反方向
        public void ChangeDir(E_Direction dir)
        {
            if(nowDirection == E_Direction.Up&&dir == E_Direction.Down
            || nowDirection == E_Direction.Left && dir == E_Direction.Right
            || nowDirection == E_Direction.Down && dir == E_Direction.Up
            || nowDirection == E_Direction.Right && dir == E_Direction.Left)
            {
                return;
            }
            nowDirection = dir;
        }

        public bool JudEat(int posX,int posY)
        {
            if(posX == snakeHead.posX&&posY == snakeHead.posY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ProLong()
        {
            snakeBodies.Add(new SnakeBody(lastBody.posX - 2, lastBody.posY));
        }
        
        //移动方法
        //先移除蛇尾
        //每次将蛇身体移动到前一个身体的位置上，然后将最前面的身体移动到蛇头
        //位置上，最后将蛇头位置通过判断当前前进方向而改变位置
        //注意水平上要移动2个位置而竖直上只移动1个位置
        public void Move()
        {
            lastBody = snakeBodies[snakeBodies.Count()-1];
            ClearTail();
            for (int i = snakeBodies.Count()-1; i > 0; i--)
            {
                snakeBodies[i].posX = snakeBodies[i - 1].posX;
                snakeBodies[i].posY = snakeBodies[i - 1].posY;
            }

            snakeBodies[0].posX = snakeHead.posX;
            snakeBodies[0].posY = snakeHead.posY;
            switch (nowDirection)
            {
                case E_Direction.Right:
                    snakeHead.posX += 2;
                    break;
                case E_Direction.Left:
                    snakeHead.posX -= 2;
                    break;
                case E_Direction.Up:
                    snakeHead.posY -=1;
                    break;
                case E_Direction.Down:
                    snakeHead.posY += 1;
                    break;
                default:
                    break;
            }
        }
        public bool JudBodyColide()
        {
            foreach(SnakeBody snakeBody in snakeBodies)
            {
                if(snakeBody.posX == snakeHead.posX&& snakeBody.posY == snakeHead.posY)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Dead()
        {
            if(snakeHead.posX<=0||snakeHead.posX>=Map.MapLen
            || snakeHead.posY <= 0 || snakeHead.posY >= Map.MapWid-1||JudBodyColide())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
