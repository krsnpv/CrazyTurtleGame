using Microsoft.SmallBasic.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleGame
{
    class Program
    {       

        static void Main(string[] args)
        {
            GraphicsWindow.DrawRectangle(40, 40, GraphicsWindow.Width - 80, GraphicsWindow.Height - 80);
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;            
            Turtle.PenUp();                      

            Random rand = new Random();

            GraphicsWindow.BrushColor = "Red";
            GraphicsWindow.FontSize = 30;
            var food = Shapes.AddRectangle(10, 10);
            int x = rand.Next (55, GraphicsWindow.Width-55);
            int y = rand.Next (55, GraphicsWindow.Height-55);
            Shapes.Move(food, x, y);
            int i = 0;

            while (Turtle.X > 40 && Turtle.X < GraphicsWindow.Width - 40 && Turtle.Y > 40 && Turtle.Y < GraphicsWindow.Height - 45)
            {                             
                
                var counter = Shapes.AddText(i);
                Turtle.Move(5);
                
                if (Turtle.X >= x - 10 && Turtle.X <= x + 10 && Turtle.Y >= y - 10 && Turtle.Y <= y + 5)
                {                    
                    x = rand.Next(55, GraphicsWindow.Width - 55);
                    y = rand.Next(55, GraphicsWindow.Height - 55);
                    Shapes.Move(food, x, y);                        
                    Turtle.Speed++;                    
                    i++;                    
                }
                Shapes.Remove(counter);
            }          
            Shapes.Remove(food);
            Turtle.Hide();
            GraphicsWindow.BrushColor = "Black";
            GraphicsWindow.FontSize = 20;
            var gameover = Shapes.AddText("GAME OVER");
            x = GraphicsWindow.Width / 2 - 45;
            y = GraphicsWindow.Height / 2 - 15;
            Shapes.Move(gameover, x, y);


        }        
        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
                Turtle.Angle = 0;                            
            else if (GraphicsWindow.LastKey == "Right")
                Turtle.Angle = 90;
            else if (GraphicsWindow.LastKey == "Down")
                Turtle.Angle = 180;
            else if (GraphicsWindow.LastKey == "Left")
                Turtle.Angle = 270;                                   
                                           
        }

    }

        
}
