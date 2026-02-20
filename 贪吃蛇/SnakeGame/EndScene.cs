using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SnakeGame
{
    class EndScene : IUpdate
    {
        public int nowOption = 0;//当前选项
        public int titTop = 7;//标题初始y
        public int choiceInitTop = 12;//选项初始y
        public int spacing = 4;//选项之间的距离
        public string title = "游戏结束";
        public string choiceOne = "回到开始界面";
        public string choiceTwo = "结束游戏";
        public string[] nowChoice = new string[2];

        // 合并并保留单个无参构造函数，初始化 nowChoice 的元素
        public EndScene()
        {
            nowChoice[0] = choiceOne;
            nowChoice[1] = choiceTwo;
        }

        public void Update()
        {
            Console.SetCursorPosition(0, titTop);//将光标移到标题y处
            Console.ForegroundColor = ConsoleColor.Blue;
            CenterPaint(title, Game.gameLength);//居中打印标题
            perfectPaint(nowChoice, choiceInitTop, spacing);//居中打印选项
            KeyUpdate();
        }
        /// <summary>
        /// 用于将某个字符串在本行居中打印
        /// </summary>
        /// <param name="font"></param 需要打印的的字符>
        /// <param name="gameLen"></param 游戏窗口的长度>
        /// 改进建议 直接在这个方法中添加一个y坐标的参数
        /// 该方法便可以直接在对应y位置的中心出打印字符
        public void CenterPaint(string font, int gameLen)
        {
            int fontLen = font.Length;
            //设置鼠标光标到首个打印字符的位置（居中）
            Console.SetCursorPosition((int)((gameLen - fontLen) / 2), Console.CursorTop);
            //打印字符
            Console.WriteLine(font);
        }

        /// <summary>
        /// 按照居中打印的规则打印开始场景所有的选择
        /// </summary>
        /// <param name="strs"></param 待打印的字符数组>
        /// <param name="initTop"></param 初始字符的y>
        /// <param name="spacing"></param 每行字符串之间的间隔>
        public void perfectPaint(string[] strs, int initTop, int spacing)
        {
            int top = initTop;
            Console.SetCursorPosition(Console.CursorLeft, top);
            for (int i = 0; i < strs.Length; i++)
            {
                //将当前选项的打印颜色变为红色
                if (i == nowOption)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                top += spacing;
                CenterPaint(strs[i], Game.gameLength);
                Console.SetCursorPosition(Console.CursorLeft, top);

            }
        }
        public void ChangeScene()
        {
            Game.nowScene = E_SceneType.beginScene;
            Console.Clear();
        }
        public void KeyUpdate()
        {
            //检测是否有按键按下
            //如果不写判断会产生阻塞导致程序一直等待
            if (Console.KeyAvailable)
            {
                //存储按下按键的信息
                //Console.ReadKey(false)(默认值)：读取按键并显示在控制台。
                //Console.ReadKey(true)：读取按键但隐藏（不显示）在控制台。
                ConsoleKeyInfo key = Console.ReadKey(true);
                //判断当前输入键的种类
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        //当前选项往上转变
                        nowOption -= 1;
                        break;
                    case ConsoleKey.S:
                        //当前选项往下转变
                        nowOption += 1;
                        break;
                    case ConsoleKey.Enter:
                        if (nowOption == 0)
                        {
                            
                            //场景转换
                            ChangeScene();

                        }
                        else
                        {
                            Environment.Exit(0);
                        }

                        break;
                    default:
                        break;
                }
            }
            if (nowOption < 0)
            {
                nowOption = nowChoice.Length - 1;
            }
            else if (nowOption >= nowChoice.Length)
            {
                nowOption = 0;
            }
        }
    }
}
