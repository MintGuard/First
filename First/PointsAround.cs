using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class PointsAround
    {
        private Position Up = new Position();
        private Position Down = new Position();
        private Position Left = new Position();
        private Position Right = new Position();

        public PointsAround(Position point)
        {
            AroundPointsUpdate(point);
        }
        /// <summary>
        /// Метод обновления соседних координат
        /// </summary>
        /// <param name="point">Координаты исходного объекта</param>
        public void AroundPointsUpdate(Position point)
        {
            //ToDo Выяснить, можно ли выполнить операцию присвоения группе объектов, записанную через запятую
            Up = point;
            Down = point;
            Left = point;
            Right = point;
            Up.x--;
            Down.x++;
            Left.y--;
            Right.y++;
        }
    }
}
