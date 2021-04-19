using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Terrarium.Models.Classes
{
    class Food : Obj
    {
        public int FoodCount;
        Functions Funk = new Functions();

        public Food(Terrarium Area)
        {
            Position = new Point();
            this.Area = Area;
            Shape = new Ellipse();
            Shape.Width = 7;
            Shape.Height = 7;
            Shape.Fill = Brushes.Green;
            FoodCount = Area.Rand.Next(1, 10);
            Position.X = Area.Rand.Next(1, Area.XLength-10);
            Position.Y = Area.Rand.Next(1, Area.YLenght-10);
            Speed = 3;
            for (int i = 0; i < FoodCount; i++)
            {
                Area.TerrariumList.Add(new Food(Position.X + Area.Rand.Next(-3, 4), Position.Y + Area.Rand.Next(-3, 4),Area));
            }
        }
        public Food(double x, double y, Terrarium Area)
        {
            this.Area = Area;
            Position = new Point();
            Shape = new Ellipse();
            Shape.Width = 7;
            Shape.Height = 7;
            Shape.Fill = Brushes.Green;
            FoodCount = Area.Rand.Next(1, 10);
            Position.X = x;
            Position.Y = y;
            Speed = 3;   
        }

        public override void FindObject(Obj obj)
        {

        }

        public override void GetObject(Obj obj)
        {
            
        }

        public override void Move()
        {
            
        } 

        public override void Move(Point Aim)
        {
            Func.Move(this, Aim, 30);
        }
    }
}
