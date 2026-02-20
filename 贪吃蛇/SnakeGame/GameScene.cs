using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class GameScene : IUpdate
    {
        Map map;
        Food food;
        Snake snake;
        public GameScene()
        {
            map = new Map();
            food = new Food();
            snake = new Snake();
        }
        public void Update()
        {
            map.Paint();
            food.Paint();

            //检测键盘输入
            //并更改对应蛇的前进方向
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);//没加true就会将字符打印到控制台上
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_Direction.Up);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_Direction.Down);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_Direction.Left);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_Direction.Right);
                        break;
                    default:
                        break;
                }
            }

            snake.Move();
            if (snake.Dead())
            {
                Game.nowScene = E_SceneType.endScene;
                Console.Clear();
                return;
            }


            if(snake.JudEat(food.FoodPosX,food.FoodPosY))
            {
                snake.ProLong();
                food.ReGenerate();
            }


            snake.Paint();
            
            Thread.Sleep(100);
        }
    }
}
