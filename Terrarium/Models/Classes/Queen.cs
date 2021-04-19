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
    class Queen : Obj
    {
        AntHill Home;
        Functions Funk = new Functions();
        Point StepRange;
        public Queen(Terrarium Area, AntHill Home)
        {
            this.Home = Home;    
            Position = new Point();
            Aim = new Point();
            this.Area = Area;
            Speed = 0.5;
            Position.X = Area.Spawn.X;
            Position.Y = Area.Spawn.Y;
            Shape = new Ellipse();
            Shape.Width = 10;
            Shape.Height = 10;
            Shape.Fill = Brushes.Red;
            Aim.X = Position.X + Area.Rand.Next(-10, 11);
            Aim.Y = Position.Y + Area.Rand.Next(-10, 11);
            Step = 10;
            Target = false;
            VisibleRange = 40;
            StepRange = new Point(Area.Spawn.X - Shape.Width / 2, Area.Spawn.Y - Shape.Width / 2);
        }
        public override void Move()
        {
            if (Func.InOkr(Aim, StepRange, 70))
            {
                Move(Aim);
            }
            else
            {
                Aim.X = Position.X + Area.Rand.Next(-10, 11);
                Aim.Y = Position.Y + Area.Rand.Next(-10, 11);
            }
        }

        public override void FindObject(Obj obj)
        {
            if (obj is Food && obj.Func.InOkr(this.Position,StepRange,70)
                && this.Target == false)
            {
                Aim.X = obj.Position.X;
                Aim.Y = obj.Position.Y;
            }
        }

        public override void Move(Point Aim)
        {
            Func.Move(this, Aim, Step);
        }

        public override void GetObject(Obj obj)
        {
            if (obj is Food && obj.Func.InOkr(this.Position, StepRange, 70)
                && this.Target == false)
            {
                Area.TerrariumList.Remove(obj);
                Area.TerrariumList.Add(new Ant(Area, Home, this.Position));
            }
        }
    }
}
