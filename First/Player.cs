using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class Player : Person
    {
        #region Конструкторы
        public Player() //Написать конструктор с заданием POwer и Health
        {
            new Player("NoName");
        }

        public Player(string name)
        {
            new Player(name, 100, 10, "N");
        }

        public Player(string name, int hp, int power, string sd)
        {
            this.PersonType = "Player";
            this.Name = name;
            this.Health = hp;
            this.Power = power;
            this.SightDirection = sd;
            this.Position = new Position();
            this.Directions = new Direction(Position);
        }
        #endregion

        public override void Move()
        {
            if (Program.Map[this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Around.x, this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Around.y] == "N")
            {
                this.Position = this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Around;
            }
            else
            {
                Console.WriteLine("Нельзя туда шагнуть");
            }
        }

        public override void Rotate()
        {
            if (this.SightDirection != this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Sight)
            {
                this.SightDirection = this.ReturnPoints(this.Position).Where(x => x.Input == Console.ReadKey().Key).FirstOrDefault().Sight;
            }
            else
            {
                Console.WriteLine("Выбери другое направление");
            }
        }

        public override void Search()
        {
            
    }
    }
}
