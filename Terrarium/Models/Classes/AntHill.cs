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
    class AntHill : Obj
    {
        public AntHill(Terrarium Area)
        {
            Position = new Point();
            this.Area = Area;
            Speed = 1;
            Shape = new Ellipse();
            Shape.Width = Area.Rand.Next(50,140);
            Shape.Height = Area.Rand.Next(50,140);
            Shape.Fill = Brushes.Pink;
            Position.X = Area.Spawn.X - Shape.Width / 2;
            Position.Y = Area.Spawn.Y - Shape.Height / 2;
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
            throw new NotImplementedException();
        }
    }
}
