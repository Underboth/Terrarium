using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Media;
using Terrarium.Models.Classes;

namespace Terrarium.Models
{
    
    class Ant : Obj
    {
        Functions Funk = new Functions();
        
        
        public Ant(Terrarium Area,AntHill Home)
        {
            VisibleRange = 20;
            Target = false;
            this.Home = Home;
            Position = new Point();
            Aim = new Point();
            this.Area = Area;
            Speed = 3;
            Position.X = Area.Spawn.X;
            Position.Y = Area.Spawn.Y;
            Shape = new Ellipse();
            Shape.Width = 5;
            Shape.Height = 5;
            Shape.Fill = Brushes.Brown;
            Aim.X = Position.X + Area.Rand.Next(-30, 31);
            Aim.Y = Position.Y + Area.Rand.Next(-30, 31);
            Step = 30;
        }

        public Ant(Terrarium Area, AntHill Home, Point positio)
        {
            VisibleRange = 40;
            Target = false;
            this.Home = Home;
            Position = new Point();
            Aim = new Point();
            this.Area = Area;
            Speed = 3;
            Shape = new Ellipse();
            Shape.Width = 5;
            Shape.Height = 5;
            Shape.Fill = Brushes.Brown;
            Aim.X = Position.X + Area.Rand.Next(-30, 31);
            Aim.Y = Position.Y + Area.Rand.Next(-30, 31);
            Step = 30;
            this.Position.X = positio.X;
            this.Position.Y = positio.Y;
        }

        public override void FindObject(Obj obj)
        {
            if (obj is Food && !obj.Func.InOkr(obj.Position, Area.Spawn,
                (int)((int)Home.Shape.Width + (int)Home.Shape.Height) / 3)
                && this.Target == false && obj.Target == false)
            {
                Aim.X = obj.Position.X;
                Aim.Y = obj.Position.Y;
            }
        }

        public override void GetObject(Obj obj)
        {
            if (obj is Food && !obj.Func.InOkr(obj.Position,Area.Spawn, 
                (int)((int)Home.Shape.Width + (int)Home.Shape.Height)/4) 
                && this.Target==false && obj.Target==false)
            {
                Aim.X = Funk.ToOkr(Area.Spawn, (int)((int)Home.Shape.Width + (int)Home.Shape.Height) / 6, Area).X;
                Aim.Y = Funk.ToOkr(Area.Spawn, (int)((int)Home.Shape.Width + (int)Home.Shape.Height) / 6, Area).Y;

                obj.Aim.X = this.Aim.X;
                obj.Aim.Y = this.Aim.Y;
                this.Target = true;
                obj.Target = true;
                this.Move(Aim);
                obj.Move(Aim);
            }
        }

        public override void Move()
        {
            if (Aim.X >1 && Aim.X < Area.XLength && Aim.Y > 1 && Aim.Y < Area.YLenght)
            {
                Move(Aim);
            }
            else
            {
                Aim.X = Position.X + Area.Rand.Next(-50, 51);
                Aim.Y = Position.Y + Area.Rand.Next(-50, 51);
            }
        }

        public override void Move(Point Aim)
        {
            Func.Move(this, Aim,Step);
        }
    }
}
