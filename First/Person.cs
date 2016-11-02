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
        public Position SightDirection { get; set; }
        public Position Position { get; set; }
        public PointsAround ClosePoints { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public Dictionary<ConsoleKey, Position> dir;

        public Person()
        {

        }

        public Person(ConsoleKey Key, Position ClosePoints, IPerson PersonToMove)
        {
            this.ClosePoints = new PointsAround(Position);
            Dictionary<ConsoleKey, Position> dir = new Dictionary<ConsoleKey, Position>
            {
                {ConsoleKey.UpArrow, this.ClosePoints.Up},
                {ConsoleKey.DownArrow, this.ClosePoints.Down},
                {ConsoleKey.LeftArrow, this.ClosePoints.Left},
                {ConsoleKey.RightArrow, this.ClosePoints.Right},
            };
        }

        public void Attack(IPerson target)
        {
            foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
            {
                if (Program.Map[target.Position.x, target.Position.y] == Program.Map[keyValue.Value.x, keyValue.Value.y])
                {
                    target.Health -= this.Power;
                }
            }
        }

        public void Move(IPerson PersonToMove)
        {
            foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
            {
                //Console.WriteLine("Нажми стрелку");
                //Console.ReadKey();
                if ((Console.ReadKey().Key == keyValue.Key) && (Program.Map[keyValue.Value.x, keyValue.Value.y] == "N"))
                {
                    Program.Map[this.Position.x, this.Position.y] = "N";
                    this.Position = keyValue.Value;
                }
                //else
                //{
                //    Console.WriteLine("Не то жмешь");
                //}

            }
        }


        public virtual void Search(IPerson Target)
        {
            foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
            {
                if (Program.Map[Target.Position.x, Target.Position.y] == Program.Map[keyValue.Value.x, keyValue.Value.y])
                {
                    Console.WriteLine(Target.Position);
                }
            }
        }

        //public void Rotate(string RotateDirection)
        //{
        //    this.SightDirection = RotateDirection;
        //}
        public void Rotate()
        {
            foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
            {
                //Console.WriteLine("Нажми стрелку");
                //Console.ReadKey();
                if ((Console.ReadKey().Key == keyValue.Key) && (Program.Map[keyValue.Value.x, keyValue.Value.y] != Program.Map[this.SightDirection.x, this.SightDirection.y]))
                {
                    this.SightDirection = keyValue.Value;
                }
            }
        }
    }
}
