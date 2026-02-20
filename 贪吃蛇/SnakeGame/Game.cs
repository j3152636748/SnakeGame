using System.Runtime.InteropServices;

namespace SnakeGame
{
    class Game
    {
        //初始化当前游戏的场景类型
        public static E_SceneType nowScene = E_SceneType.beginScene;
        //初始化游戏的长和宽(注意不能小于控制台设置的初始宽高)
        public static int gameLength = 90;
        public static int gameWidth = 30;
       
        

        static void Main(string[] args)
        {
            
            
            //设置缓冲区大小（内部逻辑大小）
            // 注意：必须先设置缓冲区或确保窗口不大于缓冲区
            Console.SetBufferSize(gameLength, gameWidth);
            //设置窗口大小
            Console.SetWindowSize(gameLength, gameWidth);

            //if (gameLengthPlus % 2 == 0)
            //{
            //    gameLengthPlus -= 2;
            //}
            //else
            //{
            //    gameLengthPlus -= 1; 
            //}


            List<IUpdate> Scenes = new List<IUpdate>();
            Scenes.Add(new BeginScene());
            Scenes.Add(new GameScene());
            Scenes.Add(new EndScene());
            Console.CursorVisible = false;
            while (true)
            {
                switch (nowScene)
                {
                    case E_SceneType.beginScene:
                        Scenes[0].Update();
                        break;
                    case E_SceneType.gameScene:
                        Scenes[1].Update();
                        break;
                    case E_SceneType.endScene:
                        Scenes[1] = new GameScene();
                        Scenes[2].Update();
                        break;
                }
            }
        }
    }
}
