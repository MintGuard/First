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

        //public Person(ConsoleKey Key, IPerson PersonToMove)
        //{
        //    this.Directions = new Direction(Position);
        //    Dictionary<ConsoleKey, IZoglushka> dir = new Dictionary<ConsoleKey, IZoglushka>
        //    {
        //        {ConsoleKey.UpArrow, this.Directions.Up},
        //        {ConsoleKey.DownArrow, this.Directions.Down},
        //        {ConsoleKey.LeftArrow, this.Directions.Left},
        //        {ConsoleKey.RightArrow, this.Directions.Right}

        //    };
        //}

        public void Attack(IPerson target)
        {
            //foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
            //{
            //    if (Program.Map[target.Position.x, target.Position.y] == Program.Map[keyValue.Value.x, keyValue.Value.y])
            //    {
                    target.Health -= this.Power;
            //    }
            //}
        }

        public void Move(IZoglushka MoveDirection)
        {
            //Console.WriteLine("Нажми стрелку");
            //Console.ReadKey();
            this.Position = MoveDirection.Around;
                //else
                //{
                //    Console.WriteLine("Не то жмешь");
                //}
    
        }

        
        public virtual void Search(IPerson Target)
        {
            //foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
            //{
            //    if (Program.Map[Target.Position.x, Target.Position.y] == Program.Map[keyValue.Value.x, keyValue.Value.y])
            //    {
                    Console.WriteLine(Target.Position);
            //    }
            //}
        }

        public void Rotate(IZoglushka RotateDirection)
        {
            this.SightDirection = RotateDirection.Sight;
            //if ((Console.ReadKey().Key == ConsoleKey.UpArrow) && (this.SightDirection != "N"))
            //{
            //    this.SightDirection = "N";
            //    return true;
            //}
            //else if ((Console.ReadKey().Key == ConsoleKey.DownArrow) && (this.SightDirection != "S"))
            //{
            //    this.SightDirection = "S";
            //    return true;
            //}
            //else if ((Console.ReadKey().Key == ConsoleKey.LeftArrow) && (this.SightDirection != "W"))
            //{
            //    this.SightDirection = "W";
            //    return true;
            //}
            //else if ((Console.ReadKey().Key == ConsoleKey.RightArrow) && (this.SightDirection != "E"))
            //{
            //    this.SightDirection = "E";
            //    return true;
            //} 
        }
        //public void Rotate()
        //{
        //    foreach (KeyValuePair<ConsoleKey, Position> keyValue in dir)
        //    {
        //        //Console.WriteLine("Нажми стрелку");
        //        //Console.ReadKey();
        //        if ((Console.ReadKey().Key == keyValue.Key) && (Program.Map[keyValue.Value.x, keyValue.Value.y] != Program.Map[this.SightDirection.x, this.SightDirection.y]))
        //        {
        //            this.SightDirection = keyValue.Value;
        //        }
        //    }
        //}
    }
}
