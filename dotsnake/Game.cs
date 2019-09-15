using System;
using System.Threading;

namespace snake
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    class Game
    {
        static readonly int x = 80;
        static readonly int y = 26;
        static TextLine gg;
        static Walls walls;
        static FoodFactory foodFactory;
        static Snake snake;
        static Timer time;

        static void Loop(object obj)
        {
            if (walls.IsHit(snake.Head) || snake.IsHitItself)
            {
                gg.WriteTextLine();
                time.Dispose();
                ConsoleKeyInfo k;
                do
                {
                    k = Console.ReadKey();
                }
                while (k.Key != ConsoleKey.Enter);
                Init();
            }
            else if (FoodFactory.IsEaten(snake.Head))
            {
                foodFactory.CreateFood();
            }
            else
            {
                snake.Move();
                if(snake.counter >= snake.str.Length)
                {
                    TextLine won = new TextLine("YOU WIN!!! :)", ( x - "YOU WIN!!! :)".Length) / 2, y / 2 - 1);
                    TextLine w = new TextLine(snake.str, (x - snake.str.Length) / 2, y / 2 + 1);
                    time.Dispose();
                    snake.Dispose();
                    won.WriteTextLine();
                    w.WriteTextLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;

            
            foodFactory = new FoodFactory(x, y, '@');
            gg = new TextLine("Game over! Press Enter to try again!", (x - "Game over! Press Enter to try again!".Length) / 2, y / 2);
            Init();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.Rotation(key.Key);
                }
            }
        }

        static void Init()
        {
            FoodFactory.Food.Clear();
            snake?.Dispose();
            gg?.Clear();
            walls = new Walls(x, y, '#');
            foodFactory.CreateFood();
            snake = new Snake(x / 2, y / 2, 4);
            time = new Timer(Loop, null, 0, 95);

        }
    }
}
