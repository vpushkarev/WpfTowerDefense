using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTowerDefence
{
    class Enemy
    {
        List<Cell> wayPoints = new List<Cell>();

        int wayIndex = 0;
        int speed = 10;

        public Enemy(List<Cell> wayPoints)
        {
            this.wayPoints = wayPoints;
        }

        void Update()
        {
            Move();
        }

        private void Move()
        {

        }
    }
}
