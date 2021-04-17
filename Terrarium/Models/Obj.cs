using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Terrarim.Models
{
    abstract class Obj
    {
        public int HP, Speed;
        public Point Position;

        abstract public void Move();
    }
}
