using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using Terrarium.Models.Classes;

namespace Terrarium.Models
{
    abstract class Obj
    {
        public Functions Func = new Functions();
        public Terrarium Area;
        public AntHill Home;
        public int HP,Step;
        public Point Position,Aim;
        public Ellipse Shape;
        public double Speed;
        public bool Target;
        public int VisibleRange;

        abstract public void Move();

        abstract public void Move(Point Aim);
        abstract public void FindObject(Obj obj);

        abstract public void GetObject(Obj obj);
    }
}
