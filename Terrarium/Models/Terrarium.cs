using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Terrarim.Models
{
    class Terrarium
    {
        public Point Spawn;
        public int XLength;
        public int YLenght;
        Random Rand;
        public List<Obj> TerrariumList;

        public Terrarium(int XLength, int YLenght, int AntsCount)
        {
            TerrariumList = new List<Obj>();
            this.XLength = XLength;
            this.YLenght = YLenght;
            this.Spawn = new Point(Rand.Next(0, XLength), Rand.Next(0, YLenght));
            for (int i = 0; i < AntsCount; i++)
            {
                TerrariumList.Add(new Ant(this, i));
            }
        }

        public void Mover()
        {
            foreach (Obj item in TerrariumList)
            {
                item.Move();
            }
        }
    }

}
