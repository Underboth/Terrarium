using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terrarium.Models.Classes;
using Terrarium.Models;

namespace Terrarium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Models.Terrarium AREA;
        Models.Functions Funk = new Models.Functions();
        Point P = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Drawer(Models.Terrarium Area)
        {
            for (int i = 0; i < Area.TerrariumList.Count; i++)
            {
                Canvas.SetLeft(Area.TerrariumList[i].Shape, Area.TerrariumList[i].Position.X);
                Canvas.SetTop(Area.TerrariumList[i].Shape, Area.TerrariumList[i].Position.Y);
                AreaCanvas.Children.Insert(i, Area.TerrariumList[i].Shape);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            AreaCanvas.Children.Clear();
            Drawer(AREA);
            AREA.Mover();
            for (int i = 0; i < AREA.TerrariumList.Count; i++)
            {
                for (int j = 0; j < AREA.TerrariumList.Count; j++)
                {
                    if (Funk.InOkr(AREA.TerrariumList[i].Position, AREA.TerrariumList[j].Position,3))
                    {
                        AREA.TerrariumList[i].GetObject(AREA.TerrariumList[j]);
                    }
                    if (Funk.InOkr(AREA.TerrariumList[i].Position, AREA.TerrariumList[j].Position, AREA.TerrariumList[i].VisibleRange))
                    {
                        AREA.TerrariumList[i].FindObject(AREA.TerrariumList[j]);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AREA = new Models.Terrarium((int)AreaCanvas.ActualWidth, (int)AreaCanvas.ActualHeight,20,30);
            
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(1000);
            timer.IsEnabled = true;
        }

        private void AreaCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            P = Mouse.GetPosition(Application.Current.MainWindow);
            AREA.TerrariumList.Add(new Food(P.X,P.Y,AREA));
        }

        private void AreaCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            P = Mouse.GetPosition(Application.Current.MainWindow);
            AREA.TerrariumList.Add(new Ant(AREA,AREA.Home,P));
        }
    }
}
