using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;


namespace Terrarim.Models
{
    class Ant : Obj
    {
        public Terrarium Area;
        private int _Id;
        Random Rand = new Random();

        public int Id { get { return _Id; } set { _Id = value; } }

        public Ant(Terrarium Area, int Id)
        {
            this.Area = Area;
            this.Speed = 1;
            this.HP = 10;
            this.Position = Area.Spawn;
            this.Id = Id;
        }
        public override void Move()
        {
            Point Aim = new Point(Rand.Next(-3, 4), Rand.Next(-3, 4));
            if (Aim.X > 0 && Aim.X < Area.XLength && Aim.Y > 0 && Aim.Y < Area.YLenght)
            {
                Move(Aim);
            }
            else
            {
                Aim = new Point(Rand.Next(-3, 4), Rand.Next(-3, 4));
            }
        }
        public void Move(Point Aim)
        {
            Point Temp = new Point();
            Temp.X = Aim.X;
            Temp.Y = Aim.Y;

            double dX, dY, len = 0;

            dX = Math.Abs(Temp.X - Position.X);
            dY = Math.Abs(Temp.Y - Position.Y);

            len = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));

            Position.X += Position.X / dX * Speed;
            Position.Y += Position.Y / dY * Speed;
        }
    }
}
