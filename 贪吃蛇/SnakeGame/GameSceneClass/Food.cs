using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    internal class Food : Ipaint
    {
        Random random;
        int foodPosX;
        int foodPosY;

        public int FoodPosX => foodPosX;
        public int FoodPosY => foodPosY;

        string foodShape = "●";
        public Food()
        {
            random = new Random();
            foodPosX = random.Next(1,Map.MapLen-1);
            //将食物的x坐标控制为奇数
            if (foodPosX % 2 == 0)
            {
                foodPosX++;
            }
            foodPosY = random.Next(1,Map.MapWid-1);
        }
        public void Paint()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(foodPosX, foodPosY);
            Console.WriteLine(foodShape);
            
        }

        public void ReGenerate()
        {
            foodPosX = random.Next(1, Map.MapLen - 1);
            //将食物的x坐标控制为奇数
            if (foodPosX % 2 == 0)
            {
                foodPosX++;
            }
            foodPosY = random.Next(1, Map.MapWid - 1);
        }
    }
}
