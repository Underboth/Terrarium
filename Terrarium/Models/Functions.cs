using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Terrarium.Models

{
    class Functions
    {
   
        public bool InOkr(Point point, Point Okr)
        {
            if (Okr.X + 2 > point.X && Okr.X - 2 < point.X && Okr.Y + 2 > point.Y && Okr.Y - 2 < point.Y)
            {
                return true;
            }
            return false;
        }
        public Point ToOkr(Point Okr, int Epsilon, Terrarium Area)
        {
            Okr.X += Area.Rand.Next(-Epsilon, Epsilon + 1);
            Okr.Y += Area.Rand.Next(-Epsilon, Epsilon + 1);
            return Okr;
        }
        public void Move(Obj obj, Point Aim, int Step)
        {
            if (obj.Func.InOkr(obj.Position, Aim))
            {
                obj.Aim.X = obj.Position.X + obj.Area.Rand.Next(-Step, Step);
                obj.Aim.Y = obj.Position.Y + obj.Area.Rand.Next(-Step, Step);
                obj.Target = false;
            }
            Vector vector = new Vector(Math.Abs(obj.Position.X - Aim.X), Math.Abs(obj.Position.Y - Aim.Y));

            double dX = Math.Abs(obj.Position.X - Aim.X);
            double dY = Math.Abs(obj.Position.Y - Aim.Y);
            double Hypo = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
            double time = Hypo / obj.Speed;


            if (obj.Position.X > Aim.X)
            {
                obj.Position.X -= vector.X / time;
                if (obj.Position.Y > Aim.Y)
                {
                    obj.Position.Y -= vector.Y / time;
                }
                else
                {
                    obj.Position.Y += vector.Y / time;
                }
            }
            else
            {
                obj.Position.X += vector.X / time;
                if (obj.Position.Y > Aim.Y)
                {
                    obj.Position.Y -= vector.Y / time;
                }
                else
                {
                    obj.Position.Y += vector.Y / time;
                }
            }
        }
        public bool InOkr(Point point, Point Okr,int Epsilon)
        {
            if (Okr.X + Epsilon > point.X && Okr.X - Epsilon < point.X && Okr.Y + Epsilon > point.Y && Okr.Y - Epsilon < point.Y)
            {
                return true;
            }
            return false;
        }
    }
}
