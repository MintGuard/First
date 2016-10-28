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
        public int Power { get; set; }
        public int Health { get; set; }
    
    public void Attack(IPerson target)
    {
        target.Health -= this.Power;
    }

    public void MovePlayer(string Direction)
    {
    if (Direction == "W")
        {
            if (Program.Map[this.Position.x - 1, this.Position.y] == "N")
                {
                    this.Position.x--;
                    Program.Map[this.Position.x, this.Position.y] = "P";
                    Program.Map[this.Position.x + 1, this.Position.y] = "N";
                }
            else
                {
                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
                }     
            }
    else if (Direction == "E") 
        {
            if (Program.Map[this.Position.x + 1, this.Position.y] == "N")
                {
                    this.Position.x++;
                    Program.Map[this.Position.x, this.Position.y] = "P";
                    Program.Map[this.Position.x - 1, this.Position.y] = "N";
                }
             else
                {
                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
                }
            }
    else if (Direction == "S")
        {
            if (Program.Map[this.Position.x, this.Position.y - 1] == "N")
                {
                    this.Position.y--;
                    Program.Map[this.Position.x, this.Position.y] = "P";
                    Program.Map[this.Position.x, this.Position.y + 1] = "N";
                }
            else
                {
                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
                }
            }
    else if (Direction == "N")
    {
        if (Program.Map[this.Position.x, this.Position.y + 1] == "N")
        {
            this.Position.y++;
            Program.Map[this.Position.x, this.Position.y] = "P";
            Program.Map[this.Position.x, this.Position.y - 1] = "N";
        }
        else
        {
            Console.WriteLine("Чувак там вроде кто то стоит, не?");
        }
    }
    else
    {
        Console.WriteLine("Нет такого направления");
    }
}
    public void MobsMove(string Direction) 
    {
        if (Direction == "W")
        {
            if (Program.Map[this.Position.x - 1, this.Position.y] == "N")
            {
                this.Position.x--;
                Program.Map[this.Position.x, this.Position.y] = "M";
                Program.Map[this.Position.x + 1, this.Position.y] = "N";
            }
            else
            {
                this.Position.x++;
                Program.Map[this.Position.x, this.Position.y] = "M";
                Program.Map[this.Position.x - 1, this.Position.y] = "N";
            }
        }
        if (Direction == "E")
        {
            if (Program.Map[this.Position.x + 1, this.Position.y] == "N")
                {
                    this.Position.x++;
                    Program.Map[this.Position.x, this.Position.y] = "M";
                    Program.Map[this.Position.x - 1, this.Position.y] = "N";
                }
            else 
                {
                    this.Position.x--;
                    Program.Map[this.Position.x, this.Position.y] = "M";
                    Program.Map[this.Position.x + 1, this.Position.y] = "N";
                }
        }
        if (Direction == "N")
        {
            if (Program.Map[this.Position.x, this.Position.y + 1] == "N")
                {
                    this.Position.y++;
                    Program.Map[this.Position.x, this.Position.y] = "M";
                    Program.Map[this.Position.x, this.Position.y - 1] = "N";
                }
            else 
                {
                    this.Position.y--;
                    Program.Map[this.Position.x, this.Position.y] = "M";
                    Program.Map[this.Position.x, this.Position.y + 1] = "N";
                }
        }
        if (Direction == "S")
        {
            if (Program.Map[this.Position.x, this.Position.y - 1] == "N")
                {
                    this.Position.y--;
                    Program.Map[this.Position.x, this.Position.y] = "M";
                    Program.Map[this.Position.x, this.Position.y + 1] = "N";
                }
            else 
                {
                    this.Position.y++;
                    Program.Map[this.Position.x, this.Position.y] = "M";
                    Program.Map[this.Position.x, this.Position.y - 1] = "N";
                }
        }
    }
    public virtual void Search(List<Mob> Mobs, IPerson Player, int x, int y)
    {
        foreach (Mob SelectesMob in Mobs)
    {
        {
            if (((SelectesMob.Position.x == (Player.Position.x - 1)) && (SelectesMob.Position.y == Player.Position.y)) |
                           ((SelectesMob.Position.x == (Player.Position.x + 1)) && (SelectesMob.Position.y == Player.Position.y)) |
                           ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y - 1))) |
                           ((SelectesMob.Position.x == Player.Position.x) && (SelectesMob.Position.y == (Player.Position.y + 1))))
            {
                int[] coor = { x, y };
                SelectesMob.Position.x = x;
                SelectesMob.Position.y = y;
                Console.WriteLine("Координаты мобов" + ":" + " " + coor);
            }
            else {
                Console.WriteLine("Поблизости нет мобов");
                }
            }
        }
    }

    public void Rotate(string RotateDirection)
    {
        this.SightDirection = RotateDirection;
    }

}
}
