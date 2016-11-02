using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    public class Mob : Person
    {

        #region Конструкторы
        public Mob()
        {
            new Mob("Noname");
        }

        public Mob(string name)
        {
            new Mob(name, 30, 9, "N");
        }

        public Mob(string name, int hp, int power, string sd)
        {
            this.PersonType = "Enemy";
            this.Name = name;
            this.Health = hp;
            this.Power = power;
            this.SightDirection = sd;
        }
        #endregion

        public override void Search()
        {

        }
    }
}
