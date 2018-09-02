using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTowerDefence
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        int fieldHeight = 6, fieldWight = 9;
        List<Cell> wayPoints = new List<Cell>();
        Cell firstCell;
        int currWayX, currWayY;

        Cell[,] allCells = new Cell[6, 9];

        string[] path =
    {
        "010000000",
        "010001111",
        "010001000",
        "011111000",
        "000000000",
        "000000000",
    };

        public Game()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateLevel();
            LoadWaypoints();

        }

        private void CreateLevel()
        {
            for (int i = 0; i < fieldHeight; i++)
                for (int k = 0; k < fieldWight; k++)
                {
                    int GroundIndex = int.Parse(path[i].ToCharArray()[k].ToString());
                    var color = (GroundIndex == 0) ? Brushes.Brown : Brushes.Gray;

                    CreateCell(color, GroundIndex, k, i);
                }
        }

        private void CreateCell(SolidColorBrush color, int GroundIndex, int x, int y)
        {
            int x0 = 10, y0 = 10;

            Button cellButton = CreateButton(new Point(x0 + (x * 50), y0 + (y * 50)), color);
            CanvasMap.Children.Insert(0, cellButton);

            Cell cell = new Cell(cellButton);
            cell.SetState(GroundIndex);

            if (!cell.isGround && firstCell == null)
            {
                firstCell = cell;
                currWayX = x;
                currWayY = y;
            }

            allCells[y, x] = cell;
        }

        private Button CreateButton(Point point, Brush brush)
        {
            Button cell = new Button();
            cell.Width = 45;
            cell.Height = 45;
            cell.Background = brush;
            Canvas.SetLeft(cell, point.X);
            Canvas.SetTop(cell, point.Y);
            return cell;
        }

        private void LoadWaypoints()
        {
            Cell currWayGo;
            wayPoints.Add(firstCell);

            while (true)
            {
                currWayGo = null;

                if (currWayX > 0 && !allCells[currWayY, currWayX - 1].isGround &&
                    !wayPoints.Exists(x => x == allCells[currWayY, currWayX - 1]))
                {
                    currWayGo = allCells[currWayY, currWayX - 1];
                    currWayX--;
                    Debug.WriteLine("Next Cell is Left");
                }
                else if (currWayX < (fieldWight - 1) && !allCells[currWayY, currWayX + 1].isGround &&
                    !wayPoints.Exists(x => x == allCells[currWayY, currWayX + 1]))
                {
                    currWayGo = allCells[currWayY, currWayX + 1];
                    currWayX++;
                    Debug.WriteLine("Next Cell is Right");
                }
                else if(currWayY > 0 && !allCells[currWayY - 1, currWayX].isGround &&
                    !wayPoints.Exists(x => x == allCells[currWayY - 1, currWayX]))
                {
                    currWayGo = allCells[currWayY - 1, currWayX];
                    currWayY--;
                    Debug.WriteLine("Next Cell is Up");
                }
                else if(currWayY < (fieldHeight - 1) && !allCells[currWayY + 1, currWayX].isGround &&
                    !wayPoints.Exists(x => x == allCells[currWayY + 1, currWayX]))
                {
                    currWayGo = allCells[currWayY + 1, currWayX];
                    currWayY++;
                    Debug.WriteLine("Next Cell is Down");
                }
                else
                {
                    Debug.WriteLine("Upss break");
                    break;
                }

                wayPoints.Add(currWayGo);
            }
        }

        

    }
}

