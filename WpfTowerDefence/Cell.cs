using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTowerDefence
{
    class Cell : UserControl
    {
        public double X { get; set; }
        public double Y { get;set;}
        //public double Width { get; set; }
        //public double Height { get; set; }
        //public System.Windows.Media.Color Color { get; set; }

        public Button cellButton;
        public int state;

        public bool isGround => state == 0;

        public Cell(Button cell, double x, double y)
        {
            cellButton = cell;
            X = x;
            Y = y;
        }

        public void SetState(int i)
        {
            state = i;
        }

    }
}
