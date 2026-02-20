using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    internal class Map : Ipaint
    {
        //地图尺寸
        private static int mapLen = Game.gameLength;
        private static int mapWid = Game.gameWidth;

        public static int MapLen => mapLen;
        public static int MapWid => mapWid;

        private string edgeFont = "■";

        public Map()
        {

            //由于当控制台长度为偶数时，最后一个字符为空字符
            //因此但控制台长度为偶数时我们设置地图长度为控制台长度-1
            
            if (Game.gameLength % 2 == 0)
            {
                mapLen = Game.gameLength - 1;
            }
            
        }

        public void Paint()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < mapWid; i++)
            {
                if (i == 0 || i == mapWid - 1)
                {
                    PaintRow(i, mapLen);
                }
                else
                {
                    PaintComRow(i, mapLen);
                }
            }
        }
        public void PaintRow(int rowSeq,int length)
        {
            //每两个字符打印一个地图块
            for(int i = 0; i < length; i+=2)
            {
                Console.SetCursorPosition(i, rowSeq);
                Console.Write(edgeFont);
            }
        }

        public void PaintComRow(int rowSeq,int length)
        {
            //分别打印首位两个字符块
            Console.SetCursorPosition(0, rowSeq);
            Console.Write(edgeFont);
            Console.SetCursorPosition(length-1, rowSeq);
            Console.Write(edgeFont);

        }
    }
}
