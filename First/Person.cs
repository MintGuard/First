using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class Person: IPerson
    {
        public string PersonType { get; set; }
        public string Name { get; set; }
        public string SightDirection { get; set; }
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
    
        //ToDo Исправить методы Мув и переделать или дописать методы Серч и Ротэйт
    //    public void MovePlayer(string Direction)
    //    {
    //    if (Direction == "W")
    //        {
    //            if (Program.Map[this.Position.x - 1, this.Position.y] == "N")
    //                {
    //                    this.Position.x--;
    //                    Program.Map[this.Position.x, this.Position.y] = "P";
    //                    Program.Map[this.Position.x + 1, this.Position.y] = "N";
    //                }
    //            else
    //                {
    //                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
    //                }     
    //            }
    //    else if (Direction == "E") 
    //        {
    //            if (Program.Map[this.Position.x + 1, this.Position.y] == "N")
    //                {
    //                    this.Position.x++;
    //                    Program.Map[this.Position.x, this.Position.y] = "P";
    //                    Program.Map[this.Position.x - 1, this.Position.y] = "N";
    //                }
    //             else
    //                {
    //                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
    //                }
    //            }
    //    else if (Direction == "S")
    //        {
    //            if (Program.Map[this.Position.x, this.Position.y - 1] == "N")
    //                {
    //                    this.Position.y--;
    //                    Program.Map[this.Position.x, this.Position.y] = "P";
    //                    Program.Map[this.Position.x, this.Position.y + 1] = "N";
    //                }
    //            else
    //                {
    //                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
    //                }
    //            }
    //    else if (Direction == "N")
    //    {
    //        if (Program.Map[this.Position.x, this.Position.y + 1] == "N")
    //        {
    //            this.Position.y++;
    //            Program.Map[this.Position.x, this.Position.y] = "P";
    //            Program.Map[this.Position.x, this.Position.y - 1] = "N";
    //        }
    //        else
    //        {
    //            Console.WriteLine("Чувак там вроде кто то стоит, не?");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Нет такого направления");
    //    }
    //}
    //    public void MobsMove(string Direction) 
    //    {
    //        if (Direction == "W")
    //        {
    //            if (Program.Map[this.Position.x - 1, this.Position.y] == "N")
    //            {
    //                this.Position.x--;
    //                Program.Map[this.Position.x, this.Position.y] = "M";
    //                Program.Map[this.Position.x + 1, this.Position.y] = "N";
    //            }
    //            else
    //            {
    //                this.Position.x++;
    //                Program.Map[this.Position.x, this.Position.y] = "M";
    //                Program.Map[this.Position.x - 1, this.Position.y] = "N";
    //            }
    //        }
    //        if (Direction == "E")
    //        {
    //            if (Program.Map[this.Position.x + 1, this.Position.y] == "N")
    //                {
    //                    this.Position.x++;
    //                    Program.Map[this.Position.x, this.Position.y] = "M";
    //                    Program.Map[this.Position.x - 1, this.Position.y] = "N";
    //                }
    //            else 
    //                {
    //                    this.Position.x--;
    //                    Program.Map[this.Position.x, this.Position.y] = "M";
    //                    Program.Map[this.Position.x + 1, this.Position.y] = "N";
    //                }
    //        }
    //        if (Direction == "N")
    //        {
    //            if (Program.Map[this.Position.x, this.Position.y + 1] == "N")
    //                {
    //                    this.Position.y++;
    //                    Program.Map[this.Position.x, this.Position.y] = "M";
    //                    Program.Map[this.Position.x, this.Position.y - 1] = "N";
    //                }
    //            else 
    //                {
    //                    this.Position.y--;
    //                    Program.Map[this.Position.x, this.Position.y] = "M";
    //                    Program.Map[this.Position.x, this.Position.y + 1] = "N";
    //                }
    //        }
    //        if (Direction == "S")
    //        {
    //            if (Program.Map[this.Position.x, this.Position.y - 1] == "N")
    //                {
    //                    this.Position.y--;
    //                    Program.Map[this.Position.x, this.Position.y] = "M";
    //                    Program.Map[this.Position.x, this.Position.y + 1] = "N";
    //                }
    //            else 
    //                {
    //                    this.Position.y++;
    //                    Program.Map[this.Position.x, this.Position.y] = "M";
    //                    Program.Map[this.Position.x, this.Position.y - 1] = "N";
    //                }
    //        }
    //    }
        //public virtual void Search(List<Mob> Mobs, IPerson Player, int x, int y)
        //{
        //    foreach (Mob SelectesMob in Mobs)
        //{
        //    {
        //        if (((SelectesMob.Position.x == (Player.Position.x - 1)) && (SelectesMob.Position.y == Player.Position.y)) |
        //                       ((SelectesMob.Position.x == (Player.Position.x + 1)) && (SelectesMob.Position.y == Player.Position.y)) |
        //                       ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y - 1))) |
        //                       ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y + 1))))
        //        {
        //            int[] coor = { x, y };
        //            SelectesMob.Position.x = x;
        //            SelectesMob.Position.y = y;
        //            Console.WriteLine("Координаты мобов" + ":" + " " + coor);
        //        }
        //        else {
        //            Console.WriteLine("Поблизости нет мобов");
        //            }
        //        }
        //    }
        //}
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

        public void Rotate(string RotateDirection)
        {
            this.SightDirection = RotateDirection;
        }

}
}
