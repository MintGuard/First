using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First
{
    class Mob : Person
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

            //ToDo Исправить, убрать инициализацию прямо в классе
            this.ClosePoints = new PointsAround(Position);
        }
        #endregion
        //ToDo Исправить косяки
        public override void Search(IPerson Player)
        {

        }
    }
}
