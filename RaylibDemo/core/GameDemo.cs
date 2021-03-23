using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace RaylibDemo.core
{
    public class GameDemo
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            const int screenWidth = 1280;
            const int screenHeight = 720;

            Raylib.InitWindow(screenWidth, screenHeight, "DemoGame");
        }
    }
}