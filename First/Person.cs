using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    public class Person: IPerson
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

    public void Move(string Direction)
    {
        if (Direction == "W")
        {
            if (Program.Map[this.Position.x][this.Position.y] == "N")
                {
                    this.Position.x--;
                    Program.Map[this.Position.x][this.Position.y] = "P";
                    Program.Map[this.Position.x + 1][this.Position.y] = "N";
                }
                else
                {
                    Console.WriteLine("Чувак там вроде кто то стоит, не?");
                }
            
        }
        if (Direction == "E") this.Position.x++;
        if (Direction == "S") this.Position.y--;
        if (Direction == "N") this.Position.y++;

    }

    public virtual void Search()
    {
    }

    public void Rotate(string RotateDirection)
    {
        this.SightDirection = RotateDirection;
    }

}
}
