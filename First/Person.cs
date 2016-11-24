using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class Person : IPerson
    {
        public string PersonType { get; set; }
        public string Name { get; set; }
        public string SightDirection { get; set; }
        public Position Position { get; set; }
        public Direction Directions { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public Dictionary<ConsoleKey, IZoglushka> dir;

        public Person()
        {
            this.Directions = new Direction(Position);
        }


        //Метод, возвращающий соседние точки
        public List<IZoglushka> ReturnPoints(Position currentPoint)
        {
            Direction dir = new Direction(this.Position);
            List<IZoglushka> Points = new List<IZoglushka>();
            Points.Add(dir.Up);
            Points.Add(dir.Down);
            Points.Add(dir.Left);
            Points.Add(dir.Right);

            return Points;
        }

        #region Методы персонажей
        public void Attack(IPerson target)
        {
              target.Health -= this.Power;
           
        }

        public virtual void Move()
        {

        }
 
        public virtual void Search()
        {
            
        }

        public virtual void Rotate()
        {

        }
        #endregion
    }
}
