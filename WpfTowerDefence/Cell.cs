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
        //List<Button> cells { set; get; }
        Button cell;
        public int state;

        public bool isGround => state == 0;

        public Cell(Button cell)
        {
            this.cell = cell;
        }

        public void SetState(int i)
        {
            state = i;
        }

    }
}
