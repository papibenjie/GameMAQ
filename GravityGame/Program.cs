﻿using System;

namespace GravityGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var game = new Game1();
            using (game)
                game.Run();
        }
    }
}