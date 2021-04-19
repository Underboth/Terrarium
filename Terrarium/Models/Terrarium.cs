using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Terrarium.Models.Classes;

namespace Terrarium.Models
{
    class Terrarium
    {
        public Random Rand;
        public Point Spawn;
        public int XLength;
        public int YLenght;
        public List<Obj> TerrariumList;
        public AntHill Home;

        public Terrarium(int XLength, int YLenght, int AntsCount, int FoodCount)
        {
            Rand = new Random();
            TerrariumList = new List<Obj>();
            this.XLength = XLength;
            this.YLenght = YLenght;
            this.Spawn = new Point(Rand.Next(50,XLength-50), Rand.Next(50,YLenght-50));
            Home = new AntHill(this);
            TerrariumList.Add(Home);
            TerrariumList.Add(new Queen(this, Home));
            for (int i = 0; i < FoodCount; i++)
            {
                TerrariumList.Add(new Food(this));
            }
            for (int i = 0; i < AntsCount; i++)
            {
                TerrariumList.Add(new Ant(this,Home));
            }
           
        }

        public void Mover()
        {
            for (int i = 0; i < TerrariumList.Count; i++)
            {
                if (TerrariumList[i].Target==false)
                {
                    TerrariumList[i].Move();
                }
                else
                {
                    TerrariumList[i].Move(TerrariumList[i].Aim);
                }
                    
            }
        }
    }

}
