using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfTowerDefence
{
    class Enemy : UserControl
    {
        public List<Cell> wayPoints = new List<Cell>();
        Label enemyLable;

        int wayIndex = 0;
        int speed = 10;

        public Enemy(List<Cell> wayPoints, Canvas CanvasMap)
        {
            this.wayPoints = wayPoints;
            enemyLable = CreateEnemyLable(new Point(wayPoints[wayIndex].X, wayPoints[wayIndex].Y), Brushes.Red);
            CanvasMap.Children.Add(enemyLable);
        }

        private Label CreateEnemyLable(Point point, Brush brush)
        {
            Label cell = new Label();
            cell.Width = 45;
            cell.Height = 45;
            cell.Background = brush;
            Canvas.SetLeft(cell, point.X);
            Canvas.SetTop(cell, point.Y);
            return cell;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            if (wayIndex < wayPoints.Count - 1)
            {
                wayIndex++;
            }
            else
            {
                //Прекращение игры вывод сообщения "Проиграл"

            }

            Cell currWayPoint = wayPoints[wayIndex];

            int left = (int)currWayPoint.X;
            int top = (int)currWayPoint.Y;
            Canvas.SetLeft(enemyLable, left);
            Canvas.SetLeft(enemyLable, top);


            //Transform currWayPoint = wayPoints[wayIndex].transform;
            //Vector3 currWayPos = new Vector3(currWayPoint.position.x + currWayPoint.GetComponent<SpriteRenderer>().
            //    bounds.size.x / 2,
            //    currWayPoint.position.y - currWayPoint.GetComponent<SpriteRenderer>().bounds.size.y / 2);

            //Vector3 dir = currWayPos - transform.position;

            //transform.Translate(dir.normalized * Time.deltaTime * speed);
            //if (Vector3.Distance(transform.position, currWayPos) < 0.1f)
            //{
            //    if (wayPointIndex < wayPoints.Count - 1)
            //    {
            //        wayPointIndex++;
            //    }
            //    else
            //    {
            //        Destroy(gameObject);
            //    }
            //}
        }
    }
}
